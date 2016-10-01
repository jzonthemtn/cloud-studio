using Amazon.EC2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace CloudStudio.GUI.Model
{
    public class FilteredInternetGateway : FilteredObject
    {

        [Browsable(true)]
        [ReadOnly(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        public FilteredAttachments Attachments { get; set; }

        [Browsable(true)]
        [ReadOnly(true)]
        public string InternetGatewayId { get; set; }

        private FilteredInternetGateway() 
        {
            this.Attachments = new FilteredAttachments();
        }
 
        public static FilteredInternetGateway FromInternetGateway(InternetGateway internetGateway)
        {

            FilteredInternetGateway filteredInternetGateway = new FilteredInternetGateway();

            filteredInternetGateway.InternetGatewayId = internetGateway.InternetGatewayId;
            
            foreach(InternetGatewayAttachment attachment in internetGateway.Attachments)
            {
                filteredInternetGateway.Attachments.AddAttachment(new FilteredAttachment(attachment.State, attachment.VpcId));
            }

            return filteredInternetGateway;

        }

        public class FilteredAttachments 
        {
 
            public List<FilteredAttachment> Attachments { get; set; }

            public FilteredAttachments()
            {
                this.Attachments = new List<FilteredAttachment>();
            }

            public void AddAttachment(FilteredAttachment attachment)
            {
                this.Attachments.Add(attachment);         
            }

            public override string ToString()
            {
                return Attachments.Count + " attachments";
            }

        }

        public class FilteredAttachment
        {
            public string State { get; set; }

            [DefaultValueAttribute("VpcId")]
            public string VpcId { get; set; }

            public FilteredAttachment(string state, string vpcId)
            {
                this.State = state;
                this.VpcId = vpcId;
            }

            public override string ToString()
            {
                return this.State + " - " + this.VpcId;
            }
        }

    }
}
