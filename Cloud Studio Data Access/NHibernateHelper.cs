﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudStudio.SharedLibrary.Domain;
using NHibernate;
using NHibernate.Cfg;

namespace CloudStudio.DataAccess {
   
    public class NHibernateHelper {

        private static ISessionFactory _sessionFactory;

        private static ISessionFactory SessionFactory {

            get {

                if (_sessionFactory == null) {

                    var configuration = new Configuration();
                    configuration.Configure();
                    configuration.AddAssembly(typeof(CloudAccount).Assembly);
                    configuration.AddAssembly(typeof(CloudProvider).Assembly);

                    _sessionFactory = configuration.BuildSessionFactory();

                }

                return _sessionFactory;

            }

        }

        public static ISession OpenSession() {
            return SessionFactory.OpenSession();
        }

    }
}
