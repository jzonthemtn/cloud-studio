using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.GUI.Settings {

    public class CustomEndpoint : ApplicationSettingsBase {

        private string name;
        private string url;

        public CustomEndpoint() {

        }

        public override string ToString() {

            return name + " - " + url;

        }

        public CustomEndpoint(string name, string url) {

            this.name = name;
            this.url = url;

        }

        [UserScopedSetting()]
        [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
        public string Name {
            get { return name; }
        }

        [UserScopedSetting()]
        [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
        public string Url {
            get { return url; }
        }

    }

}
