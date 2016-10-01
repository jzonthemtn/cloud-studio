using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;
using CloudStudio.Services.Utilities;
using CloudStudio.Services.Utilities.Caching;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using log4net;
using CloudStudio.Services.Exceptions;
using System.Reflection;
using Amazon.AutoScaling;
using Amazon.AutoScaling.Model;
using Amazon.RDS;
using Amazon.RDS.Model;

namespace CloudStudio.Services.Services {
    
    public class AwsService : ICloudService {

        private static readonly ILog log = LogManager.GetLogger(typeof(AwsService));

        private const string USER_AGENT = "Cloud Studio";

        private AmazonEC2Client ec2;
        private AmazonAutoScalingClient autoScaling;
        private AmazonElasticLoadBalancingClient elb;
        private AmazonRDSClient rds;

        private CloudAccount cloudAccount;    

        public string GetRegion() {

            return cloudAccount.Region;

        }

        public AwsService(CloudAccount cloudAccount, CloudServiceConfig cloudServiceConfig) {

            RegionEndpoint endpoint = Amazon.RegionEndpoint.GetBySystemName(cloudAccount.Region);

            // Config documentation: http://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TAWSSupport_AWSSupportConfig_NET4_5.html

            // Configure the EC2 client.
            AmazonEC2Config config = new AmazonEC2Config();
            config.RegionEndpoint = endpoint;
            config.Timeout = new TimeSpan(0, cloudServiceConfig.Timeout, 0);
            config.UserAgent = USER_AGENT;

            if (cloudServiceConfig.UseProxy == true) {

                config.ProxyHost = cloudServiceConfig.ProxyHost;
                config.ProxyPort = cloudServiceConfig.ProxyPort;
                config.ProxyCredentials = new NetworkCredential(cloudServiceConfig.ProxyUserName, EncryptionUtils.DecryptStringAES(cloudServiceConfig.ProxyPassword));

            }

            // Configure the ELB client.

            AmazonElasticLoadBalancingConfig config2 = new AmazonElasticLoadBalancingConfig();
            config2.RegionEndpoint = endpoint;
            config2.Timeout = new TimeSpan(0, cloudServiceConfig.Timeout, 0);
            config2.UserAgent = USER_AGENT;

            if (cloudServiceConfig.UseProxy == true) {

                config2.ProxyHost = cloudServiceConfig.ProxyHost;
                config2.ProxyPort = cloudServiceConfig.ProxyPort;
                config2.ProxyCredentials = new NetworkCredential(cloudServiceConfig.ProxyUserName, EncryptionUtils.DecryptStringAES(cloudServiceConfig.ProxyPassword));
                
            }

            // Configure the autoscaling client.

            AmazonAutoScalingConfig config3 = new AmazonAutoScalingConfig();
            config3.RegionEndpoint = endpoint;
            config3.Timeout = new TimeSpan(0, cloudServiceConfig.Timeout, 0);
            config3.UserAgent = USER_AGENT;

            if (cloudServiceConfig.UseProxy == true)
            {

                config3.ProxyHost = cloudServiceConfig.ProxyHost;
                config3.ProxyPort = cloudServiceConfig.ProxyPort;
                config3.ProxyCredentials = new NetworkCredential(cloudServiceConfig.ProxyUserName, EncryptionUtils.DecryptStringAES(cloudServiceConfig.ProxyPassword));

            }

            // Configure the RDS client.

            AmazonRDSConfig config4 = new AmazonRDSConfig();
            config4.RegionEndpoint = endpoint;
            config4.Timeout = new TimeSpan(0, cloudServiceConfig.Timeout, 0);
            config4.UserAgent = USER_AGENT;

            if (cloudServiceConfig.UseProxy == true)
            {

                config4.ProxyHost = cloudServiceConfig.ProxyHost;
                config4.ProxyPort = cloudServiceConfig.ProxyPort;
                config4.ProxyCredentials = new NetworkCredential(cloudServiceConfig.ProxyUserName, EncryptionUtils.DecryptStringAES(cloudServiceConfig.ProxyPassword));

            }

            // Create the clients.

            this.ec2 = new AmazonEC2Client(new BasicAWSCredentials(cloudAccount.AccessKey, cloudAccount.SecretKey), config);
            this.elb = new AmazonElasticLoadBalancingClient(new BasicAWSCredentials(cloudAccount.AccessKey, cloudAccount.SecretKey), config2);
            this.autoScaling = new AmazonAutoScalingClient(new BasicAWSCredentials(cloudAccount.AccessKey, cloudAccount.SecretKey), config3);
            this.rds = new AmazonRDSClient(new BasicAWSCredentials(cloudAccount.AccessKey, cloudAccount.SecretKey), config4);
           
            this.cloudAccount = cloudAccount;            

        }

        public GenericActionResponse ModifyTerminationProtection(string instanceId, bool terminationProtectionEnabled)
        {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            ModifyInstanceAttributeRequest request = new ModifyInstanceAttributeRequest();
            request.InstanceId = instanceId;
            request.DisableApiTermination = terminationProtectionEnabled;

            ModifyInstanceAttributeResponse result = ec2.ModifyInstanceAttribute(request);

            if(result.HttpStatusCode == HttpStatusCode.OK)
            {

            }
            else
            {
                response.Success = false;
            }
            
            return response;

        }

        public bool IsTerminationProtectionEnabled(string instanceId)
        {
            DescribeInstanceAttributeRequest request = new DescribeInstanceAttributeRequest();
            request.Attribute = "disableApiTermination";
            request.InstanceId = instanceId;

            DescribeInstanceAttributeResponse response = ec2.DescribeInstanceAttribute(request);

            bool terminationProtection = false;

            if(response.HttpStatusCode == HttpStatusCode.OK)
            {
               terminationProtection = response.InstanceAttribute.DisableApiTermination;
            }

            return terminationProtection;

        }

        public GetRDSInstancesResponse GetRDSInstances()
        {

            GetRDSInstancesResponse response = new GetRDSInstancesResponse();

            DescribeDBInstancesResult result = rds.DescribeDBInstances();

            if (result.HttpStatusCode != HttpStatusCode.OK)
            {
                response.CreateEventError("Error", "Unable to get RDS instances.");
            }
            else
            {
                response.DBInstances = result.DBInstances;
            }

            return response;

        }

        public IDictionary<string, string> DescribeTagKeys()
        {

            IDictionary<string, string> tags = new Dictionary<string, string>();

            Amazon.EC2.Model.DescribeTagsRequest request = new Amazon.EC2.Model.DescribeTagsRequest();
            Amazon.EC2.Model.DescribeTagsResponse response = ec2.DescribeTags(request);
            
            foreach(Amazon.EC2.Model.TagDescription tag in response.Tags)
            {
                // TODO: Check resource type.
                if (!tags.ContainsKey(tag.Key))
                {
                    tags.Add(tag.Key, tag.Value);
                }
            }

            return tags;

        }

        public GenericActionResponse CreateImage(string instanceId, string name, string description)
        {
            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            CreateImageRequest request = new CreateImageRequest();
            request.InstanceId = instanceId;
            request.Name = name;
            request.Description = description;

            GenericActionResponse response = null;

            CreateImageResponse result = ec2.CreateImage(request);

            if (result.HttpStatusCode != HttpStatusCode.OK)
            {
                response.CreateEventError("Error", "Unable to create image from instance " + instanceId + ".");
            }

            return response;
        }

        public GetAutoScalingGroupInstancesResponse GetAutoScalingGroups()
        {

            GetAutoScalingGroupInstancesResponse response = new GetAutoScalingGroupInstancesResponse();

            IDictionary<string, string> instances = new Dictionary<string, string>();

            DescribeAutoScalingInstancesResponse describeAutoScalingInstancesResponse = autoScaling.DescribeAutoScalingInstances();
            foreach (AutoScalingInstanceDetails detail in describeAutoScalingInstancesResponse.AutoScalingInstances)
            {

                KeyValuePair<string, string> kvp = new KeyValuePair<string, string>(detail.InstanceId, detail.AutoScalingGroupName);

                instances.Add(kvp);

            }

            response.Instances = instances;

            return response;

        }

        public GenericActionResponse CopySnapshot(Snapshot snapshot, string description, string sourceRegion, string destinationRegion) {

            if(cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            CopySnapshotRequest request = new CopySnapshotRequest();
            request.Description = description;
            request.SourceSnapshotId = snapshot.SnapshotId;
            request.SourceRegion = sourceRegion;
            request.DestinationRegion = destinationRegion;

            CopySnapshotResult result = ec2.CopySnapshot(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to copy snapshot.");
            }

            return response;

        }

        public GenericActionResponse RegisterImage(ArchitectureValues arch, List<Amazon.EC2.Model.BlockDeviceMapping> blockDeviceMapping, string snapshotId, string description, string imageLocation, string kernelId, string name, string ramdiskId, string rootDeviceName, string sriovNetSupport, VirtualizationType type) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();
        
            RegisterImageRequest request = new RegisterImageRequest();
            request.Architecture = arch;
            request.BlockDeviceMappings = blockDeviceMapping;
            request.Description = description;
            request.ImageLocation = imageLocation;
            request.KernelId = kernelId;
            request.Name = name;
            request.RamdiskId = ramdiskId;
            request.RootDeviceName = rootDeviceName;
            request.SriovNetSupport = sriovNetSupport;
            request.VirtualizationType = type;
            
            RegisterImageResult result = ec2.RegisterImage(request);

            if(result.HttpStatusCode != HttpStatusCode.OK) {           
                response.CreateEventError("Error", "Unable to create image.");
            }

            return response;

        }

        public GenericActionResponse AddRules(string groupId, List<IpPermission> ipPermissions) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            // http://docs.aws.amazon.com/AWSSdkDocsNET/latest/DeveloperGuide/authorize-ingress.html

            AuthorizeSecurityGroupIngressRequest request = new AuthorizeSecurityGroupIngressRequest();
            request.GroupId = groupId;
            request.IpPermissions = ipPermissions;

            AuthorizeSecurityGroupIngressResponse result = ec2.AuthorizeSecurityGroupIngress(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to add rule.");
            }

            return response;

        }

        public GenericActionResponse DeleteRules(string groupId, List<IpPermission> ipPermissions) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            RevokeSecurityGroupIngressRequest request = new RevokeSecurityGroupIngressRequest();
            request.GroupId = groupId;
            request.IpPermissions = ipPermissions;

            RevokeSecurityGroupIngressResponse result =  ec2.RevokeSecurityGroupIngress(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to delete rule for group " + groupId + ".");
            }

            return response;

        }

        public GenericActionResponse CreateTag(String resource, Amazon.EC2.Model.Tag tag) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            CreateTagsRequest request = new CreateTagsRequest();
            request.Tags = new List<Amazon.EC2.Model.Tag>{ tag };
            request.Resources = new List<string> { resource };

            CreateTagsResponse result = ec2.CreateTags(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to create tag " + tag.Key + " on " + resource + ".");
            }

            return response;

        }

        public GenericActionResponse DeleteTag(String resource, Amazon.EC2.Model.Tag tag) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            Amazon.EC2.Model.DeleteTagsRequest request = new Amazon.EC2.Model.DeleteTagsRequest();
            request.Tags = new List<Amazon.EC2.Model.Tag> { tag };
            request.Resources = new List<string> { resource };

            Amazon.EC2.Model.DeleteTagsResponse result = ec2.DeleteTags(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to delete tag " + tag.Key + " from " + resource + ".");
            }

            return response;

        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse DetachVolume(Volume volume, VolumeAttachment attachment, string instanceId, bool forceDetach) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse();

            DetachVolumeRequest request = new DetachVolumeRequest();
            request.InstanceId = instanceId;
            request.VolumeId = volume.VolumeId;
            request.Device = attachment.Device;
            request.Force = forceDetach;

            DetachVolumeResult result = ec2.DetachVolume(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to detach volume " + volume.VolumeId + ".");
            }
            
            return response;

        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse DeleteSnapshot(Snapshot snapshot) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse();

            DeleteSnapshotRequest request = new DeleteSnapshotRequest();
            request.SnapshotId = snapshot.SnapshotId;

            Amazon.EC2.Model.DeleteSnapshotResponse result = ec2.DeleteSnapshot(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to delete snapshot " + snapshot.SnapshotId + ".");
            }

            return response;

        }

        public GenericActionResponse DeleteKeypair(string keyname)
        {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse response = new GenericActionResponse();

            DeleteKeyPairRequest request = new DeleteKeyPairRequest();
            request.KeyName = keyname;

            DeleteKeyPairResponse result = ec2.DeleteKeyPair(request);

            if (result.HttpStatusCode != HttpStatusCode.OK)
            {
                response.CreateEventError("Error", "Unable to delete keypair " + keyname + ".");
            }

            return response;

        }

        public RegisterInstanceWithELBResponse RegisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            RegisterInstanceWithELBResponse response = new RegisterInstanceWithELBResponse();

            List<Amazon.ElasticLoadBalancing.Model.Instance> instances = new List<Amazon.ElasticLoadBalancing.Model.Instance>();

            foreach (string instanceId in instanceIds) {

                Amazon.ElasticLoadBalancing.Model.Instance i = new Amazon.ElasticLoadBalancing.Model.Instance();
                i.InstanceId = instanceId;

                instances.Add(i);

            }

            RegisterInstancesWithLoadBalancerRequest request = new RegisterInstancesWithLoadBalancerRequest();
            request.LoadBalancerName = loadBalancer.LoadBalancerName;
            request.Instances = instances;

            RegisterInstancesWithLoadBalancerResult result = elb.RegisterInstancesWithLoadBalancer(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {

                response.CreateEventError("Error", "Unable to register instances with Elastic Load Balancer.");

            }

            return response;

        }

        public DeregisterInstanceWithELBResponse DeregisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            DeregisterInstanceWithELBResponse response = new DeregisterInstanceWithELBResponse();

            // TODO: Implement this.

            return response;

        }

        public LaunchSpotRequestInstancesResponse LaunchSpotInstances(String spotPrice, String ami, String instanceType, int instanceCount, IList<string> securityGroupNames, string subnetId, string keyName, string userData) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            LaunchSpotRequestInstancesResponse response = new LaunchSpotRequestInstancesResponse();

            RequestSpotInstancesRequest requestRequest = new RequestSpotInstancesRequest();

            requestRequest.SpotPrice = spotPrice;
            requestRequest.InstanceCount = instanceCount;
            
            LaunchSpecification launchSpecification = new LaunchSpecification();
            launchSpecification.ImageId = ami;
            launchSpecification.InstanceType = instanceType;
            launchSpecification.SubnetId = subnetId;
            launchSpecification.KeyName = keyName;
            launchSpecification.UserData = userData;
            
            foreach (string securityGroup in securityGroupNames) {
                launchSpecification.SecurityGroups.Add(securityGroup);
            }

            requestRequest.LaunchSpecification = launchSpecification;

            RequestSpotInstancesResponse result = ec2.RequestSpotInstances(requestRequest);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to launch spot instance.");
            }

            return response;

        }

        public GetImagesResponse GetImagesForSnapshot(Amazon.EC2.Model.Snapshot snapshot) {

            GetImagesResponse response = new GetImagesResponse();

            // Image filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeImagesRequest.html

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("block-device-mapping.snapshot-id");
            filter.Values = new List<string> { snapshot.SnapshotId };

            DescribeImagesRequest request = new DescribeImagesRequest();
            request.Filters.Add(filter);

            DescribeImagesResponse result = ec2.DescribeImages(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get images for snapshot " + snapshot.SnapshotId + ".");
            } else {
                response.Images = result.Images;
            }

            return response;

        }

        public GetSnapshotsResponse GetSnapshotsForVolume(Amazon.EC2.Model.Volume volume) {

            GetSnapshotsResponse response = new GetSnapshotsResponse();

            // Snapshot filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeSnapshotsRequest.html

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("volume-id");
            filter.Values = new List<string> { volume.VolumeId };

            DescribeSnapshotsRequest request = new DescribeSnapshotsRequest();
            request.Filters.Add(filter);

            DescribeSnapshotsResponse result = ec2.DescribeSnapshots(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get snapshots for volume " + volume.VolumeId + ".");
            } else {
                response.Snapshots = result.Snapshots;
            }

            return response;

        }

        public GetSnapshotsResponse GetSnapshots(bool justMySnapshots) {

            GetSnapshotsResponse response = new GetSnapshotsResponse();

            DescribeSnapshotsRequest request = new DescribeSnapshotsRequest();

            if (justMySnapshots == true) {
                request.OwnerIds = new List<string> { "self" };
            }

            DescribeSnapshotsResponse result = ec2.DescribeSnapshots(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get snapshots.");
            } else {
                response.Snapshots = result.Snapshots;
            }

            return response;

        }

        public GetInstancesResponse GetInstances(IList<Amazon.EC2.Model.Instance> instances) {

            GetInstancesResponse getInstancesResponse = new GetInstancesResponse();

            getInstancesResponse.Instances = new List<Amazon.EC2.Model.Instance>();

            // Instance filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeInstancesRequest.html

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("instance-id");

            foreach (Amazon.EC2.Model.Instance instance in instances) {
                filter.Values.Add(instance.InstanceId);
            }

            DescribeInstancesRequest req = new DescribeInstancesRequest();
            req.Filters.Add(filter);

            DescribeInstancesResult result = ec2.DescribeInstances(req);

            if (result.HttpStatusCode != HttpStatusCode.OK) {

                getInstancesResponse.CreateEventError("Error", "Unable to get instances.");

            } else {

                IList<Reservation> reservations = result.Reservations;

                foreach (Reservation reservation in reservations) {

                    foreach (Amazon.EC2.Model.Instance instance in reservation.Instances) {

                        getInstancesResponse.Instances.Add(instance);

                    }

                }

            }

            return getInstancesResponse;

        }

        public GetVolumesResponse GetVolumesForInstance(string instanceId) {

            GetVolumesResponse response = new GetVolumesResponse();

            // Volume filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeVolumesRequest.html

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("attachment.instance-id");
            filter.Values = new List<string> { instanceId };

            DescribeVolumesRequest request = new DescribeVolumesRequest();
            request.Filters.Add(filter);

            DescribeVolumesResult result = ec2.DescribeVolumes(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get volumes for instance " + instanceId + ".");
            } else {
                response.Volumes = result.Volumes;
            }

            return response;

        }

        public GetVolumesResponse GetVolumes() {

            GetVolumesResponse response = new GetVolumesResponse();

            DescribeVolumesRequest request = new DescribeVolumesRequest();

            DescribeVolumesResult result = ec2.DescribeVolumes(request);
        
            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get volumes.");
            } else {
                response.Volumes = result.Volumes;
            }

            return response;

        }

        public GetVolumesResponse GetVolume(string volumeId) {

            GetVolumesResponse response = new GetVolumesResponse();

            // Volume filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeVolumesRequest.html

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("volume-id");
            filter.Values = new List<string> { volumeId };

            DescribeVolumesRequest request = new DescribeVolumesRequest();
            request.Filters.Add(filter);

            DescribeVolumesResult result = ec2.DescribeVolumes(request);

            if (result.HttpStatusCode != HttpStatusCode.OK) {
                response.CreateEventError("Error", "Unable to get volume " + volumeId + ".");
            } else {
                response.Volumes = result.Volumes;
            }

            return response;

        }

        public void CreateSnapshot(Volume volume, string description) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            CreateSnapshotRequest request = new CreateSnapshotRequest();
            request.Description = description;
            request.VolumeId = volume.VolumeId;

            CreateSnapshotResponse response = ec2.CreateSnapshot(request);

        }

        // Describe instances request filters:
        // http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeInstancesRequest.html

        public GetRegionsResponse GetRegions() {

            GetRegionsResponse getRegionsResponse = new GetRegionsResponse();

            DescribeRegionsRequest request = new DescribeRegionsRequest();

            DescribeRegionsResponse response = ec2.DescribeRegions(request);

            getRegionsResponse.Regions = response.Regions;

            return getRegionsResponse;

        }

        public GetImagesResponse GetImages(List<string> amis) {

            GetImagesResponse response = new GetImagesResponse();

            if (amis.Count > 0) {

                DescribeImagesRequest request = new DescribeImagesRequest();
                request.ImageIds = amis;

                try {

                    DescribeImagesResult result = ec2.DescribeImages(request);

                    response.Images = result.Images;

                } catch (Exception ex) {

                    response.CreateEventError("Error", "One or more of your favorite AMIs is invalid.");
                    response.Exception = ex;

                }

            } else {

                response.Images = new List<Image>();

                response.CreateEventError("Error", "Must provide a list of AMIs.");

            }

            return response;

        }

        public GetImagesResponse GetMyImages() {

            GetImagesResponse response = new GetImagesResponse();

            DescribeImagesRequest request = new DescribeImagesRequest();
            request.Owners = new List<string> { "self" };

            DescribeImagesResult result = ec2.DescribeImages(request);

            response.Images = result.Images;

            return response;

        }

        public static string GetNameFromTags(IList<Amazon.EC2.Model.Tag> tags) {

            foreach (Amazon.EC2.Model.Tag tag in tags) {

                if (tag.Key == "Name") {

                    return tag.Value;
                }

            }

            return "[Unnamed]";

        }

        public static GetRegionEndpointsResponse GetRegionEndpoints() {

            GetRegionEndpointsResponse getRegionEndpointsResponse = new GetRegionEndpointsResponse();

            getRegionEndpointsResponse.Endpoints = Amazon.RegionEndpoint.EnumerableAllRegions;

            return getRegionEndpointsResponse;

        }

        public GetSubnetResponse GetSubnet(string subnetId) {

            GetSubnetResponse response = new GetSubnetResponse();

            DescribeSubnetsRequest request = new DescribeSubnetsRequest();
            request.SubnetIds = new List<String> { subnetId };

            DescribeSubnetsResponse describeSubnetsResponse = ec2.DescribeSubnets(request);

            if (describeSubnetsResponse.Subnets.Count > 0) {
            
                response.Subnet = describeSubnetsResponse.Subnets[0];
            
            } else {

                response.CreateEventError("Error", "Unable to retrieve subnet " + subnetId + ".");

            }

            return response;

        }

        public GetSubnetsResponse GetSubnets(Vpc vpc) {

            GetSubnetsResponse getSubnetsResponse = new GetSubnetsResponse();

            // Route filters: http://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/PEC2DescribeRouteTablesRequest_Filters_NET4_5.html
            Amazon.EC2.Model.Filter vpcFilter = new Amazon.EC2.Model.Filter("vpc-id", new List<string> { vpc.VpcId });

            DescribeSubnetsRequest request = new DescribeSubnetsRequest();
            request.Filters.Add(vpcFilter);

            DescribeSubnetsResponse response = ec2.DescribeSubnets(request);

            getSubnetsResponse.Subnets = response.Subnets;

            return getSubnetsResponse;

        }

        public GetRouteTablesResponse GetRouteTables(Vpc vpc) {

            GetRouteTablesResponse getRouteTablesResponse = new GetRouteTablesResponse();

            // Route filters: http://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/PEC2DescribeRouteTablesRequest_Filters_NET4_5.html
            Amazon.EC2.Model.Filter vpcFilter = new Amazon.EC2.Model.Filter("vpc-id", new List<string> { vpc.VpcId });

            DescribeRouteTablesRequest request = new DescribeRouteTablesRequest();
            request.Filters.Add(vpcFilter);

            DescribeRouteTablesResponse response = ec2.DescribeRouteTables(request);

            getRouteTablesResponse.RouteTables = response.RouteTables;

            return getRouteTablesResponse;

        }

        public GetLoadBalancersResponse GetLoadBalancers() {

            GetLoadBalancersResponse getLoadBalancersResponse = new GetLoadBalancersResponse();

            DescribeLoadBalancersRequest request = new DescribeLoadBalancersRequest();

            DescribeLoadBalancersResponse response = elb.DescribeLoadBalancers(request);

            getLoadBalancersResponse.LoadBalancerDescriptions = response.LoadBalancerDescriptions;

            return getLoadBalancersResponse;

        }

        public GenericActionResponse AssociateElasticIPAddress(Amazon.EC2.Model.Instance instance, string publicIp) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            AssociateAddressRequest request = new AssociateAddressRequest();
            request.InstanceId = instance.InstanceId;
            request.PublicIp = publicIp;

            AssociateAddressResponse response = ec2.AssociateAddress(request);

            return genericActionResponse;

        }

        public GenericActionResponse AttachInternetGateway(InternetGateway gateway, Vpc vpc) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            AttachInternetGatewayRequest request = new AttachInternetGatewayRequest();
            request.InternetGatewayId = gateway.InternetGatewayId;
            request.VpcId = vpc.VpcId;
            
            AttachInternetGatewayResponse response = ec2.AttachInternetGateway(request);

            return genericActionResponse;

        }

        public GenericActionResponse DetachInternetGateway(InternetGateway gateway, Vpc vpc) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            DetachInternetGatewayRequest request = new DetachInternetGatewayRequest();
            request.InternetGatewayId = gateway.InternetGatewayId;
            request.VpcId = vpc.VpcId;

            DetachInternetGatewayResponse response = ec2.DetachInternetGateway(request);

            return genericActionResponse;

        }

        public GetInternetGatewaysResponse GetInternetGateways(Vpc vpc) {

            GetInternetGatewaysResponse getInternetGatewaysResponse = new GetInternetGatewaysResponse();

            // Filters: http://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TEC2DescribeInternetGatewaysRequest_NET4_5.html
            Amazon.EC2.Model.Filter vpcFilter = new Amazon.EC2.Model.Filter("attachment.vpc-id", new List<string> { vpc.VpcId });

            DescribeInternetGatewaysRequest request = new DescribeInternetGatewaysRequest();
            request.Filters.Add(vpcFilter);

            DescribeInternetGatewaysResponse response = ec2.DescribeInternetGateways(request);

            getInternetGatewaysResponse.InternetGateways = response.InternetGateways;
            
            return getInternetGatewaysResponse;

        }

        public GetInternetGatewaysResponse GetInternetGateways()
        {

            GetInternetGatewaysResponse getInternetGatewaysResponse = new GetInternetGatewaysResponse();

            DescribeInternetGatewaysRequest request = new DescribeInternetGatewaysRequest();

            /*if (onlyDetached == false)
            {
                // Filters: http://docs.aws.amazon.com/sdkfornet/latest/apidocs/items/TEC2DescribeInternetGatewaysRequest_NET4_5.html
                Filter vpcFilter = new Filter("attachment.state", new List<string> { "" });
                request.Filters.Add(vpcFilter);
            }*/

            DescribeInternetGatewaysResponse response = ec2.DescribeInternetGateways(request);

            getInternetGatewaysResponse.InternetGateways = response.InternetGateways;

            return getInternetGatewaysResponse;

        }

        public GenericActionResponse CreateSecurityGroup(string vpcId, string name, string description) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            CreateSecurityGroupRequest request = new CreateSecurityGroupRequest();
            request.VpcId = vpcId;
            request.GroupName = name;
            request.Description = description;

            CreateSecurityGroupResult result = ec2.CreateSecurityGroup(request);

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse DeleteSecurityGroup(string groupId) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            DeleteSecurityGroupRequest request = new DeleteSecurityGroupRequest();
            request.GroupId = groupId;

            DeleteSecurityGroupResponse result = ec2.DeleteSecurityGroup(request);

            GenericActionResponse response = new GenericActionResponse();

            if (response.HttpStatusCode != HttpStatusCode.OK) {

                response.CreateEventError("Error", "Unable to delete security group " + groupId + ".");

            }

            return response;

        }

        public GetSecurityGroupsResponse GetSecurityGroup(string vpcId, string groupId) {

            GetSecurityGroupsResponse getSecurityGroupsResponse = new GetSecurityGroupsResponse();

            // Filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeSecurityGroupsRequest.html

            Amazon.EC2.Model.Filter vpcFilter = new Amazon.EC2.Model.Filter("vpc-id");
            vpcFilter.Values = new List<string>{ vpcId };

            Amazon.EC2.Model.Filter groupFilter = new Amazon.EC2.Model.Filter("group-id");
            groupFilter.Values = new List<string> { groupId };

            DescribeSecurityGroupsRequest request = new DescribeSecurityGroupsRequest();
            request.Filters.Add(vpcFilter);
            request.Filters.Add(groupFilter);

            DescribeSecurityGroupsResponse response = ec2.DescribeSecurityGroups(request);

            getSecurityGroupsResponse.SecurityGroups = response.SecurityGroups;

            return getSecurityGroupsResponse;

        }

        public GetSecurityGroupsResponse GetSecurityGroups(string vpcId) {

            GetSecurityGroupsResponse getSecurityGroupsResponse = new GetSecurityGroupsResponse();

            // Filters: http://docs.aws.amazon.com/AWSJavaSDK/latest/javadoc/com/amazonaws/services/ec2/model/DescribeSecurityGroupsRequest.html

            Amazon.EC2.Model.Filter vpcFilter = new Amazon.EC2.Model.Filter("vpc-id");
            vpcFilter.Values = new List<string>{ vpcId };

            DescribeSecurityGroupsRequest request = new DescribeSecurityGroupsRequest();
            request.Filters.Add(vpcFilter);

            DescribeSecurityGroupsResponse response = ec2.DescribeSecurityGroups(request);

            getSecurityGroupsResponse.SecurityGroups = response.SecurityGroups;

            return getSecurityGroupsResponse;

        }

        public GetImagesResponse GetCommonImages() {

            GetImagesResponse getImagesResponse = new GetImagesResponse();

            getImagesResponse.Images = new List<Image>();

            // TODO: Where to get these? Is this function used?

            Image image = new Image();
            image.ImageId = "ami-76817c1e";
            image.Name = "Amazon Linux AMI 2014.03.2 (HVM)";
            image.Description = "";

            getImagesResponse.Images.Add(image);

            return getImagesResponse;

        }

        public GetImagesResponse GetImages() {

            GetImagesResponse getImagesResponse = new GetImagesResponse();

            DescribeImagesRequest request = new DescribeImagesRequest();

            DescribeImagesResponse result = ec2.DescribeImages();

            getImagesResponse.Images = result.Images;

            return getImagesResponse;

        }

        public CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse CreateKeyPair(string keypairName)
        {
            CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse();

            CreateKeyPairRequest request = new CreateKeyPairRequest();
            request.KeyName = keypairName;

            Amazon.EC2.Model.CreateKeyPairResponse result = ec2.CreateKeyPair(request);

            if (result.HttpStatusCode != HttpStatusCode.OK)
            {
                response.CreateEventError("Error", "Unable to create keypair.");
            }
            else
            {
                response.KeyName = keypairName;
                response.Fingerprint = result.KeyPair.KeyFingerprint;
                response.Material = result.KeyPair.KeyMaterial;
            }

            return response;

        }

        public GetKeyNamesResponse GetKeyNames() {

            GetKeyNamesResponse getKeyNamesResponse = new GetKeyNamesResponse();

            DescribeKeyPairsRequest request = new DescribeKeyPairsRequest();

            DescribeKeyPairsResult result = ec2.DescribeKeyPairs();

            // TODO: Check the HTTP response code.

            getKeyNamesResponse.KeyPairs = result.KeyPairs;

            return getKeyNamesResponse;

        }

        public GetInstanceTypesResponse GetInstanceTypes() {

            GetInstanceTypesResponse getInstanceTypesResponse = new GetInstanceTypesResponse();

            getInstanceTypesResponse.InstanceTypes = new List<string>();

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.T1Micro.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.T2Medium.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.T2Micro.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.T2Small.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M1Large.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M1Medium.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M1Small.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M1Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M22xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M24xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M2Xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M32xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M3Large.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M3Medium.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.M3Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C1Medium.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C1Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C32xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C34xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C38xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C3Large.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C3Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C42xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C44xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C48xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C4Large.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.C4Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.D22xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.D24xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.D28xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.D2Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.G22xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Hi14xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Hs18xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.I22xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.I24xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.I28xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.I2Xlarge.ToString());        
            
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.R32xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.R34xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.R38xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.R3Large.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.R3Xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Cc14xlarge.ToString());
            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Cc28xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Cg14xlarge.ToString());

            getInstanceTypesResponse.InstanceTypes.Add(InstanceType.Cr18xlarge.ToString());
            
            return getInstanceTypesResponse;

        }

        public GenericActionResponse LaunchInstance(string imageId, string instanceType, int minCount, int maxCount, string keyName, String subnetId, List<string> securityGroups) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            RunInstancesRequest request = new RunInstancesRequest() {
                ImageId = imageId,
                InstanceType = instanceType,
                MinCount = minCount,
                MaxCount = maxCount,
                KeyName = keyName,
                SubnetId = subnetId,
                SecurityGroupIds = securityGroups
            };

            AmazonEC2Client ec2 = new AmazonEC2Client(new BasicAWSCredentials(cloudAccount.AccessKey, cloudAccount.SecretKey), RegionEndpoint.USEast1);

            RunInstancesResult result = ec2.RunInstances(request);

            Console.Write("Instance launched.");

            return genericActionResponse;

        }

        public GenericActionResponse StartInstances(List<string> instanceIds) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            StartInstancesRequest request = new StartInstancesRequest();
            request.InstanceIds = instanceIds;

            StartInstancesResponse response = ec2.StartInstances(request);

            return genericActionResponse;

        }

        public GenericActionResponse StartInstance(String instanceId) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            List<string> instanceIds = new List<string>();
            instanceIds.Add(instanceId);

            StartInstances(instanceIds);

            return genericActionResponse;

        }

        public GenericActionResponse StopInstances(List<string> instanceIds) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            StopInstancesRequest request = new StopInstancesRequest();
            request.InstanceIds = instanceIds;

            StopInstancesResponse response = ec2.StopInstances(request);

            return genericActionResponse;

        }

        public GenericActionResponse StopInstance(String instanceId) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            List<string> instanceIds = new List<string>();
            instanceIds.Add(instanceId);

            StopInstances(instanceIds);

            return genericActionResponse;

        }

        public GenericActionResponse TerminateInstances(List<string> instanceIds) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            TerminateInstancesRequest request = new TerminateInstancesRequest();
            request.InstanceIds = instanceIds;

            TerminateInstancesResponse response = ec2.TerminateInstances(request);
            
            return genericActionResponse;

        }

        public GenericActionResponse TerminateInstance(String instanceId) {

            if (cloudAccount.ReadOnlyMode == true)
            {
                throw new ReadOnlyModeException("Cloud account is in read only mode.");
            }

            GenericActionResponse genericActionResponse = new GenericActionResponse();

            List<string> instanceIds = new List<string>();
            instanceIds.Add(instanceId);

            TerminateInstances(instanceIds);

            return genericActionResponse;

        }

        public GetInstancesResponse GetInstances() {

            GetInstancesResponse getInstancesResponse = new GetInstancesResponse();

            getInstancesResponse.Instances = new List<Amazon.EC2.Model.Instance>();

            DescribeInstancesRequest req = new DescribeInstancesRequest();

            DescribeInstancesResult res = ec2.DescribeInstances(req);

            IList<Reservation> reservations = res.Reservations;

            foreach (Reservation reservation in reservations) {

                foreach (Amazon.EC2.Model.Instance instance in reservation.Instances) {
                    
                    getInstancesResponse.Instances.Add(instance);
                    
                }

            }

            return getInstancesResponse;

        }

        public GetInstancesResponse GetInstances(List<string> instanceIds)
        {

            // TODO: What happens if you give it an invalid instance id?

            GetInstancesResponse getInstancesResponse = new GetInstancesResponse();

            getInstancesResponse.Instances = new List<Amazon.EC2.Model.Instance>();

            DescribeInstancesRequest req = new DescribeInstancesRequest();
            req.InstanceIds = instanceIds;

            DescribeInstancesResult res = ec2.DescribeInstances(req);

            IList<Reservation> reservations = res.Reservations;

            foreach (Reservation reservation in reservations)
            {

                foreach (Amazon.EC2.Model.Instance instance in reservation.Instances)
                {

                    getInstancesResponse.Instances.Add(instance);

                }

            }

            return getInstancesResponse;

        }

        public GetInstancesResponse GetInstancesInVpc(Vpc vpc)
        {

            GetInstancesResponse getInstanceTypesInVpcResponse = new GetInstancesResponse();

            getInstanceTypesInVpcResponse.Instances = new List<Amazon.EC2.Model.Instance>();

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("vpc-id");
            filter.Values = new List<string> { vpc.VpcId };

            DescribeInstancesRequest req = new DescribeInstancesRequest();
            req.Filters.Add(filter);

            DescribeInstancesResult res = ec2.DescribeInstances(req);

            IList<Reservation> reservations = res.Reservations;

            foreach (Reservation reservation in reservations)
            {

                foreach (Amazon.EC2.Model.Instance instance in reservation.Instances)
                {

                    getInstanceTypesInVpcResponse.Instances.Add(instance);

                }

            }

            return getInstanceTypesInVpcResponse;

        }

        public GetInstancesResponse GetInstancesInSubnet(Amazon.EC2.Model.Subnet subnet) {

            GetInstancesResponse getInstanceTypesInVpcResponse = new GetInstancesResponse();

            getInstanceTypesInVpcResponse.Instances = new List<Amazon.EC2.Model.Instance>();

            Amazon.EC2.Model.Filter filter = new Amazon.EC2.Model.Filter("subnet-id");
            filter.Values = new List<string> { subnet.SubnetId };

            DescribeInstancesRequest req = new DescribeInstancesRequest();
            req.Filters.Add(filter);

            DescribeInstancesResult res = ec2.DescribeInstances(req);

            IList<Reservation> reservations = res.Reservations;

            foreach (Reservation reservation in reservations) {

                foreach (Amazon.EC2.Model.Instance instance in reservation.Instances) {

                    getInstanceTypesInVpcResponse.Instances.Add(instance);

                }

            }

            return getInstanceTypesInVpcResponse;

        }

        public GetVpcsResponse GetVpcs() {

            GetVpcsResponse getVpcsResponse = new GetVpcsResponse();

            DescribeVpcsRequest request = new DescribeVpcsRequest();

            try {

                DescribeVpcsResponse response = ec2.DescribeVpcs();
                getVpcsResponse.HttpStatusCode = response.HttpStatusCode;

                if (response.HttpStatusCode == System.Net.HttpStatusCode.OK) {
                    
                    getVpcsResponse.Vpcs = response.Vpcs;
                    getVpcsResponse.Success = true;

                } else {

                    getVpcsResponse.Vpcs = new List<Vpc>();
                    getVpcsResponse.Success = false;                     

                }

            } catch (Exception ex) {

                getVpcsResponse.Success = false;
                log.Error("Unable to list VPCs.", ex);
            
            }

            return getVpcsResponse;

        }

    }

}