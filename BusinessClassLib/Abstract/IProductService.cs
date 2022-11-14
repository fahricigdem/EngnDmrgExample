using ClassLibEntities.Concrete;
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
    }
}
