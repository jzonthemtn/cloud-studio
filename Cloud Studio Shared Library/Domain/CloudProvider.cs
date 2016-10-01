using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Domain {

    /// <summary>
    /// Represents a cloud provider.
    /// </summary>
    public class CloudProvider {

        /// <summary>
        /// Gets and sets the ID of the cloud provider.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the name of the cloud provider.
        /// </summary>
        public virtual string Name { get; set; }

    }

}
