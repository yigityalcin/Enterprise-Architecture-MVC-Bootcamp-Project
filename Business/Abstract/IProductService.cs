using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IProductService
    {
        List<Product> GetAll();//product list döndürüyor
        List<Product> GetAllByCategoryId(int id);//category idsine göre getiren kod
        List<Product> GetByUnitPrice(decimal min, decimal max);
        List<ProductDetailDto> GetProductDetails();//list of product detail
        Product GetById(int productId);//single product döndürür.
        IResult Add(Product product);//herhangi bir şey döndürmüyor (void).

    }
}
