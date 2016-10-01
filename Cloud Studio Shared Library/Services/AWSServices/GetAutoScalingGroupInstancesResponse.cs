using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices {

    /// <summary>
    /// Response for getting autoscaling instances.
    /// </summary>
    public class GetAutoScalingGroupInstancesResponse : AbstractResponse
    {
        public IDictionary<string, string> Instances { get; set; }
    }

}
