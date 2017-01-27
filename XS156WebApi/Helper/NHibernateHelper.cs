using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using NHibernate.Cfg;
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
        const string ConnectionString = @"Data Source=127.0.0.1;Initial Catalog=XS156TRAC;Persist Security Info=True;User ID=sa;Password=passwordsa;MultipleActiveResultSets=True;Max Pool Size=500";
        private static ISessionFactory SessionFactory
        {
            get
            {
                if (_sessionFactory == null)
                    CreateSessionFactory();

                return _sessionFactory;
            }
        }

        private static void CreateSessionFactory()
        {
            try
            {
                NHibernate.Cfg.Configuration  ff= new Configuration();
                var cfgs = Fluently.Configure()
                    .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql)
                    .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Equipment>())
                    .ExposeConfiguration(cfg => ff=cfg);

                SchemaValidator f = new SchemaValidator(ff);

               _sessionFactory= cfgs.BuildSessionFactory();
              
            }
            catch (Exception ex1)
            {
                try
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql)
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Equipment>())
                        .ExposeConfiguration(cfg => new SchemaUpdate(cfg).Execute(false, true))
                        .BuildSessionFactory();

                }
                catch (Exception ex2)
                {
                    _sessionFactory = Fluently.Configure()
                        .Database(MsSqlConfiguration.MsSql2008.ConnectionString(ConnectionString).ShowSql)
                        .Mappings(m => m.FluentMappings.AddFromAssemblyOf<Equipment>())
                        .ExposeConfiguration(cfg => new SchemaExport(cfg).Create(false, true))
                        .BuildSessionFactory();
                }
            }
        }
    }
}