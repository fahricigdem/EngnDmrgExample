using ClassLibBusiness.Abstract;
using ClassLibBusiness.Constants;
using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using ClassLibEntities.DTOs;
using Core.Utilities.Results;
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

        public IResult Add(Product product)
        {
            //business code
            if (product?.ProductName?.Length<2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);

            return new SuccessResult(Messages.ProductAdded);
        }

        public List<Product> GetAll()
        {
            //Here comes Business code, and then codes blow (not as DAL, DAL does only data access. Business uses DAL.)
            return _productDal.GetAll();
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }
        public List<Product> GetAllByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public Product GetById(int id)
        {
            return _productDal.Get(p=>p.ProductId==id);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
