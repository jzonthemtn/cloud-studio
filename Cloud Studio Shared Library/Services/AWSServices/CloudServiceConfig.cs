using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{
    
    public class CloudServiceConfig {

        public int Timeout { get; set; }
        public bool UseProxy { get; set; }
        public string ProxyHost { get; set; }
        public int ProxyPort { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }

        public CloudServiceConfig() {

            this.Timeout = 1;
            this.UseProxy = false;

        }

    }

}
