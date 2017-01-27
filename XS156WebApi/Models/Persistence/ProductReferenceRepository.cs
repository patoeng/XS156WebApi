using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XS156WebApi.Models.Persistence
{
    public class ProductReferenceRepository : Repository<ProductReference>,IProductReferenceRepository
    {
       
        public ProductReference GetByName(string name)
        {
            try
            {
                var data = GetAll().First(x => x.ReferenceName.ToUpper() == name);

                return data ?? new ProductReference();
            }
            catch (Exception)
            {
                return new ProductReference();
            }
        }
    }
}