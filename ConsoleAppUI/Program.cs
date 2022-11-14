// See https://aka.ms/new-console-template for more information
using ClassLibBusiness.Concrete;
using ClassLibDataAccess.Concrete.EntityFramework;
using ClassLibDataAccess.Concrete.InMemory;
using ClassLibEntities.Concrete;

Console.WriteLine("Hello, World!");


ProductManager productManager = new ProductManager(new InMemoryProductDal());

List<Product> products = productManager.GetAll();
foreach (Product product in products) Console.WriteLine(product.ProductName);


ProductManager productManager1 = new ProductManager(new EFProductDal());
foreach (var item in productManager1.GetAll()) Console.WriteLine(item.ProductName);