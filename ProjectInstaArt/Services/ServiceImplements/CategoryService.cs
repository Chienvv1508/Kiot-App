using ProjectInstaArt.DAL.Model;
using ProjectInstaArt.Services.ServicesContracts;
using ProjectInstaArt;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServiceImplements
{
    internal class CategoryService : ICategoryService
    {
        private IUnitOfWork _unitOfWork;

        public CategoryService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void AddCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Add(category);
            _unitOfWork.Commit();
        }

        public void DeleteCategory(Category category)
        {
           _unitOfWork.CategoryRepository.Remove(category);
            _unitOfWork.Commit();
        }

        public List<Category> GetCategories()
        {
            return _unitOfWork.CategoryRepository.GetAll(x => x.IsValid == true).ToList();

        }

        public Category GetCategoryById(int id)
        {
            return _unitOfWork.CategoryRepository.Get(x => x.CategoryId == id);
        }

        public void UpdateCategory(Category category)
        {
            _unitOfWork.CategoryRepository.Update(category);
            _unitOfWork.Commit();
        }
    }
}
