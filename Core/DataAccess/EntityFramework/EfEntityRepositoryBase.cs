using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public void Add(TEntity entity)
        {
            //IDispossable pattern implementation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);//referansı yakala 
                addedEntity.State = EntityState.Added;// eklenecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve ekle
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);//referansı yakala 
                deletedEntity.State = EntityState.Deleted;// silinecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve sil
            }
        }

        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            //tek data getirir
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            //birden cok data için
            using (TContext context = new TContext())
            {
                return filter == null 
                    ? context.Set<TEntity>().ToList() 
                    : context.Set<TEntity>().Where(filter).ToList(); 
                //Eğer filtre null ise select * from products çalıştır ve listeye ata eğer filtre null değilse filtreleyip listele
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);//referansı yakala 
                updatedEntity.State = EntityState.Modified;// güncellenecek bir nesne oldugunu setle
                context.SaveChanges(); // hepsini gerceklestir ve güncelle
            }
        }
    }
}
