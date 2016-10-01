using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing;
using Amazon.ElasticLoadBalancing.Model;
using Amazon.Runtime;
using CloudStudio.SharedLibrary.Services.AWSServices;
using CloudStudio.SharedLibrary.Domain;
using log4net;
using System.Threading;

namespace CloudStudio.SharedLibrary
{
    
    /// <summary>
    /// Interface for cloud services.
    /// </summary>
    public interface ICloudService {

        // Operations that make changes.

        GenericActionResponse ModifyTerminationProtection(string instanceId, bool terminationProtectionEnabled);
        GenericActionResponse DeleteKeypair(string keyname);
        CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse CreateKeyPair(string keypairName);
        GenericActionResponse CreateImage(string instanceId, string name, string description);
        GenericActionResponse CopySnapshot(Snapshot snapshot, string description, string sourceRegion, string destinationRegion);
        void CreateSnapshot(Volume volume, string description);
        GenericActionResponse CreateSecurityGroup(string vpcId, string name, string description);
        GenericActionResponse DeleteSecurityGroup(string groupId);
        GenericActionResponse AddRules(string groupId, List<IpPermission> ipPermissions);
        GenericActionResponse DeleteRules(string groupId, List<IpPermission> ipPermissions);
        GenericActionResponse CreateTag(String resource, Amazon.EC2.Model.Tag tag);
        GenericActionResponse DeleteTag(String resource, Amazon.EC2.Model.Tag tag);
        CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse DetachVolume(Volume volume, VolumeAttachment attachment, string instanceId, bool forceDetach);
        LaunchSpotRequestInstancesResponse LaunchSpotInstances(String spotPrice, String ami, String instanceType, int instanceCount, IList<string> securityGroupNames, string subnetId, string keyName, string userData);
        CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse DeleteSnapshot(Snapshot snapshot);
        DeregisterInstanceWithELBResponse DeregisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer);
        RegisterInstanceWithELBResponse RegisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer);
        GenericActionResponse AssociateElasticIPAddress(Amazon.EC2.Model.Instance instance, string publicIp);
        GenericActionResponse AttachInternetGateway(InternetGateway gateway, Vpc vpc);
        GenericActionResponse DetachInternetGateway(InternetGateway gateway, Vpc vpc);
        GenericActionResponse LaunchInstance(string imageId, string instanceType, int minCount, int maxCount, string keyName, String subnetId, List<string> securityGroups);
        GenericActionResponse StartInstances(List<string> instanceIds);
        GenericActionResponse StartInstance(String instanceId);
        GenericActionResponse StopInstances(List<string> instanceIds);
        GenericActionResponse StopInstance(String instanceId);
        GenericActionResponse TerminateInstances(List<string> instanceIds);
        GenericActionResponse TerminateInstance(String instanceId);
        GenericActionResponse RegisterImage(ArchitectureValues arch, List<BlockDeviceMapping> blockDeviceMapping, string snapshotId, string description, string imageLocation, string kernelId, string name, string ramdiskId, string rootDeviceName, string sriovNetSupport, VirtualizationType type);

        // Read-only operations.

        bool IsTerminationProtectionEnabled(string instanceId);
        IDictionary<string, string> DescribeTagKeys();
        GetRDSInstancesResponse GetRDSInstances();
        GetAutoScalingGroupInstancesResponse GetAutoScalingGroups();
        GetInternetGatewaysResponse GetInternetGateways();
        GetVolumesResponse GetVolumes();        
        GetSnapshotsResponse GetSnapshots(bool justMySnapshots);        
        GetRegionsResponse GetRegions();
        GetVolumesResponse GetVolumesForInstance(string instanceId);
        GetVolumesResponse GetVolume(string volumeId);
        GetSnapshotsResponse GetSnapshotsForVolume(Amazon.EC2.Model.Volume volume);
        GetImagesResponse GetImagesForSnapshot(Amazon.EC2.Model.Snapshot snapshot);
        GetImagesResponse GetImages(List<string> amis);
        GetImagesResponse GetMyImages();
        GetSubnetResponse GetSubnet(string subnetId);
        GetSubnetsResponse GetSubnets(Vpc vpc);
        GetRouteTablesResponse GetRouteTables(Vpc vpc);
        GetLoadBalancersResponse GetLoadBalancers();        
        GetInternetGatewaysResponse GetInternetGateways(Vpc vpc);
        GetSecurityGroupsResponse GetSecurityGroups(string vpdId);
        GetSecurityGroupsResponse GetSecurityGroup(string vpcId, string groupId);
        GetImagesResponse GetCommonImages();
        GetImagesResponse GetImages();
        GetKeyNamesResponse GetKeyNames();
        GetInstanceTypesResponse GetInstanceTypes();        
        GetInstancesResponse GetInstances();
        GetInstancesResponse GetInstances(List<string> instanceIds);
        GetInstancesResponse GetInstances(IList<Amazon.EC2.Model.Instance> instances);
        GetInstancesResponse GetInstancesInSubnet(Subnet subnet);
        GetInstancesResponse GetInstancesInVpc(Vpc vpc);
        GetVpcsResponse GetVpcs();
        string GetRegion();

    }

}