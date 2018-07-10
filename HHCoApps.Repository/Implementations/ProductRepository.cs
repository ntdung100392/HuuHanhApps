using HHCoApps.Core;
using HHCoApps.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace HHCoApps.Repository.Implementations
{
    internal  class ProductRepository : IProductRepository
    {
        private const string SQL_CONNECTION_STRING = "HHCoApps";
        private const string PRODUCT_TABLE_NAME = "dbo.Products";

        public IEnumerable<Product> GetProductsOrderByIssuedDate()
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetProductsOrderByIssuedDate(context.Products).ToList();
            }
        }

        internal IQueryable<Product> GetProductsOrderByIssuedDate(IQueryable<Product> products)
        {
            return products.Where(p => p.IsActive && !p.IsDeleted).OrderByDescending(p => p.IssuedDate);
        }

        public IEnumerable<Product> GetProductsBySupplierId(Guid supplierUniqueId)
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetProductsBySupplierId(context.Products, supplierUniqueId).ToList();
            }
        }

        internal IQueryable<Product> GetProductsBySupplierId(IQueryable<Product> products, Guid supplierUniqueId)
        {
            return products.Where(p => p.SupplierId == supplierUniqueId && p.IsActive && !p.IsDeleted);
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetProducts(context.Products).ToList();
            }
        }

        internal IQueryable<Product> GetProducts(IQueryable<Product> products)
        {
            return products.Where(p => !p.IsDeleted);
        }

        public int AddProduct(Product entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new ArgumentNullException(nameof(entity.Name));

            if (entity.Id == null || entity.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(entity.Id));

            var keyName = new[]
            {
                "Name"
            };
            var parameters = new
            {
                entity.BasePrice,
                entity.CategoryId,
                entity.ExpiredDate,
                entity.IssuedDate,
                entity.IsActive,
                entity.IsDeleted,
                entity.Name,
                entity.ProductCode,
                entity.Status,
                entity.Stock,
                entity.SupplierId,
                CreatedDate = DateTime.Now,
                CreatedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int UpdateProductByUniqueIds(Product entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new ArgumentNullException(nameof(entity.Name));

            if (entity.Id == null || entity.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(entity.Id));

            var keyName = new[]
            {
                "Id"
            };

            var parameters = new
            {
                entity.BasePrice,
                entity.CategoryId,
                entity.ExpiredDate,
                entity.IssuedDate,
                entity.IsActive,
                entity.IsDeleted,
                entity.Name,
                entity.ProductCode,
                entity.Status,
                entity.Stock,
                entity.SupplierId,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int DeleteProductsByUniqueIds(IEnumerable<Guid> productUniqueIds)
        {
            if (!productUniqueIds.Any())
                throw new ArgumentNullException(nameof(productUniqueIds));

            var parameter = new
            {
                ProductCode = string.Empty,
                IsActive = false,
                IsDeleted = true,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = productUniqueIds.Select(x => x.ToString());

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameter, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }
    }
}
