using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;
using CloudStudio.Services.Utilities.Caching;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.SharedLibrary.Domain;
using log4net;
using System.Threading;
using CloudStudio.SharedLibrary;
using Amazon.EC2.Model;

namespace CloudStudio.Services {
    
    public class MockAWSServices : ICloudService {

        private static readonly ILog log = LogManager.GetLogger(typeof(MockAWSServices));

        private Cache cache;
        private CloudAccount cloudAccount;

        public MockAWSServices(CloudAccount cloudAccount)
        {

            this.cache = DefaultCache.Instance();
            this.cloudAccount = cloudAccount;

        }

        public GetRDSInstancesResponse GetRDSInstances()
        {
            return new GetRDSInstancesResponse();
        }

        public GenericActionResponse DeleteKeypair(string keyname)
        {
            GenericActionResponse response = new GenericActionResponse();

            return response;
        }

        public CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse CreateKeyPair(string keypairName)
        {
            CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse();

            return response;

        }

        public GenericActionResponse CreateImage(string instanceId, string name, string description)
        {
            GenericActionResponse response = new GenericActionResponse();

            return response;
        }

        public GetAutoScalingGroupInstancesResponse GetAutoScalingGroups()
        {
            GetAutoScalingGroupInstancesResponse response = new GetAutoScalingGroupInstancesResponse();

            return response;
        }

        public GetInternetGatewaysResponse GetInternetGateways()
        {
            GetInternetGatewaysResponse response = new GetInternetGatewaysResponse();

            return response;
        }

        public GenericActionResponse RegisterImage(ArchitectureValues arch, List<BlockDeviceMapping> blockDeviceMapping, string snapshotId, string description, string imageLocation, string kernelId, string name, string ramdiskId, string rootDeviceName, string sriovNetSupport, VirtualizationType type)
        {
            GenericActionResponse response = new GenericActionResponse();

            return response;
        }

        public void CreateSnapshot(Volume volume, string description)
        {

        }

        public string GetRegion()
        {
            return cloudAccount.Region;
        }

        public GetInstancesResponse GetInstances(List<string> instanceIds)
        {

            GetInstancesResponse response = new GetInstancesResponse();

            return response;

        }

        public GetVolumesResponse GetVolumes() {

            GetVolumesResponse response = new GetVolumesResponse();

            return response;

        }

        public GenericActionResponse CopySnapshot(Snapshot snapshot, string description, string sourceRegion, string destinationRegion) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GetSnapshotsResponse GetSnapshots(bool justMySnapshots) {

            GetSnapshotsResponse response = new GetSnapshotsResponse();

            return response;

        }

        public GetVolumesResponse GetVolume(string volumeId) {

            GetVolumesResponse response = new GetVolumesResponse();

            return response;

        }

        public GenericActionResponse CreateSecurityGroup(string vpcId, string name, string description) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse DeleteSecurityGroup(string groupId) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GetSecurityGroupsResponse GetSecurityGroup(string vpcId, string groupId) {

            GetSecurityGroupsResponse response = new GetSecurityGroupsResponse();

            return response;

        }

        public GenericActionResponse DeleteRules(string groupId, List<IpPermission> ipPermissions) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse AddRules(string groupId, List<IpPermission> ipPermissions) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse CreateTag(String resource, Amazon.EC2.Model.Tag tag) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse DeleteTag(String resource, Amazon.EC2.Model.Tag tag) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse DetachVolume(Volume volume, VolumeAttachment attachment, string instanceId, bool forceDetach) {

            CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse();

            return response;

        }

        public LaunchSpotRequestInstancesResponse LaunchSpotInstances(String spotPrice, String ami, String instanceType, int instanceCount, IList<string> securityGroupNames, string subnetId, string keyName, string userData) {

            LaunchSpotRequestInstancesResponse response = new LaunchSpotRequestInstancesResponse();

            return response;

        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse DeleteSnapshot(Snapshot snapshot) {

            CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse response = new CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse();

            return response;

        }

        public DeregisterInstanceWithELBResponse DeregisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer)
        {

            DeregisterInstanceWithELBResponse response = new DeregisterInstanceWithELBResponse();

            return response;

        }

        public RegisterInstanceWithELBResponse RegisterInstancesWithELB(List<string> instances, LoadBalancerDescription elb)
        {

            RegisterInstanceWithELBResponse response = new RegisterInstanceWithELBResponse();

            return response;

        }

        private List<Amazon.EC2.Model.Tag> generateRandomTags()
        {

            List<Amazon.EC2.Model.Tag> tags = new List<Amazon.EC2.Model.Tag>();

            Amazon.EC2.Model.Tag t1 = new Amazon.EC2.Model.Tag();
            t1.Key = "Name";
            t1.Value = Guid.NewGuid().ToString("N").Substring(0, 10); ;

            tags.Add(t1);

            return tags;

        }

        public GetRegionsResponse GetRegions() {

            GetRegionsResponse getRegionsResponse = new GetRegionsResponse();

            IList<Region> regions = new List<Region>();
            
            Region region1 = new Region();
            region1.RegionName = "Region1";
            region1.Endpoint = "http://region1";
            regions.Add(region1);

            Region region2 = new Region();
            region2.RegionName = "Region2";
            region2.Endpoint = "http://region2";
            regions.Add(region2);

            getRegionsResponse.Regions = regions;

            return getRegionsResponse;

        }

        public GetVolumesResponse GetVolumesForInstance(string instanceId) {

            GetVolumesResponse response = new GetVolumesResponse();

            IList<Volume> volumes = new List<Volume>();

            Volume volume = new Volume();
            //volume.Attachments = 
            volume.AvailabilityZone = "us-east-1";
            volume.CreateTime = new DateTime();
            volume.Encrypted = false;
            volume.Iops = 1000;
            volume.Size = 500;
            volume.SnapshotId = "snapshot-54";
            volume.State = VolumeState.Available;
            volume.Tags = generateRandomTags();
            volume.VolumeId = "volume-23";
            volume.VolumeType = VolumeType.Standard;
              
            return response;

        }

        public GetSnapshotsResponse GetSnapshotsForVolume(Amazon.EC2.Model.Volume volume)
        {

            GetSnapshotsResponse response = new GetSnapshotsResponse();

            IList<Snapshot> snapshots = new List<Snapshot>();

            Snapshot snapshot = new Snapshot();
            snapshot.Description = "Snapshot description";
            snapshot.Encrypted = false;
            snapshot.OwnerAlias = "owner-alias";
            snapshot.OwnerId = "ownerid";
            snapshot.Progress = "100";
            snapshot.SnapshotId = "snapshot-423";
            snapshot.StartTime = new DateTime();
            snapshot.State = SnapshotState.Completed;
            snapshot.Tags = generateRandomTags();
            snapshot.VolumeId = "volume-23";
            snapshot.VolumeSize = 50;

            snapshots.Add(snapshot);

            response.Snapshots = snapshots;

            return response;

        }

        public GetImagesResponse GetImagesForSnapshot(Amazon.EC2.Model.Snapshot snapshot)
        {

            GetImagesResponse response = new GetImagesResponse();
            
            IList<Image> images = new List<Image>();

            Image image = new Image();
            image.Architecture = ArchitectureValues.X86_64;
            //image.BlockDeviceMappings = 
            image.Description = "description";
            image.Hypervisor = HypervisorType.Xen;
            image.ImageId = "image-232";
            image.ImageLocation = "location";
            image.ImageOwnerAlias = "owner-alias";
            image.ImageType = ImageTypeValues.Kernel;
            image.KernelId = "kernel-232";
            image.Name = "Image Name";
            image.OwnerId = "owner-id";
            image.Platform = PlatformValues.Windows;
            //image.ProductCodes =
            image.Public = false;
            image.RamdiskId = "ramdisk-232";
            image.RootDeviceName = "rootdevicename";
            image.RootDeviceType = DeviceType.Ebs;
            image.SriovNetSupport = "no-support";
            image.State = ImageState.Available;
            //image.StateReason = StateReason.
            image.Tags = generateRandomTags();
            image.VirtualizationType = VirtualizationType.Hvm;

            response.Images = images;

            return response;

        }

        public GetImagesResponse GetImages(List<string> amis) {

            GetImagesResponse response = new GetImagesResponse();

            IList<Image> images = new List<Image>();

            Image image = new Image();
            image.Architecture = ArchitectureValues.X86_64;
            //image.BlockDeviceMappings = 
            image.Description = "description";
            image.Hypervisor = HypervisorType.Xen;
            image.ImageId = "image-232";
            image.ImageLocation = "location";
            image.ImageOwnerAlias = "owner-alias";
            image.ImageType = ImageTypeValues.Kernel;
            image.KernelId = "kernel-232";
            image.Name = "Image Name";
            image.OwnerId = "owner-id";
            image.Platform = PlatformValues.Windows;
            //image.ProductCodes =
            image.Public = false;
            image.RamdiskId = "ramdisk-232";
            image.RootDeviceName = "rootdevicename";
            image.RootDeviceType = DeviceType.Ebs;
            image.SriovNetSupport = "no-support";
            image.State = ImageState.Available;
            //image.StateReason = StateReason.
            image.Tags = generateRandomTags();
            image.VirtualizationType = VirtualizationType.Hvm;

            response.Images = images;

            return response;

        }

        public GetImagesResponse GetMyImages() {

            GetImagesResponse response = new GetImagesResponse();

            IList<Image> images = new List<Image>();

            Image image = new Image();
            image.Architecture = ArchitectureValues.X86_64;
            //image.BlockDeviceMappings = 
            image.Description = "description";
            image.Hypervisor = HypervisorType.Xen;
            image.ImageId = "image-232";
            image.ImageLocation = "location";
            image.ImageOwnerAlias = "owner-alias";
            image.ImageType = ImageTypeValues.Kernel;
            image.KernelId = "kernel-232";
            image.Name = "Image Name";
            image.OwnerId = "owner-id";
            image.Platform = PlatformValues.Windows;
            //image.ProductCodes =
            image.Public = false;
            image.RamdiskId = "ramdisk-232";
            image.RootDeviceName = "rootdevicename";
            image.RootDeviceType = DeviceType.Ebs;
            image.SriovNetSupport = "no-support";
            image.State = ImageState.Available;
            //image.StateReason = StateReason.
            image.Tags = generateRandomTags();
            image.VirtualizationType = VirtualizationType.Hvm;

            response.Images = images;

            return response;

        }        

        public GetSubnetResponse GetSubnet(string subnetId) {

            GetSubnetResponse response = new GetSubnetResponse();

            Subnet subnet = new Subnet();
            subnet.AvailabilityZone = "us-east-1";
            subnet.AvailableIpAddressCount = 250;
            subnet.CidrBlock = "10.0.0.0/24";
            subnet.DefaultForAz = false;
            subnet.MapPublicIpOnLaunch = true;
            subnet.State = SubnetState.Available;
            subnet.SubnetId = "subnet-232";
            subnet.Tags = generateRandomTags();
            subnet.VpcId = "vpc-123";

            response.Subnet = subnet;

            return response;

        }

        public GetSubnetsResponse GetSubnets(Vpc vpc) {

            GetSubnetsResponse response = new GetSubnetsResponse();

            IList<Subnet> subnets = new List<Subnet>();

            Subnet subnet = new Subnet();
            subnet.AvailabilityZone = "us-east-1";
            subnet.AvailableIpAddressCount = 250;
            subnet.CidrBlock = "10.0.0.0/24";
            subnet.DefaultForAz = false;
            subnet.MapPublicIpOnLaunch = true;
            subnet.State = SubnetState.Available;
            subnet.SubnetId = "subnet-232";
            subnet.Tags = generateRandomTags();
            subnet.VpcId = "vpc-123";

            subnets.Add(subnet);

            response.Subnets = subnets;

            return response;

        }

        public GetRouteTablesResponse GetRouteTables(Vpc vpc) {

            GetRouteTablesResponse response = new GetRouteTablesResponse();

            IList<RouteTable> routeTables = new List<RouteTable>();

            RouteTable route = new RouteTable();
            //route.Associations = 
            //route.PropagatingVgws = 
            //route.Routes = 
            route.RouteTableId = "routetable-23";
            route.Tags = generateRandomTags();
            route.VpcId = "vpc-34";

            routeTables.Add(route);

            response.RouteTables = routeTables;

            return response;

        }

        public GetLoadBalancersResponse GetLoadBalancers() {

            GetLoadBalancersResponse response = new GetLoadBalancersResponse();

            return response;

        }

        public GenericActionResponse AssociateElasticIPAddress(Amazon.EC2.Model.Instance instance, string publicIp) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse AttachInternetGateway(InternetGateway gateway, Vpc vpc) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse DetachInternetGateway(InternetGateway gateway, Vpc vpc) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GetInternetGatewaysResponse GetInternetGateways(Vpc vpc) {

            GetInternetGatewaysResponse response = new GetInternetGatewaysResponse();

            return response;

        }

        public GetSecurityGroupsResponse GetSecurityGroups(string vpcId) {

            GetSecurityGroupsResponse response = new GetSecurityGroupsResponse();

            return response;

        }

        public GetImagesResponse GetCommonImages() {

            GetImagesResponse response = new GetImagesResponse();

            return response;

        }

        public GetImagesResponse GetImages() {

            GetImagesResponse response = new GetImagesResponse();

            return response;

        }

        public GetKeyNamesResponse GetKeyNames() {

            GetKeyNamesResponse response = new GetKeyNamesResponse();

            return response;

        }

        public GetInstanceTypesResponse GetInstanceTypes() {

            GetInstanceTypesResponse response = new GetInstanceTypesResponse();

            return response;

        }

        public GenericActionResponse LaunchInstance(string imageId, string instanceType, int minCount, int maxCount, string keyName, String subnetId, List<string> securityGroups) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse StartInstances(List<string> instanceIds) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse StartInstance(String instanceId) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse StopInstances(List<string> instanceIds) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse StopInstance(String instanceId) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse TerminateInstances(List<string> instanceIds) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GenericActionResponse TerminateInstance(String instanceId) {

            GenericActionResponse response = new GenericActionResponse();

            return response;

        }

        public GetInstancesResponse GetInstances() {

            GetInstancesResponse response = new GetInstancesResponse();

            return response;

        }

        public GetInstancesResponse GetInstances(IList<Amazon.EC2.Model.Instance> instances)
        {

            GetInstancesResponse response = new GetInstancesResponse();

            return response;

        }

        public GetInstancesResponse GetInstancesInVpc(Vpc vpc)
        {

            GetInstancesResponse response = new GetInstancesResponse();

            return response;

        }

        public GetInstancesResponse GetInstancesInSubnet(Subnet subnet)
        {

            GetInstancesResponse response = new GetInstancesResponse();

            return response;

        }

        public GetVpcsResponse GetVpcs() {

            GetVpcsResponse response = new GetVpcsResponse();

            return response;

        }

    }

}