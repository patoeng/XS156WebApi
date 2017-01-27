using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public interface IRepository<T>
    {
        T Get(string id);
        IEnumerable<T> GetAll();
        T Add(T obj);
        void Delete(string id);
        bool Update(T obj);
    }
}