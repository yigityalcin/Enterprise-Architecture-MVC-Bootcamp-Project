using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfProductDal : EfEntityRepositoryBase<Product, NorthwindContext>, IProductDal
    {
        public List<ProductDetailDto> GetProductDetails()
        {
            using (NorthwindContext context = new NorthwindContext())
            {
                //IQueryable -- döngü türü
                var result = from p in context.Products //Productslarla p Categorileri c sql join et
                             join c in context.Categories
                             on p.CategoryId equals c.CategoryId //p'deki categ id ile c'deki categ id eşitse bunları join et
                             select new ProductDetailDto //sonucu bu kolonlara uydurarak ver
                             {
                                 ProductId = p.ProductId,
                                 ProductName = p.ProductName,
                                 CategoryName = c.CategoryName,
                                 UnitsInStock = p.UnitsInStock
                             };
                return result.ToList();//dönen sonuçu listele
                             
            }
        }
    }
}
