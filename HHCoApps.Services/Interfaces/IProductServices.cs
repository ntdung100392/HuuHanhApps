using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using HHCoApps.Core.EF;

namespace HHCoApps.Services.Interfaces
{
    public interface IProductServices
    {
        IEnumerable<Product> GetAllProductBySupplier(Guid supplierId);
        IEnumerable<Product> GetProductsOrderByIssuedDate();
    }
}
