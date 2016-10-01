using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Amazon.EC2.Model;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.Services;
using CloudStudio.GUI.Forms;
using CloudStudio.Services;
using Amazon.ElasticLoadBalancing.Model;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.Services.Utilities;
using System.Threading;
using CloudStudio.Services.Services;
using System.Diagnostics;
using CloudStudio.GUI.Utils;
using Amazon.ECS.Model;
using CloudStudio.GUI.Classes;
using System.Drawing.Imaging;
using Amazon.RDS.Model;
using CloudStudio.GUI.Model;

namespace CloudStudio.GUI.Controls {

    public partial class CloudView : UserControl {

        private MainMDIForm mdiForm;
        private CloudAccountService CloudAccountService;
        private Vpc vpc;
        private PropertyGrid propertyGrid;

        private int x = 25;
        private int y = 25;

        private InternetGateway internetGateway;

        Boolean bHaveMouse;
        Point ptOriginal = new Point();
        Point ptLast = new Point();

        // For drawing.
        IList<Node> nodes = new List<Node>();
        IList<Node> selectedNodes = new List<Node>();
        IList<Line> lines = new List<Line>();
        IList<ElbLine> elbLines = new List<ElbLine>();

        // Record keeping.
        IList<string> tagNames = new List<string>();

        IDictionary<string, string> autoscalingInstances;

        // Set via the filters menu.
        private bool filterInstances = false;
        private bool filterLoadBalancers = false;
        private bool filterInternetGateways = false;
        private bool filterRdsInstances = false;

        //private Grid thisGrid;

        private bool fullRefresh = true;

        public CloudView() {

            InitializeComponent();

            this.ResizeRedraw = true;
            //this.thisGrid = new Grid();

            SetStyle(ControlStyles.ResizeRedraw, true);

        }

        public void InitializeServices(MainMDIForm mdiForm, CloudAccountService CloudAccountService, Vpc vpc, PropertyGrid propertyGrid) {

            this.mdiForm = mdiForm;
            this.CloudAccountService = CloudAccountService;
            this.vpc = vpc;
            this.propertyGrid = propertyGrid;

            ReadOnlyModePanel.Visible = mdiForm.GetCloudAccount().ReadOnlyMode;

        }

        private void LoadInternetGateways() {

            // Get the internet gateways for this vpc.
            GetInternetGatewaysResponse getInternetGatewaysResponse = mdiForm.GetAWSServices().GetInternetGateways(vpc);

            Parallel.ForEach(getInternetGatewaysResponse.InternetGateways, (InternetGateway gateway, ParallelLoopState state) =>
            {

                Point point = new Point(x, y);
                RectangleF rectF1 = new Rectangle(point.X, point.Y, 75, 75);
                nodes.Add(new Node(rectF1, gateway, FilteredInternetGateway.FromInternetGateway(gateway)));

                this.internetGateway = gateway;

                x += 100;

                if(getInternetGatewaysResponse.InternetGateways.Count == 0)
                {
                    // Clear the internet gateway.
                    this.internetGateway = null;
                }

            });

        }

        private int LoadLoadBalancers(Amazon.EC2.Model.Subnet subnet) {

            int loadBalancersCount = 0;

            // Get the load balancers for this vpc.
            GetLoadBalancersResponse getLoadBalancersResponse = mdiForm.GetAWSServices().GetLoadBalancers();

            Parallel.ForEach(getLoadBalancersResponse.LoadBalancerDescriptions, (LoadBalancerDescription loadBalancer, ParallelLoopState state) =>
            {                

                if (loadBalancer.Subnets.Contains(subnet.SubnetId))
                {

                    loadBalancersCount++;

                    Point point = new Point(x, y);
                    RectangleF rectF1 = new RectangleF(point.X, point.Y, 75, 75);
                    nodes.Add(new Node(rectF1, loadBalancer, FilteredElasticLoadBalancer.FromLoadBalancerDescription(loadBalancer)));

                    x = x + 100;

                    // The line for connecting an ELB to an instance.
                    Pen pen = new Pen(Color.DarkGray, 1f);
                    //pen.DashPattern = new float[] { 4.0F, 2.0F, 1.0F, 3.0F };

                    Parallel.ForEach(loadBalancer.Instances, (Amazon.ElasticLoadBalancing.Model.Instance instance, ParallelLoopState elbState) =>
                    {
                        // Find this instance.
                        Parallel.ForEach(nodes, (Node node, ParallelLoopState instanceState) =>
                        {
                            if (node.Tag is Amazon.EC2.Model.Instance)
                            {                                

                                Amazon.EC2.Model.Instance i = (Amazon.EC2.Model.Instance)node.Tag;
                                if (instance.InstanceId == i.InstanceId)
                                {

                                    // Where to draw to connect to an instance.
                                    int bottom = (int)node.Rectangle.Left + 38;
                                    int middle = (int)node.Rectangle.Top + 75;

                                    // Draw the starting line in the top middle (x+38).
                                    elbLines.Add(new ElbLine(pen, new Point(point.X + 38, point.Y), new Point(bottom, middle)));

                                    instanceState.Break();
                                }
                            }
                        });
                    });

                    if (x + 100 > panel1.Width)
                    {
                        x = 25;
                        y += 100;
                    }

                }

            });

            return loadBalancersCount;

        }

        private int LoadRDSInstances(Amazon.EC2.Model.Subnet subnet)
        {

            int loadRDSInstances = 0;

            // Get the load balancers for this vpc.
            GetRDSInstancesResponse getRDSInstancesResponse = mdiForm.GetAWSServices().GetRDSInstances();

            foreach(DBInstance dbInstance in getRDSInstancesResponse.DBInstances)
            {
                
                bool add = false;

                foreach(Amazon.RDS.Model.Subnet s in dbInstance.DBSubnetGroup.Subnets)
                {
                    if(s.SubnetIdentifier == subnet.SubnetId)
                    {
                        add = true;
                        break;
                    }
                }                    
                    
               if(add == true)
                {

                    loadRDSInstances++;

                    Point point = new Point(x, y);
                    RectangleF rectF1 = new RectangleF(point.X, point.Y, 75, 75);
                    nodes.Add(new Node(rectF1, dbInstance, FilteredRdsInstance.FromDbInstance(dbInstance)));

                    x = x + 100;

                    if (x + 100 > panel1.Width)
                    {
                        x = 25;
                        y += 100;
                    }

                }

            }

            return loadRDSInstances;

        }

        private int LoadInstances(Amazon.EC2.Model.Subnet subnet) {

            GetInstancesResponse getInstancesResponse = mdiForm.GetAWSServices().GetInstancesInSubnet(subnet);

            IList<Amazon.EC2.Model.Instance> refreshedInstances = getInstancesResponse.Instances;

            foreach(Amazon.EC2.Model.Instance instance in refreshedInstances) {

                Point point = new Point(x, y);
                RectangleF rectF1 = new Rectangle(point.X, point.Y, 75, 75);
                nodes.Add(new Node(rectF1, instance, FilteredInstance.FromInstance(instance)));

                x += 100;

                if(x + 100 > panel1.Width)
                {
                    x = 25;
                    y += 100;
                }

            }

            return refreshedInstances.Count;

        }

        /*private void LoadSubnets() {

            // Get the subnets for this vpc.
            GetSubnetsResponse getSubnetsResponse = mdiForm.GetAWSServices().GetSubnets(vpc);

            SubnetsListView.Items.Clear();

            foreach (Subnet subnet in getSubnetsResponse.Subnets) {

                Application.DoEvents();

                ListViewItem lvi = new ListViewItem();

                String name = "[None]";
                foreach (Amazon.EC2.Model.Tag tag in subnet.Tags) {

                    Application.DoEvents();

                    if (tag.Key == "Name") {
                        name = tag.Value;
                        break;
                    }

                }

                lvi.Text = name;
                lvi.SubItems.Add(subnet.State.Value);
                lvi.SubItems.Add(subnet.CidrBlock);
                lvi.SubItems.Add(subnet.AvailabilityZone);
                lvi.ImageIndex = 5;

                SubnetsListView.Items.Add(lvi);

            }

        }*

        private void LoadRoutes() {

            // Get the route tables for this vpc.
            GetRouteTablesResponse getRouteTablesResponse = mdiForm.GetAWSServices().GetRouteTables(vpc);

            RoutesListView.Items.Clear();

            foreach (RouteTable route in getRouteTablesResponse.RouteTables) {

                Application.DoEvents();

                ListViewItem lvi = new ListViewItem();

                StringBuilder sb = new StringBuilder();

                foreach (RouteTableAssociation assoc in route.Associations) {
                    sb.Append(assoc.SubnetId + " ");
                }

                String name = "[None]";
                foreach (Amazon.EC2.Model.Tag tag in route.Tags) {

                    Application.DoEvents();

                    if (tag.Key == "Name") {
                        name = tag.Value;
                        break;
                    }

                }

                lvi.Text = name;
                lvi.SubItems.Add(sb.ToString().Trim());
                lvi.ImageIndex = 6;

                RoutesListView.Items.Add(lvi);

            }

        }*/

        public void RefreshResouces() {

            this.Cursor = Cursors.WaitCursor;

            if (this.vpc != null) {

                this.nodes.Clear();
                this.lines.Clear();

                // Reset the positions for drawing.
                x = 25;
                y = 25;

                // Get the autoscaling groups.
               // GetAutoScalingGroupInstancesResponse getAutoScalingGroupInstancesResponse = mdiForm.GetAWSServices().GetAutoScalingGroups();
                //autoscalingInstances = getAutoScalingGroupInstancesResponse.Instances;

                // Get the subnets on this VPC.
                GetSubnetsResponse getSubnetsResponse = mdiForm.GetAWSServices().GetSubnets(this.vpc);

                // Do these subnet by subnet.
                foreach (Amazon.EC2.Model.Subnet subnet in getSubnetsResponse.Subnets)
                {
                    
                    // Add a separator.
                    lines.Add(new Line(new Pen(Color.Black, 1f), new Point(0, y), new Point(5000, y), AwsUtils.GetNameFromTags(subnet.Tags) + " - " + subnet.SubnetId + " - " + subnet.AvailabilityZone));

                    y = y + 25;

                    int instances = LoadInstances(subnet);

                    if (instances > 0)
                    {
                        // Start the ELBs on a new "line" below the instances for this subnet.
                        y = y + 100;
                        x = 25;
                    }

                    int elbs = LoadLoadBalancers(subnet);

                    // Start the RDS instances on a new "line" below the instances for this subnet.
                    if (elbs > 0)
                    {
                        y = y + 100;
                        x = 25;
                    }

                    int rds = LoadRDSInstances(subnet);

                    if (rds > 0)
                    {
                        y = y + 100;
                        x = 25;
                    }

                    // Subtract some because we don't need this much space between subnets.
                    //y = y - 75;

                }

                // Add a separator.
                lines.Add(new Line(new Pen(Color.Black, 1f), new Point(0, y+100), new Point(5000, y+100), "Internet Gateways"));

                x = 25;
                y += 125;

                LoadInternetGateways();

                // Draw the items on the panel.                
                panel1.Invalidate();

                // Get the security groups for this CPC.
                GetSecurityGroupsResponse getSecurityGroupsResponse = mdiForm.GetAWSServices().GetSecurityGroups(this.vpc.VpcId);

                if (getSecurityGroupsResponse.Success == true)
                {
                    InstanceSecurityGroupsToolStripMenuItem.DropDownItems.Clear();
                    foreach(SecurityGroup sg in getSecurityGroupsResponse.SecurityGroups)
                    {

                        ToolStripItem tsi = new ToolStripMenuItem(sg.GroupName);
                        tsi.Tag = sg;

                        InstanceSecurityGroupsToolStripMenuItem.DropDownItems.Add(tsi);
                    }
                }

                // TODO: Get all the tags.
                /*IDictionary<string, string> tags = mdiForm.GetAWSServices().DescribeTagKeys();

                foreach(string key in tags.Keys)
                {
                    ToolStripItem tagItem = WhereTagToolStripMenuItem.DropDownItems.Add(key);
                }*/

                fullRefresh = false;

            }

            this.Cursor = Cursors.Default;

        }

        private string BuildInstanceLabelText(Amazon.EC2.Model.Instance instance)
        {

            IList<string> instanceLabelText = new List<string>();

            if (Properties.Settings.Default.PublicDNSName == true)
            {
                if (instance.PublicIpAddress != null)
                {
                    instanceLabelText.Add(instance.PublicDnsName);
                }
            }

            if (Properties.Settings.Default.ShowPublicIP == true)
            {
                if (instance.PublicIpAddress != null)
                {
                    instanceLabelText.Add(instance.PublicIpAddress);
                }
            }

            if (Properties.Settings.Default.PrivateIP == true)
            {
                if (instance.PrivateIpAddress != null)
                {
                    instanceLabelText.Add(instance.PrivateIpAddress);
                }
            }

            if (Properties.Settings.Default.InstanceName == true)
            {
                instanceLabelText.Add(AwsUtils.GetNameFromTags(instance.Tags));
            }

            if (Properties.Settings.Default.ShowInstanceID == true)
            {
                instanceLabelText.Add(instance.InstanceId);
            }

            return String.Join("\n", instanceLabelText);

        }

        public Pen GetPenForState(String stateName)
        {

            Pen pen = null;

            if (stateName.ToLower() == "running")
            {
                pen = new Pen(Color.Green, 2f);
            }
            else if (stateName.ToLower() == "stopped")
            {
                pen = new Pen(Color.Black, 1f);
            }
            else if (stateName.ToLower() == "pending")
            {
                pen = new Pen(Color.LightGreen, 2f);
            }
            else if (stateName.ToLower() == "stopping")
            {
                pen = new Pen(Color.LightGray, 2f);
            }
            else if (stateName.ToLower() == "shutting-down")
            {
                pen = new Pen(Color.DarkGray, 2f);
            }
            else if (stateName.ToLower() == "terminated")
            {
                pen = new Pen(Color.Red, 2f);
            }
            else
            {
                pen = new Pen(Color.Black, 1f);
            }

            return pen;

        }

        public Color GetColorForState(String stateName)
        {

            Color color = Color.White;

            if (stateName.ToLower() == "running")
            {
                color = Color.Green;
            }
            else if (stateName.ToLower() == "stopped")
            {
                color = Color.White;
            }
            else if (stateName.ToLower() == "pending")
            {
                color = Color.LightGreen;
            }
            else if (stateName.ToLower() == "stopping")
            {
                color = Color.LightGray;
            }
            else if (stateName.ToLower() == "shutting-down")
            {
                color = Color.DarkGray;
            }
            else if (stateName.ToLower() == "terminated")
            {
                color = Color.Red;
            }

            return color;

        }

        private void GetSelectedInstances()
        {

            selectedNodes.Clear();

            foreach (Node node in nodes)
            {
                if (node.Selected == true && node.Tag is Amazon.EC2.Model.Instance)
                {
                    selectedNodes.Add(node);
                }
            }

            // If none are selected maybe we just clicked on one?
            if(selectedNodes.Count == 0)
            {
                foreach (Node node in nodes)
                {
                    if (node.Rectangle.Contains(panel1.PointToClient(Cursor.Position)) && node.Tag is Amazon.EC2.Model.Instance)
                    {
                        selectedNodes.Add(node);
                    }
                }
            }

        }

        private void startInstanceToolStripMenuItem_Click_1(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // Start the instances.
            
            List<string> instanceIds = new List<string>();

            foreach (Node node in selectedNodes)
            {

                Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;
                instanceIds.Add(instance.InstanceId);

                // Start a background process worker to watch this thread.
                BackgroundWorker instanceStateWatcher = new BackgroundWorker();
                instanceStateWatcher.WorkerReportsProgress = false;
                instanceStateWatcher.WorkerSupportsCancellation = true;
                instanceStateWatcher.DoWork += new DoWorkEventHandler(instanceStateWatcher_DoWork);
                //worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                instanceStateWatcher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(instanceStateWatcher_RunWorkerCompleted);
                instanceStateWatcher.RunWorkerAsync(instance);

            }

            mdiForm.GetAWSServices().StartInstances(instanceIds);               

        }

        private void instanceStateWatcher_DoWork(object sender, DoWorkEventArgs e)
        {

            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance) e.Argument;

            Amazon.EC2.Model.InstanceState initialState = instance.State;

            do
            {

                GetInstancesResponse response = mdiForm.GetAWSServices().GetInstances(new List<Amazon.EC2.Model.Instance> { instance });

                if (response.Instances.Count > 0)
                {

                    Amazon.EC2.Model.Instance updatedInstance = response.Instances[0];

                    foreach(Node node in nodes)
                    {
                        if(node.Tag is Amazon.EC2.Model.Instance)
                        {
                            Amazon.EC2.Model.Instance nodeInstance = (Amazon.EC2.Model.Instance)node.Tag;

                            if(nodeInstance.InstanceId == instance.InstanceId)
                            {
                                node.Tag = instance;
                                fullRefresh = true;
                                break;
                            }

                        }
                    }

                    // Wait a couple of seconds before continuing.
                    Thread.Sleep(3000);

                }
                else
                {

                    // Something happened. This instance does not exist anymore.
                    e.Result = null;
                    e.Cancel = true;
                    break;

                }

            } while (true);

        }

        private void instanceStateWatcher_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)e.Result;
        }

        private void stopInstanceToolStripMenuItem_Click_1(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // Stop instances.

            List<string> instanceIds = new List<string>();

            foreach (Node node in selectedNodes)
            {

                if (node.Tag is Amazon.EC2.Model.Instance)
                {

                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;
                    instanceIds.Add(instance.InstanceId);

                    // Start a background process worker to watch this thread.
                    BackgroundWorker instanceStateWatcher = new BackgroundWorker();
                    instanceStateWatcher.WorkerReportsProgress = false;
                    instanceStateWatcher.WorkerSupportsCancellation = true;
                    instanceStateWatcher.DoWork += new DoWorkEventHandler(instanceStateWatcher_DoWork);
                    //worker.ProgressChanged += new ProgressChangedEventHandler(bw_ProgressChanged);
                    instanceStateWatcher.RunWorkerCompleted += new RunWorkerCompletedEventHandler(instanceStateWatcher_RunWorkerCompleted);
                    instanceStateWatcher.RunWorkerAsync(instance);

                }

            }

            mdiForm.GetAWSServices().StopInstances(instanceIds);

        }

        private void terminateInstanceToolStripMenuItem_Click_1(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // Terminate instances.

            if (MessageBox.Show("Terminate the selected instances?", "Terminate", MessageBoxButtons.YesNo) == DialogResult.Yes) {

                List<string> instanceIds = new List<string>();

                foreach (Node node in selectedNodes)
                {

                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;
                    instanceIds.Add(instance.InstanceId);

                }

                new Thread(delegate()
                {
                    mdiForm.GetAWSServices().TerminateInstances(instanceIds);
                });

            }

        }

        private void launchNewInstanceToolStripMenuItem_Click_1(object sender, EventArgs e) {

            // Launch new instance.

            LaunchInstanceForm lif = new LaunchInstanceForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices());
            if (lif.ShowDialog() == DialogResult.OK)
            {
                // TODO: Refresh the nodes collection.
                panel1.Invalidate();
            }

        }

        private void detachToolStripMenuItem_Click(object sender, EventArgs e) {

            // Detach the internet gateway from the VPC.
            DetachInternetGateway();

        }

        private void Zoom100ToolStripMenuItem_Click(object sender, EventArgs e) {

            // TODO: Zoom the panel.

            /*designer1.Document.Zoom = 1.0F;

            Zoom100ToolStripMenuItem.Checked = true;
            Zoom75ToolStripMenuItem.Checked = false;
            Zoom50ToolStripMenuItem.Checked = false;
            Zoom25ToolStripMenuItem.Checked = false;*/

        }

        private void Zoom75ToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Zoom the panel.

            /*designer1.Document.Zoom = 0.75F;

            Zoom100ToolStripMenuItem.Checked = false;
            Zoom75ToolStripMenuItem.Checked = true;
            Zoom50ToolStripMenuItem.Checked = false;
            Zoom25ToolStripMenuItem.Checked = false;*/

        }

        private void Zoom50ToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Zoom the panel.

            /*designer1.Document.Zoom = 0.50F;

            Zoom100ToolStripMenuItem.Checked = false;
            Zoom75ToolStripMenuItem.Checked = false;
            Zoom50ToolStripMenuItem.Checked = true;
            Zoom25ToolStripMenuItem.Checked = false;*/

        }

        private void Zoom25ToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Zoom the panel.

            /*designer1.Document.Zoom = 0.25F;

            Zoom100ToolStripMenuItem.Checked = false;
            Zoom75ToolStripMenuItem.Checked = false;
            Zoom50ToolStripMenuItem.Checked = false;
            Zoom25ToolStripMenuItem.Checked = true;*/

        }

        private void RefreshToolStripButton_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripButton)sender).Name);
            
            RefreshResouces();
        }

        private void ViewInstancesToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);
            
            ViewInstancesToolStripMenuItem.Checked = !ViewInstancesToolStripMenuItem.Checked;
            filterInstances = !ViewInstancesToolStripMenuItem.Checked;
            panel1.Invalidate();
        }

        private void ViewIternetGatewaysToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            ViewIternetGatewaysToolStripMenuItem.Checked = !ViewIternetGatewaysToolStripMenuItem.Checked;
            filterInternetGateways = !ViewIternetGatewaysToolStripMenuItem.Checked;
            panel1.Invalidate();
        }

        private void ViewLoadBalancersToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            ViewLoadBalancersToolStripMenuItem.Checked = !ViewLoadBalancersToolStripMenuItem.Checked;
            filterLoadBalancers = !ViewLoadBalancersToolStripMenuItem.Checked;
            panel1.Invalidate();
        }

        private void InstanceVolumesToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (this.selectedNodes.Count > 0)
            {

                // Get the first one.
                Node node = selectedNodes[0];

                Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                VolumesForm volumes = new VolumesForm(mdiForm, mdiForm.GetCloudAccount(), instance, this.vpc);
                volumes.ShowDialog();

                this.FindForm().Refresh();

            }

        }

        private void launchNewInstanceToolStripMenuItem1_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            LaunchInstanceForm lif = new LaunchInstanceForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices());
            if (lif.ShowDialog() == DialogResult.OK)
            {
                // TODO: Refresh the Nodes collection.
                panel1.Invalidate();
            }

        }

        private void InstanceTagsToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (selectedNodes.Count == 1)
            {

                Node node = selectedNodes[0];

                Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                TagEditorForm tef = new TagEditorForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices(), instance.InstanceId, instance.Tags);
                tef.ShowDialog();

            } 
            else
            {
                // TODO: Do anything for multiple instances?
            }

        }

        private void SecurityGroupsToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            IList<Vpc> vpcs = new List<Vpc>();
            vpcs.Add(this.vpc);

            SecurityGroupsForm sgf = new SecurityGroupsForm(mdiForm.GetCloudAccount(), mdiForm.GetAWSServices(), vpcs);
            sgf.ShowDialog();

            this.FindForm().Refresh();

        }

        private void VolumesAndSnapshotsToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            VolumesForm vf = new VolumesForm(mdiForm, mdiForm.GetCloudAccount(), null, vpc);
            vf.ShowDialog();

            this.FindForm().Refresh();

        }

        private void ConnectRemoteDesktopToolStripMenuItem_Click(object sender, EventArgs e) {

            // TODO: Test this.

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (selectedNodes.Count > 0)
            {
                Node node = selectedNodes[0];

                Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                string server = instance.PublicIpAddress;
                int port = 3389;

                if (Properties.Settings.Default.UseWindowsRDP == true) {

                    Process.Start("mstsc.exe", string.Format("/v:{0}:{1}", server, port));

                }

            }
            else
            {
                // TODO: Handle multiple selected instances?
            }
        }

        private void ConnectSSHToolStripMenuItem_Click(object sender, EventArgs e) {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (selectedNodes.Count > 0) {

                Node node = selectedNodes[0];

                Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                ConnectSSHForm csf = new ConnectSSHForm(instance, mdiForm.GetCloudAccount());
                csf.ShowDialog();

            }
       
        }

        private void PNGToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            saveFileDialog1.Title = "Export";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Filter = "*.png|*.png";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = this.vpc.VpcId + ".png";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (Bitmap bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height))
                {
                    panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
                    bitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                }

            }           

        }

        private void JPGToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            saveFileDialog1.Title = "Export";
            saveFileDialog1.OverwritePrompt = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.Filter = "*.jpg|*.jpg";
            saveFileDialog1.FilterIndex = 0;
            saveFileDialog1.FileName = this.vpc.VpcId + ".jpg";

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {

                using (Bitmap bitmap = new Bitmap(panel1.ClientSize.Width, panel1.ClientSize.Height))
                {
                    panel1.DrawToBitmap(bitmap, panel1.ClientRectangle);
                    bitmap.Save(saveFileDialog1.FileName, ImageFormat.Jpeg);
                }

            }   

        }

        private void DocumentContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (mdiForm.GetCloudAccount().ReadOnlyMode == true)
            {
                // In read-only mode.
                launchNewInstanceToolStripMenuItem1.Enabled = false;
                PasteToolStripMenuItem.Enabled = false;
            }
            else
            {
                // Not in read-only mode.
                launchNewInstanceToolStripMenuItem1.Enabled = true;
                PasteToolStripMenuItem.Enabled = !ClipboardUtils.IsClipboardEmpty();
            }
        }

        private void InternetGatewaysContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (mdiForm.GetCloudAccount().ReadOnlyMode == true)
            {
                detachToolStripMenuItem.Enabled = false;
            }
            else
            {
                detachToolStripMenuItem.Enabled = true;
            }
        }

        private void ELBContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            if (mdiForm.GetCloudAccount().ReadOnlyMode == true)
            {
                RegisterInstancesWithELBToolStripMenuItem.Enabled = false;
            }
            else
            {
                RegisterInstancesWithELBToolStripMenuItem.Enabled = true;
            }
        }

        private void CopyInstanceToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Get the selected instances.

            /*ElementCollection selectedElements = designer1.Document.SelectedElements;

            List<string> instanceIds = new List<string>();

            foreach (BaseElement element in selectedElements)
            {

                //Application.DoEvents();

                if (element.Tag is Amazon.EC2.Model.Instance)
                {

                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)element.Tag;
                    instanceIds.Add(instance.InstanceId);
 
                }
                
            }

            ClipboardUtils.CopyInstances(instanceIds);*/

        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            if (Properties.Settings.Default.ShowPasteConfirmation == true)
            {

                PasteInstanceForm pif = new PasteInstanceForm();
                if (pif.ShowDialog() == DialogResult.OK)
                {
                    pasteInstances();
                }

            }
            else
            {
                pasteInstances();
            }
        }

        private void pasteInstances()
        {
            
            // Get the instances.
            GetInstancesResponse response = mdiForm.GetAWSServices().GetInstances(ClipboardUtils.GetCopiedInstances());

            foreach(Amazon.EC2.Model.Instance instance in response.Instances)
            {
                // TODO: Do the paste.
            }

        }

        private void DetachInternetGateway()
        {
            if (MessageBox.Show("Detach the internet gateway from the VPC?", Application.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                GenericActionResponse response = mdiForm.GetAWSServices().DetachInternetGateway(this.internetGateway, this.vpc);
                if (response.Success == true)
                {
                    //RemoveInternetGateways();
                    this.internetGateway = null;
                }
                else
                {
                    MessageBox.Show("Unable to detach the internet gateway.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void detachFromVPCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DetachInternetGateway();
        }

        private void attachToVPCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            GetInternetGatewaysResponse response = mdiForm.GetAWSServices().GetInternetGateways();

            InternetGatewaysForm igf = new InternetGatewaysForm(response.InternetGateways);
            if(igf.ShowDialog() == DialogResult.OK)
            {
                InternetGateway gateway = igf.SelectedInternetGateway;

                // Attach this gateway to the VPC.
                GenericActionResponse attachResponse = mdiForm.GetAWSServices().AttachInternetGateway(gateway, this.vpc);

                if (attachResponse.Success == true)
                {
                    MessageBox.Show("The gateway has been attached.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The gateway could not be attached.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                // Redraw the gateway.
                LoadInternetGateways();

            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            
            if(fullRefresh == true)
            {
                RefreshResouces();
            }            

            /*thisGrid.Origin = new Point(5, 5);
            thisGrid.GridCellSize = new Size(40, 50);
            thisGrid.HorizontalCells = panel1.Width;
            thisGrid.VerticalCells = panel1.Height;

            // Make some fancy pen, make ANY pen you like here
            Pen myPen = new Pen(Color.LightGray, 2f);
            myPen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;
            myPen.DashCap = System.Drawing.Drawing2D.DashCap.Triangle;
            thisGrid.Draw(e.Graphics, myPen);*/

            System.Drawing.SolidBrush blackBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);

            foreach (Node node in nodes)            
            {

                if (node.Tag is Amazon.EC2.Model.Instance && filterInstances == false)
                {

                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                    string nodeText = BuildInstanceLabelText(instance);

                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {                        

                        if (node.Selected == true)
                        {
                            System.Drawing.SolidBrush myBrush = new System.Drawing.SolidBrush(System.Drawing.Color.LightBlue);
                            e.Graphics.FillRectangle(myBrush, Rectangle.Round(node.Rectangle));
                            e.Graphics.DrawString(nodeText, font1, Brushes.Black, node.Rectangle);
                            myBrush.Dispose();
                        }
                        else
                        {
                            e.Graphics.DrawRectangle(GetPenForState(instance.State.Name.Value), Rectangle.Round(node.Rectangle));
                            e.Graphics.DrawString(nodeText, font1, Brushes.Black, node.Rectangle);
                        }

                    }
                    
                }
                else if (node.Tag is InternetGateway && filterInternetGateways == false)
                {

                    InternetGateway gateway = (InternetGateway)node.Tag;

                    string text1 = gateway.InternetGatewayId;
                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString(text1, font1, Brushes.Black, node.Rectangle);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(node.Rectangle));
                    }

                }
                else if (node.Tag is LoadBalancerDescription && filterLoadBalancers == false)
                {

                    LoadBalancerDescription elb = (LoadBalancerDescription)node.Tag;

                    string text1 = elb.LoadBalancerName;
                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString(text1, font1, Brushes.Black, node.Rectangle);
                        e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(node.Rectangle));
                    }

                }
                else if (node.Tag is DBInstance && filterRdsInstances == false)
                {

                    DBInstance rds = (DBInstance)node.Tag;

                    string text1 = AwsUtils.GetRDSLabel(rds);
                    using (Font font1 = new Font("Arial", 8, FontStyle.Regular, GraphicsUnit.Point))
                    {
                        e.Graphics.DrawString(text1, font1, Brushes.Black, node.Rectangle);
                        e.Graphics.DrawRectangle(Pens.Blue, Rectangle.Round(node.Rectangle));
                    }

                }

            }

            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", 8);
            foreach(Line line in lines)
            {

                // These are subnet lines.
                e.Graphics.DrawLine(line.Pen, line.Point1, line.Point2);
                e.Graphics.DrawString(line.Label, drawFont, blackBrush, 10, line.Point1.Y);

            }
            drawFont.Dispose();

            // Only do this if instances and ELBs are not filtered.
            if (filterInstances == false && filterLoadBalancers == false)
            {
                foreach (ElbLine line in elbLines)
                {
                    e.Graphics.DrawLine(line.Pen, line.Point1, line.Point2);                    
                }
            }

            blackBrush.Dispose();
            e.Graphics.Dispose();

            panel1.Width = CloudViewPanel.Width - System.Windows.Forms.SystemInformation.VerticalScrollBarWidth;
            panel1.Height = y + 250;
            
            //mdiForm.LogOutputMessage("Refreshed cloud view for VPC " + this.vpc.VpcId + ".");
                     
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == System.Windows.Forms.MouseButtons.Right)
            {

                bool onNode = false;

                foreach(Node node in nodes)
                {
                    if (node.Rectangle.Contains(e.Location))
                    {

                        if (node.Tag is Amazon.EC2.Model.Instance)
                        {
                            onNode = true;
                            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                            if (instance.State.Name == "Stopped")
                            {

                                startInstanceToolStripMenuItem.Enabled = true;
                                stopInstanceToolStripMenuItem.Enabled = false;

                            }
                            else
                            {

                                startInstanceToolStripMenuItem.Enabled = false;
                                stopInstanceToolStripMenuItem.Enabled = true;

                            }

                            InstancesContextMenuStrip.Show(panel1, new Point(e.X, e.Y));

                        }
                        else if (node.Tag is InternetGateway)
                        {
                            onNode = true;
                            InternetGateway instance = (InternetGateway)node.Tag;

                            InternetGatewaysContextMenuStrip.Show(panel1, new Point(e.X, e.Y));

                        }
                        else if (node.Tag is LoadBalancerDescription)
                        {
                            onNode = true;
                            LoadBalancerDescription elb = (LoadBalancerDescription)node.Tag;

                            ELBContextMenuStrip.Show(panel1, new Point(e.X, e.Y));

                        }

                    }

                }

                if(onNode == false)
                {
                    DocumentContextMenuStrip.Show(panel1, new Point(e.X, e.Y));
                }

            }
            else
            {
                bool onNode = false;

                foreach(Node node in nodes)
                {
                    if (node.Rectangle.Contains(e.Location))
                    {
                        // Update the properties.
                        System.Diagnostics.Debug.WriteLine("Showing properties");
                        propertyGrid.SelectedObject = node.FilteredObject;

                        break;
                    }
                }

                /*// Make a note that we "have the mouse".
                bHaveMouse = true;
               
                // Store the "starting point" for this rubber-band rectangle.
                ptOriginal.X = e.X;
                ptOriginal.Y = e.Y;

                // Special value lets us know that no previous
                // rectangle needs to be erased.
                ptLast.X = -1;
                ptLast.Y = -1;*/

                
            }

        }

        // Convert and normalize the points and draw the reversible frame.
        private void MyDrawReversibleRectangle(Point p1, Point p2)
        {
            Rectangle rc = new Rectangle();

            // Convert the points to screen coordinates.
            p1 = PointToScreen(p1);
            p2 = PointToScreen(p2);
        
            // Normalize the rectangle.
            if (p1.X < p2.X)
            {
                rc.X = p1.X;
                rc.Width = p2.X - p1.X;
            }
            else
            {
                rc.X = p2.X;
                rc.Width = p1.X - p2.X;
            }
            if (p1.Y < p2.Y)
            {
                rc.Y = p1.Y;
                rc.Height = p2.Y - p1.Y;
            }
            else
            {
                rc.Y = p2.Y;
                rc.Height = p1.Y - p2.Y;
            }

            // Draw the reversible frame.
            ControlPaint.DrawReversibleFrame(rc, Color.Red, FrameStyle.Thick);

        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
        
            // Set internal flag to know we no longer "have the mouse".
            bHaveMouse = false;

            // If we have drawn previously, draw again in that spot
            // to remove the lines.
            if (ptLast.X != -1)
            {
                Point ptCurrent = new Point(e.X, e.Y);
                MyDrawReversibleRectangle(ptOriginal, ptLast);
            }

            RectangleF rectf = new RectangleF(ptOriginal, new Size(Math.Abs(ptOriginal.X - ptLast.X), Math.Abs(ptOriginal.Y - ptLast.Y)));

            Parallel.ForEach(nodes, (Node node, ParallelLoopState state) =>
            {
                if (rectf.Contains(node.Rectangle))
                {
                    //System.Diagnostics.Debug.WriteLine("Contains: " + node.ID);
                    node.Selected = true;
                }
                else
                {
                    node.Selected = false;
                }
            });

            // Set flags to know that there is no "previous" line to reverse.
            ptLast.X = -1;
            ptLast.Y = -1;
            ptOriginal.X = -1;
            ptOriginal.Y = -1;

            //panel1.Invalidate();

        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
          
            Point ptCurrent = new Point(e.X, e.Y);
           
            // If we "have the mouse", then we draw our lines.
            if (bHaveMouse)
            {
               
                // If we have drawn previously, draw again in
                // that spot to remove the lines.
                if (ptLast.X != -1)
                {
                    MyDrawReversibleRectangle(ptOriginal, ptLast);
                }
               
                // Update last point.
                ptLast = ptCurrent;
               
                // Draw new lines.
                MyDrawReversibleRectangle(ptOriginal, ptCurrent);
            }

        }

        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {

            bool nodeChanged = false;

            // Is there a node here?
            foreach(Node node in nodes)
            {
                if (node.Rectangle.Contains(panel1.PointToClient(e.Location)))
                {
                    node.Selected = true;
                    nodeChanged = true;
                    break;
                }
            }  

            if(nodeChanged == true)
            {
                panel1.Invalidate();
            }

        }

        private void internetGatewayToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void internetGatewayToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            if (mdiForm.GetCloudAccount().ReadOnlyMode == true)
            {
                attachToVPCToolStripMenuItem.Enabled = false;
                detachFromVPCToolStripMenuItem.Enabled = false;
            } 
            else
            {
                if (this.internetGateway != null)
                {
                    // We have an internet gateway node so enable/disable the menus.
                    attachToVPCToolStripMenuItem.Enabled = false;
                    detachFromVPCToolStripMenuItem.Enabled = true;
                }
                else
                {
                    // No internet gateway.
                    attachToVPCToolStripMenuItem.Enabled = true;
                    detachFromVPCToolStripMenuItem.Enabled = false;                    
                }

            }

        }

        private void createImageToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Implement this.

            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)selectedNodes[0].Tag;
            CreateImageForm cif = new CreateImageForm(mdiForm, instance);
            cif.ShowDialog();

        }

        private void connectToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void RegisterInstancesWithELBToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            // TODO: Implement this.

        }

        private void InstancesContextMenuStrip_Opening(object sender, CancelEventArgs e)
        {
            // Get selected instance(s).

            // Puts the selected instances into selectedNodes.
            GetSelectedInstances();

            CopyInstanceToolStripMenuItem.Enabled = false;

            if (mdiForm.GetCloudAccount().ReadOnlyMode == true)
            {

                launchNewInstanceToolStripMenuItem.Enabled = false;
                startInstanceToolStripMenuItem.Enabled = false;
                stopInstanceToolStripMenuItem.Enabled = false;
                terminateInstanceToolStripMenuItem.Enabled = false;
                createImageToolStripMenuItem.Enabled = false;

                if(selectedNodes.Count == 1)
                {

                    Node node = selectedNodes[0];
                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                    foreach (ToolStripMenuItem tsmi in InstanceSecurityGroupsToolStripMenuItem.DropDownItems)
                    {
                        tsmi.Enabled = false;
                    }

                    if (string.IsNullOrEmpty(instance.PublicIpAddress) == true)
                    {

                        ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                        ConnectSSHToolStripMenuItem.Enabled = false;

                    }
                    else
                    {

                        // Only enable RDP if it is a Windows instance.
                        if (instance.Platform == Amazon.EC2.PlatformValues.Windows)
                        {
                            ConnectRemoteDesktopToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                        }

                        ConnectSSHToolStripMenuItem.Enabled = true;

                    }
                }
                else
                {
                    ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                    ConnectSSHToolStripMenuItem.Enabled = false;
                }

            }
            else
            {

                if (selectedNodes.Count > 1)
                {
                    ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                    ConnectSSHToolStripMenuItem.Enabled = false;
                }
                else if (selectedNodes.Count == 0)
                {
                    // Disable everything.
                    ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                    ConnectSSHToolStripMenuItem.Enabled = false;
                }
                else if (selectedNodes.Count == 1)
                {

                    Node node = selectedNodes[0];

                    Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;

                    CopyInstanceToolStripMenuItem.Enabled = true;

                    bool terminationProtection = mdiForm.GetAWSServices().IsTerminationProtectionEnabled(instance.InstanceId);
                    EnableTerminationProtectionToolStripMenuItem.Enabled = !terminationProtection;
                    DisableTerminationProtectionToolStripMenuItem.Enabled = terminationProtection;
                    terminateInstanceToolStripMenuItem.Enabled = !terminationProtection;

                    // Get the security groups for this instance.
                    foreach(GroupIdentifier gi in instance.SecurityGroups)
                    {
                        foreach(ToolStripMenuItem tsmi in InstanceSecurityGroupsToolStripMenuItem.DropDownItems)
                        {
                            tsmi.Enabled = true;
                            SecurityGroup sg = (SecurityGroup)tsmi.Tag;
                            if (sg.GroupId == gi.GroupId)
                            {
                                tsmi.Checked = true;
                            }
                            else
                            {
                                tsmi.Checked = false;
                            }
                        }
                    }

                    if (string.IsNullOrEmpty(instance.PublicIpAddress) == true)
                    {

                        ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                        ConnectSSHToolStripMenuItem.Enabled = false;

                    }
                    else
                    {

                        // Only enable RDP if it is a Windows instance.
                        if (instance.Platform == Amazon.EC2.PlatformValues.Windows)
                        {
                            ConnectRemoteDesktopToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            ConnectRemoteDesktopToolStripMenuItem.Enabled = false;
                        }

                        ConnectSSHToolStripMenuItem.Enabled = true;

                    }

                }

            }
        }

        private void ViewRDSInstancesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //RuntimeIntelligenceUtils.TrackEvent(//RuntimeIntelligenceUtils.CATEGORY_BUTTON_CLICK, Form.ActiveForm.Name + "." + ((ToolStripMenuItem)sender).Name);

            ViewRDSInstancesToolStripMenuItem.Checked = !ViewRDSInstancesToolStripMenuItem.Checked;
            filterRdsInstances = !ViewRDSInstancesToolStripMenuItem.Checked;
            panel1.Invalidate();
        }

        private void customFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void EnableTerminationProtectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node node = selectedNodes[0];
            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;
            GenericActionResponse response = mdiForm.GetAWSServices().ModifyTerminationProtection(instance.InstanceId, true);

            if(response.Success == true)
            {
                EnableTerminationProtectionToolStripMenuItem.Enabled = false;
                DisableTerminationProtectionToolStripMenuItem.Enabled = true;
                MessageBox.Show("Termination protection enabled for instance " + instance.InstanceId + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to change termination protection.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DisableTerminationProtectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node node = selectedNodes[0];
            Amazon.EC2.Model.Instance instance = (Amazon.EC2.Model.Instance)node.Tag;
            GenericActionResponse response = mdiForm.GetAWSServices().ModifyTerminationProtection(instance.InstanceId, false);

            if (response.Success == true)
            {
                EnableTerminationProtectionToolStripMenuItem.Enabled = true;
                DisableTerminationProtectionToolStripMenuItem.Enabled = false;
                MessageBox.Show("Termination protection disabled for instance " + instance.InstanceId + ".", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Unable to change termination protection.", Application.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }

}
