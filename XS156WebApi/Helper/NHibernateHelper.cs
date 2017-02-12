using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Dialect;
using NHibernate.Tool.hbm2ddl;
using XS156WebApi.Models;

namespace XS156WebApi.Helper
{
    public class NHibernateHelper{
    public static ISession OpenSession()
        {
            return SessionFactory.OpenSession();

        }

        private static ISessionFactory _sessionFactory;
        const string ConnectionString = @"Data Source=127.0.0.1;Initial Catalog=XS156TRAC;User ID=sa;Password=passwordsa;";
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                {
                    CreateSessionFactory();
                }
              
               

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
           
                
                
                NHibernate.Cfg.Configuration  ff= new Configuration();
                var cfgs = Fluently.Configure()
                    .Database( MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString))
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Equipment>())
                    .ExposeConfiguration(cfg => ff=cfg);

               _sessionFactory= cfgs.BuildSessionFactory();
            
        }
    }
}