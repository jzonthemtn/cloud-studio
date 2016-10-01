using CloudStudio.SharedLibrary.Services.PowerShellIntegration;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Management.Automation;
using System.Text;

namespace CloudStudio.Services.Services
{
    public class PowerShellIntegrationService
    {

        /// <summary>
        /// Execute a Windows PowerShell command.
        /// </summary>
        /// <param name="request">The PowerShellExecuteCommandRequest request.</param>
        /// <returns></returns>
        public PowerShellExecuteCommandResponse ExecutePowerShellCommand(PowerShellExecuteCommandRequest request)
        {

            PowerShellExecuteCommandResponse response = new PowerShellExecuteCommandResponse();

            using (PowerShell PowerShellInstance = PowerShell.Create())
            {

                // use "AddScript" to add the contents of a script file to the end of the execution pipeline.
                // use "AddCommand" to add individual commands/cmdlets to the end of the execution pipeline.

                PowerShellInstance.AddScript(request.Script);

                // invoke execution on the pipeline (collecting output)
                Collection<PSObject> PSOutput = PowerShellInstance.Invoke();

                // check the other output streams (for example, the error stream)
                if (PowerShellInstance.Streams.Error.Count > 0)
                {

                    // error records were written to the error stream.
                    // do something with the items found.

                    response.Success = false;

                }
                else
                {

                    StringBuilder result = new StringBuilder();

                    // loop through each output object item
                    foreach (PSObject outputItem in PSOutput)
                    {

                        // if null object was dumped to the pipeline during the script then a null
                        // object may be present here. check for null to prevent potential NRE.
                        if (outputItem != null)
                        {

                            result.AppendLine(outputItem.BaseObject.ToString());

                            // TODO: do something with the output item 
                            System.Diagnostics.Debug.WriteLine(outputItem.BaseObject.GetType().FullName);
                            System.Diagnostics.Debug.WriteLine(outputItem.BaseObject.ToString() + "\n");

                        }

                    }

                    response.Result = result.ToString();

                }

            }

            return null;

        }

    }
}
