using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HHCoApps.Core;
using HHCoApps.Core.EF;

namespace HHCoApps.Repository.Implementations
{
    internal class CategoryRepository : ICategoryRepository
    {
        private readonly string SQL_CONNECTION_STRING = "HHCoApps";
        private readonly string TABLE_NAME = "dbo.Categories";

        public IEnumerable<Category> GetCategories()
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetCategories(context.Categories).ToList();
            }
        }

        internal IQueryable<Category> GetCategories(IQueryable<Category> categories)
        {
            return categories.OrderBy(c => c.Code);
        }

        public Category GetCategoryById(int categoryId)
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetCategoryById(categoryId, context.Categories);
            }
        }

        internal Category GetCategoryById(int categoryId, IQueryable<Category> categories)
        {
            return categories.FirstOrDefault(c => c.Id == categoryId);
        }

        public int AddNewCategory(Category entity)
        {
            if(string.IsNullOrEmpty(entity.Name))
                throw new ArgumentNullException(nameof(entity.Name));

            if (string.IsNullOrEmpty(entity.Code))
                throw new ArgumentNullException(nameof(entity.Code));

            var keyName = new[]
            {
                "Name"
            };
            var parameters = new
            {
                entity.Code,
                entity.Name,
                CreatedDate = DateTime.Now,
                CreatedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if(rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int UpdateCategoryById(Category entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new ArgumentNullException(nameof(entity.Name));

            if (string.IsNullOrEmpty(entity.Code))
                throw new ArgumentNullException(nameof(entity.Code));

            var keyName = new[]
            {
                "Id"
            };
            var parameters = new
            {
                entity.Code,
                entity.Name,
                ModifiedBy = DateTime.Now,
                ModifiedDate = Thread.CurrentPrincipal.Identity.Name
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }
    }
}