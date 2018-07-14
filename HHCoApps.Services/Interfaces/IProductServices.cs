using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;

namespace HHCoApps.Services.Interfaces
{
    public interface IProductServices
    {
        IEnumerable<ProductModel> GetAllProductBySupplier(Guid supplierId);
        IEnumerable<ProductModel> GetProductsOrderByIssuedDate();
        int AddNewProduct(ProductModel model);
        int UpdateProductByUniqueId(ProductModel model);
    }
}
