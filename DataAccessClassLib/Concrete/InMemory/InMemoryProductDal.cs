using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using ClassLibEntities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Concrete.InMemory
{
    public class InMemoryProductDal : IProductDal
    {
        List<Product> _products;
        public InMemoryProductDal()
        {
            // BU verilerin her hangi bir veri tabanindan geldigini farz ederek calisacagiz.
            _products = new List<Product> {
                new Product{ProductId=1, ProductName="Bardak", UnitPrice=15, CategoryId=1,UnitsInStock=15,},
                new Product{ProductId=2, ProductName="Kamera", UnitPrice=500, CategoryId=1,UnitsInStock=3,},
                new Product{ProductId=3, ProductName="Telefon", UnitPrice=1500, CategoryId=2,UnitsInStock=2,},
                new Product{ProductId=4, ProductName="Klavye", UnitPrice=150, CategoryId=2,UnitsInStock=65,},
                new Product{ProductId=5, ProductName="Fare", UnitPrice=85, CategoryId=2,UnitsInStock=1,},
            };

        }
        public void Add(Product product)
        {
            _products.Add(product);
        }
        public void Delete(Product product)
        {
            // LINQ: Language Integrated Query
            Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            _products.Remove(productToDelete);    
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            Product productToGet = _products.AsQueryable().SingleOrDefault(filter);
            return productToGet;
        }

         public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            return _products;
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
        {
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId);
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitsInStock = product.UnitsInStock;

        }

    }
}
