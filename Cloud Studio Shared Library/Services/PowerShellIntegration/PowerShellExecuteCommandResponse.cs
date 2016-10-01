using CloudStudio.SharedLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Services.PowerShellIntegration
{

    /// <summary>
    /// The response from a Windows PowerShell execution.
    /// </summary>
    public class PowerShellExecuteCommandResponse : AbstractResponse
    {

        /// <summary>
        /// Gets or sets the result of the PowerShell command execution.
        /// </summary>
        public virtual string Result { get; set; }

    }

}
