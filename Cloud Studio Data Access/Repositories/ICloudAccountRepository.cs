using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudStudio.SharedLibrary.Domain;

namespace CloudStudio.DataAccess.Repositories {

    public interface ICloudAccountRepository {

        IList<CloudAccount> GetCloudAccounts(bool onlyEnabled);
        void SetEnabled(CloudAccount cloudAccount, bool enabled);
        void SetReadOnly(CloudAccount cloudAccount, bool readOnly);
        CloudAccount GetCloudAccountByDescription(String description);
        CloudAccount GetCloudAccountById(String guid);

    }
}
