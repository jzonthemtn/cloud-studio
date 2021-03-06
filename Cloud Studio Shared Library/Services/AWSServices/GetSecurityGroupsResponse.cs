﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.EC2.Model;

namespace CloudStudio.SharedLibrary.Services.AWSServices
{

    /// <summary>
    /// Response for getting the security groups.
    /// </summary>
    public class GetSecurityGroupsResponse : AbstractResponse {

        public IList<SecurityGroup> SecurityGroups { get; set; }

    }

}
