using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudStudio.DataAccess;
using CloudStudio.SharedLibrary.Domain;
using CloudStudio.DataAccess.Repositories;
using NHibernate;
using NHibernate.Criterion;

namespace CloudStudio.DataAccess.Repositories {
    
    public class CloudAccountRepository : AbstractRepository<CloudAccount>, ICloudAccountRepository  {

        public void SetEnabled(CloudAccount cloudAccount, bool enabled)
        {

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    cloudAccount.Enabled = enabled;
                    session.SaveOrUpdate(cloudAccount);

                    transaction.Commit();

                }

            }

        }

        public void SetReadOnly(CloudAccount cloudAccount, bool readOnly)
        {

            using (ISession session = NHibernateHelper.OpenSession())
            {

                using (ITransaction transaction = session.BeginTransaction())
                {

                    cloudAccount.ReadOnlyMode = readOnly;
                    session.SaveOrUpdate(cloudAccount);

                    transaction.Commit();

                }

            }

        }

        public IList<CloudAccount> GetCloudAccounts(bool onlyEnabled) {

            IList<CloudAccount> cloudAccounts = new List<CloudAccount>();

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    ICriteria crit = session.CreateCriteria<CloudAccount>();

                    if (onlyEnabled == true) {

                        crit.Add(Restrictions.Eq("Enabled", true));

                    }

                    cloudAccounts = crit.List<CloudAccount>();

                    transaction.Commit();

                }

            }

            return cloudAccounts;

        }

        public CloudAccount GetCloudAccountByDescription(String description) {

            CloudAccount cloudAccount = null;

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    ICriteria crit = session.CreateCriteria<CloudAccount>();
                    crit.Add(Restrictions.Eq("Description", description));
                    cloudAccount = crit.UniqueResult<CloudAccount>();

                    transaction.Commit();

                }

            }

            return cloudAccount;

        }

        public CloudAccount GetCloudAccountById(String guid) {

            CloudAccount cloudAccount = null;

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    Guid g = new Guid(guid);

                    ICriteria crit = session.CreateCriteria<CloudAccount>();
                    crit.Add(Restrictions.Eq("id", g));
                    cloudAccount = crit.UniqueResult<CloudAccount>();

                    transaction.Commit();

                }

            }

            return cloudAccount;

        }

    }

}