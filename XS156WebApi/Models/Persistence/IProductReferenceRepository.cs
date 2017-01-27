using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public interface IProductReferenceRepository : IRepository<ProductReference>
    {
        ProductReference GetByName(string name);
    }
}