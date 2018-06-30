using System;
using System.Collections.Generic;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;

namespace HHCoApps.Services.Implementation
{
    internal class CategoryServices : ICategoryServices
    {
        public IEnumerable<CategoryModel> GetCategories()
        {
            throw new NotImplementedException();
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            throw new NotImplementedException();
        }

        public bool CheckDuplicateCategory(string categoryName)
        {
            throw new NotImplementedException();
        }

        public bool AddCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }

        public bool UpdateCategory(CategoryModel model)
        {
            throw new NotImplementedException();
        }
    }
}
