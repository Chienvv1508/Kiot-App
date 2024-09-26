using ProjectInstaArt.DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectInstaArt.Services.ServicesContracts
{
    internal interface ICategoryService
    {
        List<Category> GetCategories();
        Category GetCategoryById(int id);

        void AddCategory(Category category);

        void UpdateCategory(Category category);

        void DeleteCategory(Category category);
        
    }
}
