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
        IDataResult<List<Product>> GetAll(); //IDataResulttaki generic T'miz Product. List of product.
        IDataResult<List<Product>> GetAllByCategoryId(int id); //category idsine göre getiren kod
        IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max);
        IDataResult<List<ProductDetailDto>> GetProductDetails(); //list of product detail
        IDataResult<Product> GetById(int productId); //single product döndürür.
        IResult Add(Product product); //herhangi bir şey döndürmüyor (void).
        IResult Update(Product product);


    }
}
