using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using log4net;

namespace CloudStudio.DataAccess.Repositories {

    public abstract class AbstractRepository<T> where T : class {

        private static readonly ILog Logger = LogManager.GetLogger("AbstractRepository");

        public void Save(T item) {

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    session.SaveOrUpdate(item);

                    transaction.Commit();

                }


            }

        }

        public T GetById(String id) {

            T item = null;

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    ICriteria crit = session.CreateCriteria<T>();
                    item = crit.UniqueResult<T>();

                    transaction.Commit();

                }


            }

            return item;

        }

        public void Delete(T item) {

            using (ISession session = NHibernateHelper.OpenSession()) {

                using (ITransaction transaction = session.BeginTransaction()) {

                    // If the item does not exist an exception will be thrown.

                    try
                    {

                        session.Delete(item);
                        transaction.Commit();

                    }
                    catch (System.ArgumentNullException ex)
                    {
                        // Unable to delete because it does not exist.
                        Logger.Error("Unable to delete entity.", ex);
                    }                    

                }

            }

        }

    }

}
