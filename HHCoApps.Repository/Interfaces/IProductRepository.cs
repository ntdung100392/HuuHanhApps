using System;
using System.Collections.Generic;
using HHCoApps.Core.EF;

namespace HHCoApps.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsOrderByIssuedDate();
        IEnumerable<Product> GetProductsBySupplierId(Guid supplierUniqueId);
        int DeleteProductsByUniqueIds(IEnumerable<Guid> productUniqueIds);
        IEnumerable<Product> GetProducts();
        int AddProduct(Product model);
        int UpdateProductByUniqueIds(Product model);
    }
}