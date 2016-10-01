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
using CloudStudio.Services.Utilities;

namespace CloudStudio.Services {

    /// <summary>
    /// Services for manipulating cloud accounts.
    /// </summary>
    public class CloudAccountService : AbstractService {

        private static readonly ILog Log = LogManager.GetLogger(typeof(CloudAccountService));

        private CloudAccountRepository cloudAccountRepository;

        /// <summary>
        /// Creates a new CloudAccountService object.
        /// </summary>
        public CloudAccountService() {

            cloudAccountRepository = new CloudAccountRepository();

        }

        /// <summary>
        /// Gets a cloud account by ID.
        /// </summary>
        /// <param name="guid">The ID of the cloud account.</param>
        /// <returns>A CloudAccount; null if the cloud account could not be found.</returns>
        public CloudAccount GetCloudAccountById(String guid) {

            CloudAccount cloudAccount = cloudAccountRepository.GetCloudAccountById(guid);

            if (cloudAccount != null)
            {

                // Decrypt the keys.
                cloudAccount.AccessKey = EncryptionUtils.DecryptStringAES(cloudAccount.AccessKey);
                cloudAccount.SecretKey = EncryptionUtils.DecryptStringAES(cloudAccount.SecretKey);

            }

            return cloudAccount;

        }

        /// <summary>
        /// Gets a cloud account by description.
        /// </summary>
        /// <param name="description">The description.</param>
        /// <returns>A CloudAccount; null if the cloud account could not be found.</returns>
        public CloudAccount GetCloudAccountByDescription(String description) {

            CloudAccount cloudAccount = cloudAccountRepository.GetCloudAccountByDescription(description);

            if (cloudAccount != null)
            {

                // Decrypt the keys.
                cloudAccount.AccessKey = EncryptionUtils.DecryptStringAES(cloudAccount.AccessKey);
                cloudAccount.SecretKey = EncryptionUtils.DecryptStringAES(cloudAccount.SecretKey);

                

            }            

            return cloudAccount;

        }

        /// <summary>
        /// Save a CloudAccount.
        /// </summary>
        /// <param name="cloudAccount">The CloudAccount to save.</param>
        public void SaveCloudAccount(CloudAccount cloudAccount) {

            // Encrypt the keys.
            cloudAccount.AccessKey = EncryptionUtils.EncryptStringAES(cloudAccount.AccessKey);
            cloudAccount.SecretKey = EncryptionUtils.EncryptStringAES(cloudAccount.SecretKey);

            // Save it.
            cloudAccountRepository.Save(cloudAccount);

        }

        /// <summary>
        /// Gets all cloud accounts.
        /// </summary>
        /// <param name="onlyEnabled">True to only retrieve enabled cloud accounts.</param>
        /// <returns>A list of cloud accounts.</returns>
        public IList<CloudAccount> GetCloudAccounts(bool onlyEnabled) {

            IList<CloudAccount> cloudAccounts = cloudAccountRepository.GetCloudAccounts(onlyEnabled);

            foreach (CloudAccount cloudAccount in cloudAccounts)
            {

                // Decrypt the keys.
                cloudAccount.AccessKey = EncryptionUtils.DecryptStringAES(cloudAccount.AccessKey);
                cloudAccount.SecretKey = EncryptionUtils.DecryptStringAES(cloudAccount.SecretKey);

            }

            return cloudAccounts;

        }

        /// <summary>
        /// Disable a cloud account.
        /// </summary>
        /// <param name="cloudAccount">The cloud account.</param>
        public void Disable(CloudAccount cloudAccount, bool enabled) {

            cloudAccountRepository.SetEnabled(cloudAccount, enabled);

        }

        /// <summary>
        /// Set a cloud account's readonly property.
        /// </summary>
        /// <param name="cloudAccount">The cloud account.</param>
        /// <param name="readOnly">True to set as readonly.</param>
        public void SetReadOnly(CloudAccount cloudAccount, bool readOnly)
        {

            cloudAccountRepository.SetReadOnly(cloudAccount, readOnly);

        }

        /// <summary>
        /// Deletes a cloud account.
        /// </summary>
        /// <param name="cloudAccount">The cloud account to delete.</param>
        public void Delete(CloudAccount cloudAccount)
        {
            cloudAccountRepository.Delete(cloudAccount);
        }

    }

}