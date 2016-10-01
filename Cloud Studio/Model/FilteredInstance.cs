using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Model
{

    //[DefaultPropertyAttribute("AmiLaunchIndex")]
    //[CategoryAttribute("ID Settings")]

    public class FilteredInstance : FilteredObject
    {

        [Browsable(true)]
        [ReadOnly(true)]
        //[DisplayName("Int for Displaying")]
        //[Description("Int for Displaying")]       
        public int AmiLaunchIndex { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public string Architecture { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public string ClientToken { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public bool EbsOptimized { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public string Hypervisor { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public string ImageId { get; set; }

        [Browsable(true)] 
        [ReadOnly(true)]
        public string InstanceId { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string InstanceLifeCycle { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string InstanceType { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string KernelId { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string KeyName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string LaunchTime { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string Monitoring { get; set; }

        // NetworkInterfaces

        [Browsable(true)]
        [ReadOnly(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public FilteredPlacement Placement { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string Platform { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string PrivateDnsAddress { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string PrivateIpAddress { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string RamdiskId { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string RootDeviceName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string RootDeviceType { get; set; }

        // TODO: Security Groups

        [Browsable(true)]
        [ReadOnly(true)]
        public bool SourceDestChecks { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string SpotInstanceRequestId { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string SriovNetSupport { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string State { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string StateReason { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string StateTransitionReason { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string SubnetId { get; set; }

        // TODO: Tags.

        [Browsable(true)]
        [ReadOnly(true)]
        public string VirtualizationType { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string VpcId { get; set; }

        private FilteredInstance() {}

        public static FilteredInstance FromInstance(Instance instance)
        {

            FilteredInstance filteredInstance = new FilteredInstance();

            filteredInstance.AmiLaunchIndex = instance.AmiLaunchIndex;
            filteredInstance.Architecture = instance.Architecture.Value;
            filteredInstance.ClientToken = instance.ClientToken;
            filteredInstance.EbsOptimized = instance.EbsOptimized;
            filteredInstance.Hypervisor = instance.Hypervisor;
            filteredInstance.ImageId = instance.ImageId;
            filteredInstance.InstanceId = instance.InstanceId;

            if (instance.InstanceLifecycle != null)
            {
                filteredInstance.InstanceLifeCycle = instance.InstanceLifecycle.Value;
            }

            filteredInstance.InstanceType = instance.InstanceType;
            filteredInstance.KernelId = instance.KernelId;
            filteredInstance.KeyName = instance.KeyName;
            filteredInstance.LaunchTime = instance.LaunchTime.ToString();
            filteredInstance.Monitoring = instance.Monitoring.State.Value;
            filteredInstance.Placement = new FilteredPlacement(instance.Placement.AvailabilityZone, instance.Placement.GroupName, instance.Placement.Tenancy);

            if (instance.Platform != null)
            {
                filteredInstance.Platform = instance.Platform.Value;
            }

            filteredInstance.PrivateDnsAddress = instance.PrivateDnsName;
            filteredInstance.PrivateIpAddress = instance.PrivateIpAddress;
            filteredInstance.RamdiskId = instance.RamdiskId;
            filteredInstance.RootDeviceName = instance.RootDeviceName;
            filteredInstance.RootDeviceType = instance.RootDeviceType.Value;
            filteredInstance.SourceDestChecks = instance.SourceDestCheck;
            filteredInstance.SpotInstanceRequestId = instance.SpotInstanceRequestId;
            filteredInstance.SriovNetSupport = instance.SriovNetSupport;
            filteredInstance.State = instance.State.Name.Value + " (" + instance.State.Code.ToString() + ")";

            if (instance.StateReason != null)
            {
                filteredInstance.StateReason = instance.StateReason.Message + " (" + instance.StateReason.Code + ")";
            }

            filteredInstance.StateTransitionReason = instance.StateTransitionReason;
            filteredInstance.SubnetId = instance.SubnetId;
            filteredInstance.VirtualizationType = instance.VirtualizationType.Value;
            filteredInstance.VpcId = instance.VpcId;

            return filteredInstance;

        }

        public class FilteredPlacement
        {
            public string AvailabilityZone { get; set; }
            public string GroupName { get; set; }
            public string Tenancy { get; set; }

            public FilteredPlacement(string availabilityZone, string groupName, string tenancy)
            {
                this.AvailabilityZone = availabilityZone;
                this.GroupName = groupName;
                this.Tenancy = tenancy;
            }

            public override string ToString()
            {
                return AvailabilityZone;
            }

        }

    }

}
