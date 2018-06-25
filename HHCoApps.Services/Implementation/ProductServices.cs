using AutoMapper;
using HHCoApps.Core.EF;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using HHCoApps.Services.Repos;
using HHCoApps.Services.Repos.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HHCoApps.Core;

namespace HHCoApps.Services.Implementation
{
    public class ProductServices : BaseServices, IProductServices, ICategoryServices
    {
        private readonly IRepository<Product> productRepository;
        private readonly IRepository<Category> categoryRepository;
        public ProductServices()
        {
            productRepository = new Repository<Product>(dbContext);
            categoryRepository = new Repository<Category>(dbContext);
        }

        public IEnumerable<Product> GetAllProductBySupplier(Guid supplierId)
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetAllProductBySupplier(supplierId, context.Products).ToList();
            }
        }

        internal IEnumerable<Product> GetAllProductBySupplier(Guid supplierId, IQueryable<Product> products)
        {
            return products.Where(p => p.SupplierId == supplierId && p.IsActive && !p.IsDeleted);
        }

        public IEnumerable<ProductModel> GetProducts()
        {
            try
            {
                var data = productRepository.GetAll()
                    .Where(p => p.IsActive && !p.IsDeleted).OrderByDescending(p => p.IssuedDate).ToList();
                if (data != null && data.Count() != 0)
                    return data.Select(p => Mapper.Map<Product, ProductModel>(p));
                return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            try
            {
                var data = categoryRepository.GetAll();
                if (data.Any())
                    return data.ToList().Select(c => Mapper.Map<Category, CategoryModel>(c));
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public CategoryModel GetCategoryById(int categoryId)
        {
            try
            {
                var entity = categoryRepository.GetById(categoryId);
                if (entity != null)
                    return Mapper.Map<Category, CategoryModel>(entity);
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        public bool CheckDuplicateCategory(string categoryName)
        {
            try
            {
                var entity = categoryRepository.GetAll().Where(c => c.Name == categoryName).FirstOrDefault();
                if (entity != null)
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return true;
            }
        }

        public bool AddCategory(CategoryModel model)
        {
            try
            {
                var entity = Mapper.Map<CategoryModel, Category>(model);
                categoryRepository.Insert(entity);
                SaveChanges();
                _logger.Info($"New Category has been added by {Thread.CurrentPrincipal.Identity.Name}: {model.Name}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        public bool UpdateCategory(CategoryModel model)
        {
            try
            {
                var entity = categoryRepository.GetById(model.Id);
                entity.Name = model.Name;
                entity.Code = model.Code;
                categoryRepository.Update(entity);
                SaveChanges();
                if (Thread.CurrentPrincipal != null)
                    _logger.Info(string.Format("Category has been updated by {0}: {1}",
                        Thread.CurrentPrincipal.Identity.Name, model.Name));
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
    }
}
