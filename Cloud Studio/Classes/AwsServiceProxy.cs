using Amazon.EC2;
using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing.Model;
using CloudStudio.Services.Services;
using CloudStudio.Services.Utilities.Caching;
using CloudStudio.SharedLibrary;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CloudStudio.GUI.Classes
{
    public class AwsServiceProxy : ICloudService
    {

        private MainMDIForm mdiForm;
        private ICloudService awsServices;
        private Cache cache;

        public AwsServiceProxy(MainMDIForm mdiForm, CloudAccount cloudAccount, CloudServiceConfig cloudServiceConfig)
        {
            this.mdiForm = mdiForm;
            this.awsServices = new AwsService(cloudAccount, cloudServiceConfig);
            cache = DefaultCache.Instance();
        }

        private void LogMessage(string message)
        {
            //toolStripStatusLabel.Text = message;
            mdiForm.LogOutputMessage(message);
        }

        public IDictionary<string, string> DescribeTagKeys()
        {
            return awsServices.DescribeTagKeys();
        }

        public GenericActionResponse ModifyTerminationProtection(string instanceId, bool terminationProtectionEnabled)
        {
            return awsServices.ModifyTerminationProtection(instanceId, terminationProtectionEnabled);
        }

        public bool IsTerminationProtectionEnabled(string instanceId)
        {
            return awsServices.IsTerminationProtectionEnabled(instanceId);
        }

        public GenericActionResponse CreateImage(string instanceId, string name, string description)
        {
            LogMessage("Creating image of instance " + instanceId + "...");
            GenericActionResponse response = awsServices.CreateImage(instanceId, name, description);
            if (response.Success == true)
            {
                LogMessage("Image created.");
            }
            else
            {
                LogMessage("Unable to create image of instance " + instanceId + ".");
            }
            return response;
        }

        public GetRDSInstancesResponse GetRDSInstances()
        {
            LogMessage("Getting RDS instances...");
            GetRDSInstancesResponse response = awsServices.GetRDSInstances();
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.DBInstances.Count + " RDS instances.");
            }
            else
            {
                LogMessage("Unable to get RDS instances.");
            }
            return response;
        }

        public GenericActionResponse DeleteKeypair(string keypair)
        {
            LogMessage("Deleting keypair " + keypair + "...");
            GenericActionResponse response = awsServices.DeleteKeypair(keypair);
            if (response.Success == true)
            {
                LogMessage("Keypair deleted.");
            }
            else
            {
                LogMessage("Unable to delete keypair.");
            }
            return response;
        }

        public CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse CreateKeyPair(string keypairName)
        {
            LogMessage("Creating new keypair " + keypairName + "...");
            CloudStudio.SharedLibrary.Services.AWSServices.CreateKeyPairResponse response = awsServices.CreateKeyPair(keypairName);
            if (response.Success == true)
            {
                LogMessage("Keypair created.");
            }
            else
            {
                LogMessage("Unable to create keypair.");
            }
            return response;
        }

        public string GetRegion()
        {
            return awsServices.GetRegion();
        }

        public GetAutoScalingGroupInstancesResponse GetAutoScalingGroups()
        {
            LogMessage("Getting autoscaling groups...");
            GetAutoScalingGroupInstancesResponse response = awsServices.GetAutoScalingGroups();
            if (response.Success == true)
            {
                LogMessage("Retrieved autoscaling groups.");
            }
            else
            {
                LogMessage("Unable to retrieve autoscaling groups.");
            }
            return response;
        }

        public GenericActionResponse RegisterImage(ArchitectureValues arch, List<BlockDeviceMapping> blockDeviceMapping, string snapshotId, string description, string imageLocation, string kernelId, string name, string ramdiskId, string rootDeviceName, string sriovNetSupport, VirtualizationType type)
        {
            LogMessage("Creating image...");
            GenericActionResponse response = awsServices.RegisterImage(arch, blockDeviceMapping, snapshotId, description, imageLocation, kernelId, name, ramdiskId, rootDeviceName, sriovNetSupport, type);
            if (response.Success == true)
            {
                LogMessage("Image registered");
            }
            else
            {
                LogMessage("Unable to create image.");
            }
            return response;
        }

        public GetInternetGatewaysResponse GetInternetGateways()
        {
            LogMessage("Getting internet gateways...");
            GetInternetGatewaysResponse response = awsServices.GetInternetGateways();
            if(response.Success == true)
            {
                LogMessage("Retrieved " + response.InternetGateways.Count + " internet gateways.");
            }
            else
            {
                LogMessage("Unable to retrieve internet gateways.");
            }
            return response;
        }

        public void CreateSnapshot(Volume volume, string description)
        {
            LogMessage("Creating snapshot...");
            awsServices.CreateSnapshot(volume, description);
            LogMessage("Snapshot creation started.");
        }

        public GetInstancesResponse GetInstances(List<string> instanceIds)
        {
            LogMessage("Getting instances...");
            GetInstancesResponse response = awsServices.GetInstances(instanceIds);
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Instances.Count + " instances.");
            }
            else
            {
                LogMessage("Unable to retrieve instances.");
            }
            return response;
        }

        public GetVolumesResponse GetVolumes()
        {
            LogMessage("Getting volumes...");
            GetVolumesResponse response = awsServices.GetVolumes();
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Volumes.Count + " volumes.");
            }
            else
            {
                LogMessage("Unable to retrieve volumes.");
            }
            return response;
        }

        public GenericActionResponse CopySnapshot(Snapshot snapshot, string description, string sourceRegion, string destinationRegion)
        {
            LogMessage("Copying snapshot...");
            GenericActionResponse response = awsServices.CopySnapshot(snapshot, description, sourceRegion, destinationRegion);
            if (response.Success == true)
            {
                LogMessage("Snapshot copy was started.");
            }
            else
            {
                LogMessage("Unable to copy the snapshot.");
            }
            return response;
        }

        public GetSnapshotsResponse GetSnapshots(bool justMySnapshots)
        {
            LogMessage("Getting snapshots...");
            GetSnapshotsResponse response = awsServices.GetSnapshots(justMySnapshots);
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Snapshots.Count + " snapshots.");
            }
            else
            {
                LogMessage("Unable to retrieve snapshots.");
            }
            return response;
        }

        public GetVolumesResponse GetVolume(string volumeId)
        {
            LogMessage("Getting volume " + volumeId + "...");
            GetVolumesResponse response = awsServices.GetVolume(volumeId);
            if (response.Success == true)
            {
                LogMessage("Retrieved the volume.");
            }
            else
            {
                LogMessage("Unable to retrieve volume " + volumeId + ".");
            }
            return response;
        }

        public GenericActionResponse CreateSecurityGroup(string vpcId, string name, string description)
        {
            LogMessage("Creating security group " + name + "...");
            GenericActionResponse response = awsServices.CreateSecurityGroup(vpcId, name, description);
            if (response.Success == true)
            {
                LogMessage("Security group " + name + " created.");
            }
            else
            {
                LogMessage("Unable to create security group.");
            }
            return response;
        }

        public GenericActionResponse DeleteSecurityGroup(string groupId)
        {
            LogMessage("Deleting security group " + groupId + "...");
            GenericActionResponse response = awsServices.DeleteSecurityGroup(groupId);
            if (response.Success == true)
            {
                LogMessage("Security group " + groupId + " deleted.");
            }
            else
            {
                LogMessage("Unable to deleted security group.");
            }
            return response;
        }

        public GetSecurityGroupsResponse GetSecurityGroup(string vpcId, string groupId)
        {
            LogMessage("Getting security group " + groupId + "...");
            GetSecurityGroupsResponse response = awsServices.GetSecurityGroup(vpcId, groupId);
            if (response.Success == true)
            {
                LogMessage("Retrieved security group " + groupId + ".");
            }
            else
            {
                LogMessage("Unable to retrieve security group " + groupId + ".");
            }
            return response;
        }

        public GenericActionResponse DeleteRules(string groupId, List<IpPermission> ipPermissions)
        {
            LogMessage("Deleting security group rules from group " + groupId + ".");
            GenericActionResponse response = awsServices.DeleteRules(groupId, ipPermissions);
            if (response.Success == true)
            {
                LogMessage("Deleting security group rules from " + groupId + ".");
            }
            else
            {
                LogMessage("Unable to delete rules from security group " + groupId + ".");
            }
            return response;
        }

        public GenericActionResponse AddRules(string groupId, List<IpPermission> ipPermissions)
        {
            LogMessage("Adding security group rules to " + groupId + "...");
            GenericActionResponse response = awsServices.AddRules(groupId, ipPermissions);
            if (response.Success == true)
            {
                LogMessage("Added rules to security group " + groupId + ".");
            }
            else
            {
                LogMessage("Unable to add rules to security group " + groupId + ".");
            }
            return response;
        }

        public GenericActionResponse CreateTag(String resource, Amazon.EC2.Model.Tag tag)
        {
            LogMessage("Creating tag on resource " + resource + "...");
            GenericActionResponse response = awsServices.CreateTag(resource, tag);
            if (response.Success == true)
            {
                LogMessage("Added tag.");
            }
            else
            {
                LogMessage("Unable to add tag.");
            }
            return response;
        }

        public GenericActionResponse DeleteTag(String resource, Amazon.EC2.Model.Tag tag)
        {
            LogMessage("Deleting tag from resource " + resource + "...");
            GenericActionResponse response = awsServices.DeleteTag(resource, tag);
            if (response.Success == true)
            {
                LogMessage("Added tag.");
            }
            else
            {
                LogMessage("Unable to delete tag.");
            }
            return response;
        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse DetachVolume(Volume volume, VolumeAttachment attachment, string instanceId, bool forceDetach)
        {
            LogMessage("Detaching volume...");
            CloudStudio.SharedLibrary.Services.AWSServices.DetachVolumeResponse response = awsServices.DetachVolume(volume, attachment, instanceId, forceDetach);
            if (response.Success == true)
            {
                LogMessage("Detached volume.");
            }
            else
            {
                LogMessage("Unable to detach volume.");
            }
            return response;
        }

        public LaunchSpotRequestInstancesResponse LaunchSpotInstances(String spotPrice, String ami, String instanceType, int instanceCount, IList<string> securityGroupNames, string subnetId, string keyName, string userData)
        {
            LogMessage("Launching spot instances...");
            LaunchSpotRequestInstancesResponse response = awsServices.LaunchSpotInstances(spotPrice, ami, instanceType, instanceCount, securityGroupNames, subnetId, keyName, userData);
            if (response.Success == true)
            {
                LogMessage("Spot instances launched.");
            }
            else
            {
                LogMessage("Unable to launch spot instances.");
            }
            return response;
        }

        public CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse DeleteSnapshot(Snapshot snapshot)
        {
            LogMessage("Deleting snapshot " + snapshot.SnapshotId + "...");
            CloudStudio.SharedLibrary.Services.AWSServices.DeleteSnapshotResponse response = awsServices.DeleteSnapshot(snapshot);
            if (response.Success == true)
            {
                LogMessage("Deleted snapshot " + snapshot.SnapshotId + ".");
            }
            else
            {
                LogMessage("Unable to delete snapshot.");
            }
            return response;
        }

        public DeregisterInstanceWithELBResponse DeregisterInstancesWithELB(List<string> instanceIds, LoadBalancerDescription loadBalancer)
        {
            LogMessage("Deregistering instance from ELB...");
            DeregisterInstanceWithELBResponse response = awsServices.DeregisterInstancesWithELB(instanceIds, loadBalancer);
            if (response.Success == true)
            {
                LogMessage("Deregistered instance from ELB.");
            }
            else
            {
                LogMessage("Unable to deregister instance from ELB.");
            }
            return response;
        }

        public RegisterInstanceWithELBResponse RegisterInstancesWithELB(List<string> instances, LoadBalancerDescription elb)
        {
            LogMessage("Registering instances with ELB...");
            RegisterInstanceWithELBResponse response = awsServices.RegisterInstancesWithELB(instances, elb);
            if (response.Success == true)
            {
                LogMessage("Registered instances with ELB.");
            }
            else
            {
                LogMessage("Unable to register instances with ELB.");
            }
            return response;
        }

        public GetRegionsResponse GetRegions()
        {
            LogMessage("Getting regions...");

            GetRegionsResponse response = null;

            if (cache.ContainsKey("regions") == true) {
                response = (GetRegionsResponse)cache.Get("regions");
            } else {
                response = awsServices.GetRegions();                
                cache.Add("regions", response.Regions);
            }

            if (response.Success == true)
            {
                LogMessage("Retrieved regions.");
            }
            else
            {
                LogMessage("Unable to retrieve regions.");
            }
            return response;

        }

        public GetVolumesResponse GetVolumesForInstance(string instanceId)
        {
            LogMessage("Getting volumes for instance " + instanceId + ".");
            GetVolumesResponse response = awsServices.GetVolumesForInstance(instanceId);
            if (response.Success == true)
            {
                LogMessage("Retrieved volumes.");
            }
            else
            {
                LogMessage("Unable to retrieve volumes.");
            }
            return response;
        }

        public GetSnapshotsResponse GetSnapshotsForVolume(Amazon.EC2.Model.Volume volume)
        {
            LogMessage("Getting snapshots for volume " + volume.VolumeId + ".");
            GetSnapshotsResponse response = awsServices.GetSnapshotsForVolume(volume);
            if (response.Success == true)
            {
                LogMessage("Retrieved snapshots.");
            }
            else
            {
                LogMessage("Unable to retrieve snapshots.");
            }
            return response;
        }

        public GetImagesResponse GetImagesForSnapshot(Amazon.EC2.Model.Snapshot snapshot)
        {
            LogMessage("Getting images for snapshot " + snapshot.SnapshotId + ".");
            GetImagesResponse response = awsServices.GetImagesForSnapshot(snapshot);
            if (response.Success == true)
            {
                LogMessage("Retrieved images.");
            }
            else
            {
                LogMessage("Unable to retrieve images.");
            }
            return response;
        }

        public GetImagesResponse GetImages(List<string> amis)
        {
            LogMessage("Getting images for AMIs...");
            GetImagesResponse response = awsServices.GetImages(amis);
            if (response.Success == true)
            {
                LogMessage("Retrieved images.");
            }
            else
            {
                LogMessage("Unable to retrieve images.");
            }
            return response;
        }

        public GetImagesResponse GetMyImages()
        {
            LogMessage("Getting my images...");
            GetImagesResponse response = awsServices.GetMyImages();
            if (response.Success == true)
            {
                LogMessage("Retrieved images.");
            }
            else
            {
                LogMessage("Unable to retrieve images.");
            }
            return response;
        }

        public GetSubnetResponse GetSubnet(string subnetId)
        {
            LogMessage("Getting subnet " + subnetId + ".");
            GetSubnetResponse response = awsServices.GetSubnet(subnetId);
            if (response.Success == true)
            {
                LogMessage("Retrieved subnet.");
            }
            else
            {
                LogMessage("Unable to retrieve subnet.");
            }
            return response;
        }

        public GetSubnetsResponse GetSubnets(Vpc vpc)
        {
            LogMessage("Unable to get subnets in VPC " + vpc.VpcId + ".");
            GetSubnetsResponse response = awsServices.GetSubnets(vpc);
            if (response.Success == true)
            {
                LogMessage("Retrieved subnets.");
            }
            else
            {
                LogMessage("Unable to retrieve subnets.");
            }
            return response;
        }

        public GetRouteTablesResponse GetRouteTables(Vpc vpc)
        {
            LogMessage("Getting route tables for VPC " + vpc.VpcId + ".");
            GetRouteTablesResponse response = awsServices.GetRouteTables(vpc);
            if (response.Success == true)
            {
                LogMessage("Retrieved route tables.");
            }
            else
            {
                LogMessage("Unable to retrieve route tables.");
            }
            return response;
        }

        public GetLoadBalancersResponse GetLoadBalancers()
        {
            LogMessage("Getting load balancers...");
            GetLoadBalancersResponse response = awsServices.GetLoadBalancers();
            if (response.Success == true)
            {
                LogMessage("Retrieved load balancers.");
            }
            else
            {
                LogMessage("Unable to retrieve load balancers.");
            }
            return response;
        }

        public GenericActionResponse AssociateElasticIPAddress(Amazon.EC2.Model.Instance instance, string publicIp)
        {
            LogMessage("Associating elastic IP address " + publicIp + " with instance " + instance.InstanceId + "...");
            GenericActionResponse response = awsServices.AssociateElasticIPAddress(instance, publicIp);
            if (response.Success == true)
            {
                LogMessage("Associated elastic IP address.");
            }
            else
            {
                LogMessage("Unable to associate elastic IP address.");
            }
            return response;
        }

        public GenericActionResponse AttachInternetGateway(InternetGateway gateway, Vpc vpc)
        {
            LogMessage("Attaching internet gateway to " + vpc.VpcId + "...");
            GenericActionResponse response = awsServices.AttachInternetGateway(gateway, vpc);
            if (response.Success == true)
            {
                LogMessage("Attached internet gateway to VPC.");
            }
            else
            {
                LogMessage("Unable to attach internet gateway to VPC.");
            }
            return response;
        }

        public GenericActionResponse DetachInternetGateway(InternetGateway gateway, Vpc vpc)
        {
            LogMessage("Detaching internet gateway from VPC " + vpc.VpcId + ".");
            GenericActionResponse response = awsServices.DetachInternetGateway(gateway, vpc);
            if (response.Success == true)
            {
                LogMessage("Detached internet gateway from VPC.");
            }
            else
            {
                LogMessage("Unable to detach internet gateway from VPC.");
            }
            return response;
        }

        public GetInternetGatewaysResponse GetInternetGateways(Vpc vpc)
        {
            LogMessage("Getting internet gateways for VPC " + vpc.VpcId + ".");
            GetInternetGatewaysResponse response = awsServices.GetInternetGateways(vpc);
            if (response.Success == true)
            {
                LogMessage("Retrieved internet gateways for VPC.");
            }
            else
            {
                LogMessage("Unable to retrieve internet gateways for VPC.");
            }
            return response;
        }

        public GetSecurityGroupsResponse GetSecurityGroups(string vpcId)
        {
            LogMessage("Getting security groups for VPC " + vpcId + ".");
            GetSecurityGroupsResponse response = awsServices.GetSecurityGroups(vpcId);
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.SecurityGroups.Count + " security groups in VPC " + vpcId + ".");
            }
            else
            {
                LogMessage("Unable to retrieve security groups for VPC.");
            }
            return response;
        }

        public GetImagesResponse GetCommonImages()
        {
            LogMessage("Getting common images...");
            GetImagesResponse response = awsServices.GetCommonImages();
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Images.Count + " common images.");
            }
            else
            {
                LogMessage("Unable to retrieve common images.");
            }
            return response;
        }

        public GetImagesResponse GetImages()
        {
            LogMessage("Getting images...");
            GetImagesResponse response = awsServices.GetImages();
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Images.Count + " images.");
            }
            else
            {
                LogMessage("Unable to retrieve images.");
            }
            return response;
        }

        public GetKeyNamesResponse GetKeyNames()
        {
            LogMessage("Getting key names...");
            GetKeyNamesResponse response = awsServices.GetKeyNames();
            if (response.Success == true)
            {
                LogMessage("Retrieved key names.");
            }
            else
            {
                LogMessage("Unable to retrieve key names.");
            }
            return response;
        }

        public GetInstanceTypesResponse GetInstanceTypes()
        {
            LogMessage("Getting instance types...");
            GetInstanceTypesResponse response = awsServices.GetInstanceTypes();
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.InstanceTypes.Count + " instance types.");
            }
            else
            {
                LogMessage("Unable to retrieve instance types.");
            }
            return response;
        }

        public GenericActionResponse LaunchInstance(string imageId, string instanceType, int minCount, int maxCount, string keyName, String subnetId, List<string> securityGroups)
        {
            LogMessage("Launching instance of " + imageId + "...");
            GenericActionResponse response = awsServices.LaunchInstance(imageId, instanceType, minCount, maxCount, keyName, subnetId, securityGroups);
            if (response.Success == true)
            {
                LogMessage("Launched instance(s) of " + imageId + ".");
            }
            else
            {
                LogMessage("Unable to launch instance(s).");
            }
            return response;
        }

        public GenericActionResponse StartInstances(List<string> instanceIds)
        {
            LogMessage("Starting instances...");
            GenericActionResponse response = awsServices.StartInstances(instanceIds);
            if (response.Success == true)
            {
                LogMessage("Started " + instanceIds.Count + " instances.");
            }
            else
            {
                LogMessage("Unable to start instances.");
            }
            return response;
        }

        public GenericActionResponse StartInstance(String instanceId)
        {
            LogMessage("Starting instance " + instanceId + ".");
            GenericActionResponse response = awsServices.StartInstance(instanceId);
            if (response.Success == true)
            {
                LogMessage("Started instance " + instanceId + ".");
            }
            else
            {
                LogMessage("Unable to start instance " + instanceId + ".");
            }
            return response;
        }

        public GenericActionResponse StopInstances(List<string> instanceIds)
        {
            LogMessage("Stopping instances...");
            GenericActionResponse response = awsServices.StopInstances(instanceIds);
            if (response.Success == true)
            {
                LogMessage("Stopped " + instanceIds.Count + " instances.");
            }
            else
            {
                LogMessage("Unable to stop instances.");
            }
            return response;
        }

        public GenericActionResponse StopInstance(String instanceId)
        {
            LogMessage("Stopping instance " + instanceId + "...");
            GenericActionResponse response = awsServices.StopInstance(instanceId);
            if (response.Success == true)
            {
                LogMessage("Stopped instance " + instanceId + ".");
            }
            else
            {
                LogMessage("Unable to stop instance " + instanceId + ".");
            }
            return response;
        }

        public GenericActionResponse TerminateInstances(List<string> instanceIds)
        {
            LogMessage("Terminating instances...");
            GenericActionResponse response = awsServices.TerminateInstances(instanceIds);
            if (response.Success == true)
            {
                LogMessage("Terminated instances.");
            }
            else
            {
                LogMessage("Unable to terminate instances.");
            }
            return response;
        }

        public GenericActionResponse TerminateInstance(String instanceId)
        {
            LogMessage("Terminating instance " + instanceId + "...");
            GenericActionResponse response = awsServices.TerminateInstance(instanceId);
            if (response.Success == true)
            {
                LogMessage("Terminated instance " + instanceId + ".");
            }
            else
            {
                LogMessage("Unable to terminate instance " + instanceId + ".");
            }
            return response;
        }

        public GetInstancesResponse GetInstances()
        {
            LogMessage("Getting instances...");
            GetInstancesResponse response = awsServices.GetInstances();
            if (response.Success == true)
            {
                LogMessage("Retrieved instances.");
            }
            else
            {
                LogMessage("Unable to retrieve instances.");
            }
            return response;
        }

        public GetInstancesResponse GetInstances(IList<Amazon.EC2.Model.Instance> instances)
        {
            LogMessage("Getting instances...");
            GetInstancesResponse response = awsServices.GetInstances(instances);
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Instances.Count + " instances.");
            }
            else
            {
                LogMessage("Unable to retrieve instances.");
            }
            return response;
        }

        public GetInstancesResponse GetInstancesInVpc(Vpc vpc)
        {
            LogMessage("Getting instances in VPC " + vpc.VpcId + "...");
            GetInstancesResponse response = awsServices.GetInstancesInVpc(vpc);
            if (response.Success == true)
            {
                LogMessage("Retrieved instances in VPC.");
            }
            else
            {
                LogMessage("Unable to retrieve instances in the VPC.");
            }
            return response;
        }

        public GetInstancesResponse GetInstancesInSubnet(Subnet subnet)
        {
            LogMessage("Getting instances in subnet " + subnet.SubnetId + "...");
            GetInstancesResponse response = awsServices.GetInstancesInSubnet(subnet);
            if (response.Success == true)
            {
                LogMessage("Retrieved " + response.Instances.Count + " instances in the subnet.");
            }
            else
            {
                LogMessage("Unable to retrieve instances in the subnet.");
            }
            return response;
        }

        public GetVpcsResponse GetVpcs()
        {
            LogMessage("Getting vpcs...");
            GetVpcsResponse response = awsServices.GetVpcs();
            if (response.Success == true)
            {
                LogMessage("Retrieved VPCs.");
            }
            else
            {
                LogMessage("Unable to retrieve VPCs.");
            }
            return response;
        }

    }

}
