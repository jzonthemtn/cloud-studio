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

    public class InstanceSSHConnectionRepository : AbstractRepository<InstanceSSHConnection>, IInstanceSSHConnectionRepository {

        public InstanceSSHConnection GetByInstanceId(string instanceId, Guid cloudAccountId) {

            InstanceSSHConnection conn = null;

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    ICriteria crit = session.CreateCriteria<InstanceSSHConnection>();
                    crit.Add(Restrictions.Eq("CloudAccountId", cloudAccountId));
                    crit.Add(Restrictions.Eq("InstanceId", instanceId));

                    conn = crit.UniqueResult<InstanceSSHConnection>();

                    transaction.Commit();

                }

            }

            return conn;

        }

    }

}