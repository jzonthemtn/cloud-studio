using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.GUI.Settings {

    public class FavoriteAMI : ApplicationSettingsBase {

        private string ami;

        public FavoriteAMI() {

        }

        public override string ToString() {

            return ami;

        }

        public FavoriteAMI(string ami) {

            this.ami = ami;

        }

        [UserScopedSetting()]
        [SettingsSerializeAs(System.Configuration.SettingsSerializeAs.Xml)]
        public string Ami {
            get { return ami; }
        }

    }

}
