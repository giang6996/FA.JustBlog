using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core
{
    public class CategoryService : ICategoryService
    {
        public IUnitOfWork _unitOfWork;
        

        public CategoryService(IUnitOfWork unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        public Category Find(int id)
        {
            return _unitOfWork.CategoryRepository.Find(id);
        }

        public Category FindByName(string name)
        {
            return _unitOfWork.CategoryRepository.GetByName(name);
        }

        public void Add(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public void Update(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();
        }

        public void Delete(Category category)
        {
            _unitOfWork.CategoryRepository.Delete(category);
            _unitOfWork.Commit();
        }

        public void Delete(int id)
        {
            _unitOfWork.CategoryRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public IList<Category> GetAll()
        {
            return _unitOfWork.CategoryRepository.GetAll();
        }
    }
}
