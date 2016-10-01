using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices {

    /// <summary>
    /// Response for retrieving details about images (AMIs).
    /// </summary>
    public class GetImagesResponse : AbstractResponse {

        public IList<Image> Images { get; set; }

    }

}
