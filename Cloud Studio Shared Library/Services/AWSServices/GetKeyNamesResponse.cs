using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting EC2 key names.
    /// </summary>
    public class GetKeyNamesResponse : AbstractResponse {

        public IList<KeyPairInfo> KeyPairs { get; set; }

    }

}
