﻿using ClassLibDataAccess.Abstract;
using ClassLibEntities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibDataAccess.Concrete.EntityFramework
{
    public class EFProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDisposable pattern implementation of C# (using icindekiler islem bittikten sonmra temizlenir)
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        } 

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            } 
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //2.10 video
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() :
                    context.Set<Product>().Where(filter).ToList();
            }

        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }  
        }
    }
}
