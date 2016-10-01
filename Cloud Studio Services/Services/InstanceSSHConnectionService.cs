using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.DataAccess.Repositories;
using log4net;
using CloudStudio.SharedLibrary;
using CloudStudio.Services.Services;

namespace CloudStudio.Services {

    /// <summary>
    /// Service for manipulating stored instance SSH connection settings.
    /// </summary>
    public class InstanceSSHConnectionService : AbstractService {

        private static readonly ILog Log = LogManager.GetLogger(typeof(InstanceSSHConnectionService));

        private InstanceSSHConnectionRepository instanceSSHConnectionRepository;

        public InstanceSSHConnectionService() {

            instanceSSHConnectionRepository = new InstanceSSHConnectionRepository();

        }

        /// <summary>
        /// Deletes a stored instance SSH connection.
        /// </summary>
        /// <param name="instanceSSHConnection">The SSH connection to delete.</param>
        public void DeleteInstanceSSHConnectionDetails(InstanceSSHConnection instanceSSHConnection) {

            instanceSSHConnectionRepository.Delete(instanceSSHConnection);

        }

        /// <summary>
        /// Gets an SSH connection by instance ID.
        /// </summary>
        /// <param name="instanceId">The ID of the instance.</param>
        /// <param name="cloudAccountId">The ID of the cloud account that owns the instance.</param>
        /// <returns></returns>
        public InstanceSSHConnection GetByInstanceId(string instanceId, Guid cloudAccountId) {

            return instanceSSHConnectionRepository.GetByInstanceId(instanceId, cloudAccountId);

        }

        /// <summary>
        /// Save SSH connection settings for an instance.
        /// </summary>
        /// <param name="instanceId">The ID of the instance.</param>
        /// <param name="userName">The user name for the connection.</param>
        /// <param name="privateKeyFilePath">The full path to the private key file.</param>
        /// <param name="cloudAccountId">The ID of the cloud account owning the instance.</param>
        public void SaveInstanceSSHConnectionDetails(string instanceId, string userName, string privateKeyFilePath, Guid cloudAccountId) {

            InstanceSSHConnection conn = new InstanceSSHConnection();
            conn.InstanceId = instanceId;
            conn.UserName = userName;
            conn.KeyFilePath = privateKeyFilePath;
            conn.CloudAccountId = cloudAccountId;

            instanceSSHConnectionRepository.Save(conn);

        }

    }

}
