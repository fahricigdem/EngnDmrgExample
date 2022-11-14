using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {
        public void Add(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(Product product)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll()
        {
            return new List<Product> { 
                new Product { ProductName = "EF item1" },
                new Product { ProductName = "EF item2" } 
            };
        }

        public List<Product> GetAllByCategory(int CategoryId)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
