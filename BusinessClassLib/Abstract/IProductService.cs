using ClassLibEntities.Concrete;
using ClassLibEntities.DTOs;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibBusiness.Abstract
{
    public interface IProductService
    {
        IDataResult<List<Product>> GetAll();
        IDataResult<List<Product>> GetAllByCategoryId(int id);
        IDataResult<List<Product>> GetAllByUnitPrice(decimal min, decimal max);
        IDataResult<Product> GetById(int id);
        IDataResult<List<ProductDetailDto>>  GetProductDetails();
        IResult Add(Product product);
    }
}
