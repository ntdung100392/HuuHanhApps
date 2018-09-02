using HHCoApps.Core;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;

namespace HHCoApps.Repository.Implementations
{
    internal  class ProductRepository : IProductRepository
    {
        private const string SQL_CONNECTION_STRING = "HHCoApps";
        private const string PRODUCT_TABLE_NAME = "dbo.Product";

        public IEnumerable<Product> GetProductsOrderByIssuedDate()
        {
            using (var context = new HHCoAppsEntities())
            {
                return GetProductsOrderByIssuedDate(context.Products).ToList();
            }
        }

        internal IQueryable<Product> GetProductsOrderByIssuedDate(IQueryable<Product> products)
        {
            return products.Where(p => !p.IsDeleted).OrderByDescending(p => p.IssuedDate).Include(p => p.Supplier).Include(p => p.Category);
        }

        public IEnumerable<Product> GetProductsBySupplierId(int supplierId)
        {
            using (var context = new HHCoAppsEntities())
            {
                return GetProductsBySupplierId(context.Products, supplierId).ToList();
            }
        }

        internal IQueryable<Product> GetProductsBySupplierId(IQueryable<Product> products, int supplierId)
        {
            return products.Where(p => p.SupplierId == supplierId && p.IsActive && !p.IsDeleted);
        }

        public IEnumerable<Product> GetProducts()
        {
            using (var context = new HHCoAppsEntities())
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

            var keyName = new[]
            {
                "Name"
            };
            var parameters = new
            {
                entity.BaseCost,
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
                entity.InputCost
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int UpdateProductByUniqueId(Product entity)
        {
            if (string.IsNullOrEmpty(entity.Name))
                throw new ArgumentNullException(nameof(entity.Name));

            var keyName = new[]
            {
                "Id"
            };

            var parameters = new
            {
                entity.BaseCost,
                entity.CategoryId,
                entity.ExpiredDate,
                entity.IssuedDate,
                entity.IsActive,
                entity.Name,
                entity.ProductCode,
                entity.Status,
                entity.Stock,
                entity.SupplierId,
                entity.Id
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int DeleteProductsByUniqueIds(IEnumerable<int> productUniqueIds)
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

            var rowAffected = 0;
            foreach (var productUniqueId in productUniqueIds)
            {
                rowAffected =+ DapperRepositoryUtil.UpdateRecordInTable(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), "Id", productUniqueId, parameter);
            }

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int UpdateProductQuantityByProductId(int productId, int quantity)
        {
            if (productId >= 0 || quantity == 0)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            var keyName = new[]
            {
                "Id"
            };

            var parameters = new
            {
                Stock = quantity,
                Id = productId
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameters, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }
    }
}
