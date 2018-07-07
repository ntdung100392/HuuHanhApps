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

        public int AddProduct(Product model)
        {
            if (string.IsNullOrEmpty(model.Name))
                throw new ArgumentNullException(nameof(model.Name));

            if (model.Id == null || model.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(model.Id));

            var keyName = new[]
            {
                "Name"
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(PRODUCT_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), model, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int DeleteProductsByUniqueIds(IEnumerable<Guid> productUniqueIds)
        {
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
