using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting details about internet gateways.
    /// </summary>
    public class GetInternetGatewaysResponse : AbstractResponse {

        public IList<InternetGateway> InternetGateways { get; set; }

    }

}
