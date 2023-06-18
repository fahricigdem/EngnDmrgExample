using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibBusiness.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";
        public static string ProductNameInvalid = "Ürün ismi gecersiz";
        public static string MaintenanceTime = "Bakim Zamani";
        public static string ProductsListed = "Ürünler listelendi";
        public static string ProductCountOfCategoryError = "Kategorideki product sayisi hatali";
        public static string ProductNameAlreadyExists = "Bu isimde zaten baska bir ürün var";
        public static string CategoryLimitExceeded = "Kategori limiti asildi";
        public static string AuthorizationDenied = "Yetkiniz yok";
    }
}
