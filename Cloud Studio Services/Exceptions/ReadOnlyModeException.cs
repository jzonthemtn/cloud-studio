using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CloudStudio.Services.Exceptions
{

    /// <summary>
    /// Thrown when a write operation is attempted on
    /// a cloud account in read only mode.
    /// </summary>
    public class ReadOnlyModeException : Exception 
    {

        public ReadOnlyModeException(string message)
        : base(message)
        {
        }

    }

}
