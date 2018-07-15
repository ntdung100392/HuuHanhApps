using System;
using System.Collections.Generic;
using HHCoApps.Core;

namespace HHCoApps.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetProductsOrderByIssuedDate();
        IEnumerable<Product> GetProductsBySupplierId(int supplierId);
        int DeleteProductsByUniqueIds(IEnumerable<int> productUniqueIds);
        IEnumerable<Product> GetProducts();
        int AddProduct(Product model);
        int UpdateProductByUniqueId(Product model);
    }
}