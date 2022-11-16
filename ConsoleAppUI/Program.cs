// See https://aka.ms/new-console-template for more information
using ClassLibBusiness.Concrete;
using ClassLibDataAccess.Concrete.EntityFramework;
using ClassLibDataAccess.Concrete.InMemory;
using ClassLibEntities.Concrete;

Console.WriteLine("Hello, World!");



#region
// burada Business Layer kullanilmadi direk business yapildi. DAL'daki concrete classlar kullanildi.
InMemoryProductDal inMemoryProductDal = new();

Console.WriteLine(inMemoryProductDal.GetAll().Count);

EFProductDal eFProductDal = new();

Console.WriteLine(eFProductDal.GetAll().Count);
#endregion

#region
//burada ise business layer kullanildi. DAL'daki soyut class kullanildi. Hangi tür bir Data Access kullanilacagi soyut birakildi.
ProductManager productManager = new ProductManager(new InMemoryProductDal());

List<Product> products = productManager.GetAll();

foreach (Product product in products) Console.WriteLine(product.ProductName);

ProductManager productManager1 = new ProductManager(new EFProductDal());

foreach (var item in productManager1.GetAll()) Console.WriteLine(item.ProductName);
#endregion

