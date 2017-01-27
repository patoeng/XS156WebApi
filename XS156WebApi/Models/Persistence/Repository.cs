using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using NHibernate.Linq;
using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
    public abstract class Repository <T> : IRepository<T>
    {
            protected Repository()
            {

            }

            public T Get(string id)
            {
                
                using (var session = NHibernateHelper.OpenSession())
                    return session.Get<T>(new Guid(id));
            }

            public IEnumerable<T> GetAll()
            {
                using (var session = NHibernateHelper.OpenSession())
                    return session.Query<T>().ToList();
            }

            public T Add(T obj)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Save(obj);
                        transaction.Commit();
                    }
                    return obj;
                }
            }

            public void Delete(string id)
            {
                var obj = Get(id);

                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.Delete(obj);
                        transaction.Commit();
                    }
                }
            }

            public bool Update(T obj)
            {
                using (var session = NHibernateHelper.OpenSession())
                {
                    using (var transaction = session.BeginTransaction())
                    {
                        session.SaveOrUpdate(obj);
                        try
                        {
                            transaction.Commit();
                        }
                        catch (Exception)
                        {
                            throw;
                        }
                    }
                    return true;
                }
            }
        }
}