using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudStudio.GUI.Forms;
using System.IO;
using CloudStudio.Services.Model;
using CloudStudio.SharedLibrary;

namespace CloudStudio.GUI {

    static class Program {

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args) {

            log4net.Config.XmlConfigurator.Configure();
 
        }

    }

}
