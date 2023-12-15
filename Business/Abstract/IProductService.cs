using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IProductService
    {
        List<Product> GetAll();
        List<Product> GetAllByCategoryId(int id);//category idsine göre getiren kod
        List<Product> GetByUnitPrice(decimal min, decimal max);
    }
}
