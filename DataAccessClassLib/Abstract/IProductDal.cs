// Data Acccess Layer
// Veri tabaninda Product ile ilgili yapilacak islemler, CRUD operasyonlari.
// Product class'ini burada kull icin bu class'i barindiran proje bu projeye eklenir, referans olarak. Dependency olarak.
// Ayni projedeki diger bir class icin using yeterlidir.
// Her is yapan class bir interface'e sahip olmalidir.
// diger class'lardan ulasilabilmesi icin public olmalidir.
// interface'in operasyonlari public'tir, ayriyeten public demeye gerek yok.
using ClassLibEntities.Concrete;
using ClassLibEntities.DTOs;
using Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Abstract
{
    public interface IProductDal:IEntityRepository<Product>
    {
        List<ProductDetailDto> GetProductDetails();

    }
}
