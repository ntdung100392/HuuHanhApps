using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using HHCoApps.Core.EF;
using HHCoApps.Repository;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;

namespace HHCoApps.Services.Implementation
{
    internal class CategoryServices : ICategoryServices
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryServices(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            var categories = _categoryRepository.GetCategories();
            return categories.Any() ? categories.Select(c => Mapper.Map<CategoryModel>(c)).ToList() : Enumerable.Empty<CategoryModel>();
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            return Mapper.Map<CategoryModel>(_categoryRepository.GetCategoryById(categoryId));
        }

        public int AddCategory(CategoryModel model)
        {
            var entity = Mapper.Map<Category>(model);
            entity.CreatedBy = Thread.CurrentPrincipal.Identity.Name;
            entity.CreatedDate = DateTime.Now;;
            return _categoryRepository.AddNewCategory(entity);
        }

        public int UpdateCategory(CategoryModel model)
        {
            var entity = Mapper.Map<Category>(model);
            entity.ModifiedBy = Thread.CurrentPrincipal.Identity.Name;
            entity.ModifiedDate = DateTime.Now;
            return _categoryRepository.UpdateCategoryById(entity);
        }
    }
}
