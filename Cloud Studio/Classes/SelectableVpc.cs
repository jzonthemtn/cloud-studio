using Amazon.EC2.Model;
using CloudStudio.GUI.Utils;
using CloudStudio.Services.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Classes
{
    public class SelectableVpc
    {
        public Vpc Vpc { get; set; }

        public SelectableVpc(Vpc vpc)
        {
            this.Vpc = vpc;
        }

        public override string ToString()
        {
            return Vpc.VpcId + " (" + AwsUtils.GetNameFromTags(Vpc.Tags) + ")";
        }
    }
}
