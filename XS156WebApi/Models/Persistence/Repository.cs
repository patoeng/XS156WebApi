using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using XS156WebApi.Helper;

namespace XS156WebApi.Models.Persistence
{
    public abstract class Repository <C, T> : 
    IRepository<T> where T : class where C : DbContext, new() {

    private C _entities = new C();
    public C Context {

        get { return _entities; }
        set { _entities = value; }
    }
    
            protected Repository()
            {

            }

            public T Get(string id)
            {

                using (var dbcontect = new Xs156DbContext())
                    return dbcontect.Set<T>().Find(new Guid(id));
            }

            public virtual IEnumerable<T> GetAll()
            {

                IEnumerable<T> query = _entities.Set<T>();
                return query;
            }

            public IEnumerable<T> FindBy(System.Linq.Expressions.Expression<Func<T, bool>> predicate)
            {

                IEnumerable<T> query = _entities.Set<T>().Where(predicate);
                return query;
            }

            public virtual T Add(T entity)
            {
                _entities.Set<T>().Add(entity);
                Save();
                return entity;
            }

            
            public virtual void Delete(T entity)
            {
                _entities.Set<T>().Remove(entity);
                Save();
            }

            public virtual bool Update(T entity)
            {
                _entities.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                Save();
                return true;
            }

            public virtual void Save()
            {
                _entities.SaveChanges();
            }
        }
}