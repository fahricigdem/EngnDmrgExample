using ClassLibBusiness.Abstract;
using ClassLibBusiness.Concrete;
using ClassLibDataAccess.Abstract;
using ClassLibDataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductManager>();
builder.Services.AddSingleton<IProductDal, EFProductDal>(); // ProductManager de IProductDal'a bagimlidir, constructor'inda, dolayisiyla o noktada ihtiyac duyuldugundan collection'a IProductDal icin EFProductDal verilir. Eger InMemoryProductDal kullanilmasi gerekirse ne olacak ???

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
