using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace CloudStudio.SharedLibrary
{
    
    /// <summary>
    /// An abstract for class for services.
    /// </summary>
    public abstract class AbstractService {

        protected static readonly ILog log = LogManager.GetLogger(typeof(AbstractService));

    }

}