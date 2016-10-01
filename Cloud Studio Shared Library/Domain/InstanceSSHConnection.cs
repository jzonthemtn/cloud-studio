using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Domain {

    /// <summary>
    /// Represents SSH connection settings for a cloud instance.
    /// </summary>
    public class InstanceSSHConnection {

        /// <summary>
        /// Gets and sets the ID of the connection.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets and sets the ID of the instance.
        /// </summary>
        public virtual string InstanceId { get; set; }

        /// <summary>
        /// Gets and sets the username for the connection.
        /// </summary>
        public virtual string UserName { get; set; }

        /// <summary>
        /// Gets and sets the private key file for the connection.
        /// </summary>
        public virtual string KeyFilePath { get; set; }

        /// <summary>
        /// Gets and sets the ID of the cloud associated with this connection.
        /// </summary>
        public virtual Guid CloudAccountId { get; set; }

        /// <summary>
        /// Returns a string representation of the connection.
        /// </summary>
        /// <returns>Formatted as username@instanceId.</returns>
        public override string ToString() {

            return this.UserName + "@" + this.InstanceId;

        }

    }

}