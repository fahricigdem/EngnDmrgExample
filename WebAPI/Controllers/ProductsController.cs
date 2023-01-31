using ClassLibBusiness.Abstract;
using ClassLibBusiness.Concrete;
using ClassLibDataAccess.Concrete.EntityFramework;
using ClassLibEntities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // Loosely coupled, bagimli ama soyut'a bagimli, yani manager'i degistirirsek yine de calisir. genel olarak bir katman diger katmanin somut class'ini kullanmamali.
        // Burada IProductService injection'i yapildi burada
        // IoC Container -- Inversion of Control
        IProductService _productService;
        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get() 
        {
            //Dependency chain -- product service'e bagimliyiz burada
            var result = _productService.GetAll();
            return result.Data;
        }
    }
}
