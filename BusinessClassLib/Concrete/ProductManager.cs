using ClassLibBusiness.Abstract;
using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibBusiness.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal; 
        }
        public List<Product> GetAll()
        {
            //Here comes Business code, and then codes blow
            return _productDal.GetAll();
        }
    }
}
