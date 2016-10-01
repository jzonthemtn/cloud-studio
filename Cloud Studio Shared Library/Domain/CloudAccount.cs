using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CloudStudio.SharedLibrary.Domain {

    /// <summary>
    /// Represents a cloud account.
    /// </summary>
    public class CloudAccount {

        /// <summary>
        /// Gets and sets the ID of the account.
        /// </summary>
        public virtual Guid Id { get; set; }

        /// <summary>
        /// Gets and sets a description of the account.
        /// </summary>
        public virtual string Description { get; set; }

        /// <summary>
        /// Gets and sets the name of the provider for the account.
        /// </summary>
        public virtual string Provider { get; set; }

        /// <summary>
        /// Gets and sets the access key for the account.
        /// </summary>
        public virtual string AccessKey { get; set; }

        /// <summary>
        /// Gets and sets the secret key for the account.
        /// </summary>
        public virtual string SecretKey { get; set; }

        /// <summary>
        /// Gets and sets the region for the account.
        /// </summary>
        public virtual string Region { get; set; }

        /// <summary>
        /// Gets and sets if the account is enabled.
        /// </summary>
        public virtual bool Enabled { get; set; }

        /// <summary>
        /// Gets and sets if the account is in readonly mode.
        /// </summary>
        public virtual bool ReadOnlyMode { get; set; }

        /// <summary>
        /// Returns a string representation of the account formatted
        /// by the provider - description.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {

            return this.Provider + " - " + this.Description;

        }

    }

}
