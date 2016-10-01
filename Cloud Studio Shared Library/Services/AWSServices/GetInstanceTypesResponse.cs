using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting instance types.
    /// </summary>
    public class GetInstanceTypesResponse : AbstractResponse {

        public IList<string> InstanceTypes { get; set; }

    }

}
