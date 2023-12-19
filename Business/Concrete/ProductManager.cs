using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public IResult Add(Product product)
        {
            //business codes

            if (product.ProductName.Length < 2)
            {
                //magic strings
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _productDal.Add(product);
            return new Result(true, Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            //business codes           
            //Yetkisi var mıı
            return new DataResult<List<Product>>(_productDal.GetAll(),true,"Ürünler listelendi");
        }

        public IDataResult<List<Product>> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public IDataResult<Product> GetById(int productId)
        {
            return _productDal.Get(p => p.ProductId == productId);
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);//iki fiyat aralığındaki datayı getirir
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return _productDal.GetProductDetails();
        }
    }
}
