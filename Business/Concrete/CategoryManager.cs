using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public List<Category> GetAll()
        {
            //iş kodları eğer varsa
            return _categoryDal.GetAll();
        }

        public Category GetById(int categoryId)
        {
            return _categoryDal.Get(c=>c.CategoryId == categoryId);//veritabanı sorgusu gibi düşünebiliriz--benim gönderdiğim idye göre veritablosundaki idyi getir
        }
    }
}
