using Amazon.RDS.Model;
using CloudStudio.SharedLibrary.Services.AWSServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.GUI.Utils
{
    public class AwsUtils
    {

        public static string GetRDSLabel(DBInstance dbInstance)
        {
            StringBuilder sb = new StringBuilder();
            
            if(dbInstance.DBName != null && dbInstance.DBName != string.Empty && dbInstance.DBName != "")
            {
                sb.AppendLine(dbInstance.DBName);
            }
            else
            {
                sb.AppendLine("RDS");
            }

            sb.AppendLine(dbInstance.Engine);
           // sb.AppendLine(dbInstance.)
            return sb.ToString();

        }

        public static bool SearchInTags(IList<Amazon.EC2.Model.Tag> tags, string search)
        {

            foreach (Amazon.EC2.Model.Tag tag in tags)
            {
                if (tag.Key.Contains(search) || tag.Value.Contains(search))
                {
                    return true;
                }
            }

            return false;

        }

        public static bool IsValidType(string type) {
        
            if (type == "SSH") {
                return true;
            } else if (type == "FTP") {
                return true;
            } else if (type == "SMTP") {
                return true;
            } else if (type == "HTTP") {
                return true;
            } else if (type == "POP3") {
                return true;
            } else if (type == "IMAP") {
                return true;
            } else if (type == "HTTPS") {
                return true;
            } else if (type == "LDAP") {
                return true;
            } else if (type == "DNS") {
                return true;
            } else if (type == "SMTPS") {
                return true;
            } else if (type == "IMAPS") {
                return true;
            } else if (type == "POP3S") {
                return true;
            } else if (type == "MS SQL") {
                return true;
            } else if (type == "MYSQL") {
                return true;
            } else if (type == "RDP") {
                return true;
            } else {
                return false;
            }

        }

        public static int GetPortFromType(string type) {

            if (type == "SSH") {
                return 22;
            } else if (type == "FTP") {
                return 21;
            } else if (type == "SMTP") {
                return 25;
            } else if (type == "HTTP") {
                return 80;
            } else if (type == "POP3") {
                return 110;
            } else if (type == "IMAP") {
                return 143;
            } else if (type == "HTTPS") {
                return 443;
            } else if (type == "LDAP") {
                return 389;
            } else if (type == "DNS") {
                return 53;
            } else if (type == "SMTPS") {
                return 465;
            } else if (type == "IMAPS") {
                return 993;
            } else if (type == "POP3S") {
                return 995;
            } else if (type == "MS SQL") {
                return 1433;
            } else if (type == "MYSQL") {
                return 3306;
            } else if (type == "RDP") {
                return 389;
            } else {
                return 0;
            }

        }

        public static string GetTypeFromPort(int port) {

            if (port == 22) {
                return "SSH";
            } else if (port == 21) {
                return "FTP";
            } else if (port == 25) {
                return "SMTP";
            } else if (port == 80) {
                return "HTTP";
            } else if (port == 110) {
                return "POP3";
            } else if (port == 143) {
                return "IMAP";
            } else if (port == 443) {
                return "HTTPS";
            } else if (port == 389) {
                return "LDAP";
            } else if (port == 53) {
                return "DNS";
            } else if (port == 465) {
                return "SMTPS";
            } else if (port == 993) {
                return "IMAPS";
            } else if (port == 995) {
                return "POP3S";
            } else if (port == 1433) {
                return "MS SQL";
            } else if (port == 3306) {
                return "MYSQL";
            } else if (port == 389) {
                return "RDP";
            } else {
                return "Custom";
            }            

        }

        /// <summary>
        /// Look for a Name tag and return its value.
        /// </summary>
        /// <param name="tags">A list of EC2 resource tags.</param>
        /// <returns>The value of the Name tag, if cound. Returns
        /// "[Unnamed]" if no "Name" tag is found.</returns>
        public static string GetNameFromTags(IList<Amazon.EC2.Model.Tag> tags)
        {

            foreach (Amazon.EC2.Model.Tag tag in tags)
            {

                if (tag.Key == "Name")
                {
                    return tag.Value;
                }

            }

            return "[Unnamed]";

        }

        public static GetRegionEndpointsResponse GetRegionEndpoints()
        {

            // No need to use the cache for this function because it
            // does not make an API call.

            GetRegionEndpointsResponse getRegionEndpointsResponse = new GetRegionEndpointsResponse();

            getRegionEndpointsResponse.Endpoints = Amazon.RegionEndpoint.EnumerableAllRegions;

            return getRegionEndpointsResponse;

        }

    }
}
