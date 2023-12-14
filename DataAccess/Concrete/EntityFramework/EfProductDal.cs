using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : IProductDal
    {
        public void Add(Product entity)
        {
            //IDispossable pattern implementation of c#
            using (NorthwindContext context = new NorthwindContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala 
                addedEntity.State = EntityState.Added;// eklenecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve ekle
            }
        }

        public void Delete(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala 
                deletedEntity.State = EntityState.Deleted;// silinecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve sil
            }
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            //tek data getirir
            using (NorthwindContext context = new NorthwindContext())
            {
                return context.Set<Product>().SingleOrDefault(filter);
            }
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            //birden cok data için
            using (NorthwindContext context = new NorthwindContext())
            {
                return filter == null ? context.Set<Product>().ToList() : context.Set<Product>().Where(filter).ToList(); //Eğer filtre null ise select * from products çalıştır ve listeye ata eğer filtre null değilse filtreleyip listele
            }
        }

        public void Update(Product entity)
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                var updatedEntity = context.Entry(entity);//referansı yakala 
                updatedEntity.State = EntityState.Modified;// güncellenecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve güncelle
            }
        }
    }
}
