﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using HHCoApps.Core;
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
            return categories.Any() ? categories.Select(Mapper.Map<CategoryModel>).ToList() : Enumerable.Empty<CategoryModel>();
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            return Mapper.Map<CategoryModel>(_categoryRepository.GetCategoryById(categoryId));
        }

        public int AddCategory(CategoryModel model)
        {
            var entity = Mapper.Map<Category>(model);
            return _categoryRepository.AddNewCategory(entity);
        }

        public int UpdateCategory(CategoryModel model)
        {
            var entity = Mapper.Map<Category>(model);
            return _categoryRepository.UpdateCategoryById(entity);
        }
    }
}
