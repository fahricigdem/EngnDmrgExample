using Autofac;
using Autofac.Core;
using Autofac.Extensions.DependencyInjection;
using ClassLibBusiness.Abstract;
using ClassLibBusiness.Concrete;
using ClassLibBusiness.DependencyResolvers.Autofac;
using ClassLibDataAccess.Abstract;
using ClassLibDataAccess.Concrete.EntityFramework;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

//Autofac, Ninject, CastleWindsor, StructoreMap, LightInject, DryInject --> IoC Container gibi islem yapan eski sistemler
//AOP (Aspect Oriented Programming)
//Postsharp
// ProductManager de IProductDal'a bagimlidir, constructor'inda, dolayisiyla o noktada ihtiyac duyuldugundan collection'a IProductDal icin EFProductDal verilir. Eger InMemoryProductDal kullanilmasi gerekirse ne olacak ???
builder.Services.AddControllers();
builder.Services.AddCors();


//builder.Services.AddDependencyResolvers(new ICoreModule[]
//{
//    new CoreModule()
//}); ;

//builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

ConfigurationManager Configuration = builder.Configuration; // allows both to access and to set up the config
//IWebHostEnvironment environment = builder.Environment;

var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidIssuer = tokenOptions.Issuer,
            ValidAudience = tokenOptions.Audience,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)
        };
    });

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

app.ConfigureCustomExceptionMiddleware();

// Configure the HTTP request pipeline.

//app.UseCors(x => x
//    .SetIsOriginAllowed(origin => true) // allow any origin
//    );
app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());


app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();




app.MapControllers();

app.Run();
