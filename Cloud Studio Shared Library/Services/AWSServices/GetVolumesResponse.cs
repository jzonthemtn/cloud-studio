﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{
    
    /// <summary>
    /// Response for getting details about volumes.
    /// </summary>
    public class GetVolumesResponse : AbstractResponse {

        public IList<Volume> Volumes { get; set; }

    }

}
