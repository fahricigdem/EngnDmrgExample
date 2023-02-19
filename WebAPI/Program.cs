using Autofac;
using Autofac.Extensions.DependencyInjection;
using ClassLibBusiness.Abstract;
using ClassLibBusiness.Concrete;
using ClassLibBusiness.DependencyResolvers.Autofac;
using ClassLibDataAccess.Abstract;
using ClassLibDataAccess.Concrete.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Autofac, Ninject, CastleWindsor, StructoreMap, LightInject, DryInject --> IoC Container gibi islem yapan eski sistemler
//AOP (Aspect Oriented Programming)
//Postsharp
// ProductManager de IProductDal'a bagimlidir, constructor'inda, dolayisiyla o noktada ihtiyac duyuldugundan collection'a IProductDal icin EFProductDal verilir. Eger InMemoryProductDal kullanilmasi gerekirse ne olacak ???
builder.Services.AddControllers();
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EFProductDal>();
builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
builder.Host.ConfigureContainer<ContainerBuilder>(builder =>
{
    builder.RegisterModule(new AutofacBusinessModule());
});
//builder.Services.AddSingleton<IProductService, ProductManager>();
//builder.Services.AddSingleton<IProductDal, EFProductDal>(); 

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
