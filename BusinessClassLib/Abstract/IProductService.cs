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
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);
        List<Product> GetAllByUnitPrice(decimal min, decimal max);
        Product GetById(int id);
        List<ProductDetailDto> GetProductDetails();

        IResult Add(Product product);
    }
}
