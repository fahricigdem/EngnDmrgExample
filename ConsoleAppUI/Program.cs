// See https://aka.ms/new-console-template for more information
using ClassLibBusiness.Concrete;
using ClassLibDataAccess.Concrete.EntityFramework;
using ClassLibDataAccess.Concrete.InMemory;
using ClassLibEntities.Concrete;

Console.WriteLine("Hello, World!");



#region
// burada Business Layer kullanilmadi direk business yapildi. DAL'daki concrete classlar kullanildi.
InMemoryProductDal inMemoryProductDal = new();

//Console.WriteLine(inMemoryProductDal.GetAll().Count);

EFProductDal eFProductDal = new();

//Console.WriteLine(eFProductDal.GetAll().Count);
#endregion

#region
//burada ise business layer kullanildi. DAL'daki soyut class kullanildi. Hangi tür bir Data Access kullanilacagi soyut birakildi.
//ProductManager productManager = new ProductManager(new InMemoryProductDal());

//List<Product> products = productManager.GetAll();

//foreach (Product product in products) Console.WriteLine(product.ProductName);

ProductManager productManager1 = new ProductManager(new EFProductDal());

//foreach (var item in productManager1.GetAll()) Console.WriteLine(item.ProductName);
//foreach (var item in productManager1.GetAllByCategoryId(1)) Console.WriteLine(item.ProductName);
//foreach (var item in productManager1.GetAllByUnitPrice(15, 25)) Console.WriteLine(item.ProductName + " - " +item.UnitPrice);
//Console.WriteLine("Id: 2 ->" + productManager1.GetById(2).ProductName);
//Console.WriteLine("Id: 2 ->" + productManager1.GetById(2).CategoryId);

CategoryManager categoryManager = new CategoryManager(new EFCategoryDal());
//foreach (var item in categoryManager.GetAll()) Console.WriteLine(item.CategoryId + " " + item.CategoryName);
var result = productManager1.GetProductDetails();
if (result.Success) 
{
    foreach (var item in productManager1.GetProductDetails().Data) Console.WriteLine(item.ProductName + " " + item.CategoryName);
}
else
{
    Console.WriteLine(result.Message);
}


#endregion

#region direkt DbConntext is usued

NorthwindContext context = new();
//var x = context.Set<Product>().ToList();
//var y = x.Where(x => x.ProductId == 1).ToList();
//Console.WriteLine(y[0].ProductName);

//context.Set<Product>().ToList().ForEach(product => Console.WriteLine(product.ProductName));

//(new NorthwindContext()).Set<Product>().ToList().ForEach(
//        product => Console.WriteLine(product.ProductName)
//    );

var xx = (new NorthwindContext()).Set<Product>().ToList();

#endregion