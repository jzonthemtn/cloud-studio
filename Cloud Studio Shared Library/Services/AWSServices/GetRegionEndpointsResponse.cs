using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting the available AWS endpoints.
    /// </summary>
    public class GetRegionEndpointsResponse : AbstractResponse {

        public IEnumerable<RegionEndpoint> Endpoints { get; set; }

    }

}
