using CloudStudio.SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Services.PowerShellIntegration
{

    /// <summary>
    /// A request to execute a Windows PowerShell command.
    /// </summary>
    public class PowerShellExecuteCommandRequest : AbstractRequest
    {

        /// <summary>
        /// Gets or sets the script to be executed.
        /// </summary>
        public virtual string Script { get; set; }

    }
}
