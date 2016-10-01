using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;
using Amazon.ElasticLoadBalancing.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting details about ELBs.
    /// </summary>
    public class GetLoadBalancersResponse : AbstractResponse {

        public IList<LoadBalancerDescription> LoadBalancerDescriptions { get; set; }

    }

}
