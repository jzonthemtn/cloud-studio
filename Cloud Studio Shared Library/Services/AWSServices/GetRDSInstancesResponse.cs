using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;
using Amazon.RDS.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for describing RDS instances.
    /// </summary>
    public class GetRDSInstancesResponse : AbstractResponse
    {
        public List<DBInstance> DBInstances { get; set; }

        public GetRDSInstancesResponse()
        {
            DBInstances = new List<DBInstance>();
        }
    }

}
