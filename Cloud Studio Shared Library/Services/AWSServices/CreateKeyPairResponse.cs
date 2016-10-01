using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for creating a new EC2 keypair.
    /// </summary>
    public class CreateKeyPairResponse : AbstractResponse
    {

        public string KeyName { get; set; }
        public string Fingerprint { get; set; }
        public string Material { get; set; }

    }

}
