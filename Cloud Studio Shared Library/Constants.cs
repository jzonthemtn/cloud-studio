using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary
{
    
    public class Constants
    {

        public static readonly DateTime EXPIRES_DATE = new DateTime(2015, 12, 31);

        public static readonly string STATS_GUID = "17e6c49f1df63ae0d989abffb4246c51";

        public static readonly string ICONS8_URL = "http://www.icons8.com";
        public static readonly string HOMEPAGE_URL = "https://www.github.com/jzonthemtn/cloud-studio";

        public static readonly string UNKNOWN_IP = "Unknown";

        public static IDictionary<string, string> RemoteConnectVariables = new Dictionary<string, string>();

        static Constants() {

            RemoteConnectVariables.Add("${username}", "The user name to connect with.");
            RemoteConnectVariables.Add("${keyfile}", "The path to the key file.");
            RemoteConnectVariables.Add("${host}", "The host (IP) to connect to.");

        }

        public static bool GetBoolFromYesNo(string yesNo) {

            if (yesNo == "Yes") {
                return true;
            } else {
                return false;
            }

        }

        public static string GetYesNoFromBool(bool trueFalse) {

            if (trueFalse == true) {
                return "Yes";
            } else {
                return "No";
            }
        }

    }

}
