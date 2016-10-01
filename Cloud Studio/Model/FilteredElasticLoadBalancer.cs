using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Model
{
    public class FilteredElasticLoadBalancer : FilteredObject
    {

        private FilteredElasticLoadBalancer() { }

        [Browsable(true)]
        [ReadOnly(true)]
        public string AvailabilityZones { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string CanonicalHostedZoneName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string CanonicalHostedZoneNameID { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string CreatedTime { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string DNSName { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public FilteredHealthCheck HealthCheck { get; set; }

        // TODO: Instances
        // TODO: ListenerDescriptions

        [Browsable(true)]
        [ReadOnly(true)]
        public string LoadBalancerName { get; set; }

        // TODO: Policies

        [Browsable(true)]
        [ReadOnly(true)]
        public string Scheme { get; set; }

        // TODO: SecurityGroups
        // TODO: SourceSecurityGroup
        // TODO: Subnets

        [Browsable(true)]
        [ReadOnly(true)]
        public string VPCId { get; set; }

        public static FilteredElasticLoadBalancer FromLoadBalancerDescription(LoadBalancerDescription elasticLoadBalancer)
        {

            FilteredElasticLoadBalancer filteredElasticLoadBalancer = new FilteredElasticLoadBalancer();

            filteredElasticLoadBalancer.AvailabilityZones = String.Join(", ", elasticLoadBalancer.AvailabilityZones);
            filteredElasticLoadBalancer.CanonicalHostedZoneName = elasticLoadBalancer.CanonicalHostedZoneName;
            filteredElasticLoadBalancer.CanonicalHostedZoneNameID = elasticLoadBalancer.CanonicalHostedZoneNameID;
            filteredElasticLoadBalancer.CreatedTime = elasticLoadBalancer.CreatedTime.ToString();
            filteredElasticLoadBalancer.DNSName = elasticLoadBalancer.DNSName;
            filteredElasticLoadBalancer.HealthCheck = FilteredHealthCheck.FromHealthCheck(elasticLoadBalancer.HealthCheck);
            filteredElasticLoadBalancer.LoadBalancerName = elasticLoadBalancer.LoadBalancerName;
            filteredElasticLoadBalancer.Scheme = elasticLoadBalancer.Scheme;
            filteredElasticLoadBalancer.VPCId = elasticLoadBalancer.VPCId;

            return filteredElasticLoadBalancer;

        }

        public class FilteredHealthCheck
        {
            public int HealthyThreadhold { get; set; }
            public int Interval { get; set; }
            public string Target { get; set; }
            public int Timeout { get; set; }
            public int UnhealthyThreshold { get; set; }

            private FilteredHealthCheck() { }

            public static FilteredHealthCheck FromHealthCheck(HealthCheck healthCheck)
            {
                FilteredHealthCheck filteredHealthCheck = new FilteredHealthCheck();
                filteredHealthCheck.HealthyThreadhold = healthCheck.HealthyThreshold;
                filteredHealthCheck.Interval = healthCheck.Interval;
                filteredHealthCheck.Target = healthCheck.Target;
                filteredHealthCheck.Timeout = healthCheck.Timeout;
                filteredHealthCheck.UnhealthyThreshold = healthCheck.UnhealthyThreshold;

                return filteredHealthCheck;
            }
        }
 
    }

}
