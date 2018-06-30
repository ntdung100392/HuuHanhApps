using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Ninject;

namespace HHCoApps.Services.Implementation
{
    internal class ProductServices : IProductServices
    {
        private ICategoryServices _categoryServices;

        public ProductServices(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        public IEnumerable<ProductModel> GetAllProductBySupplier(Guid supplierId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProductsOrderByIssuedDate()
        {
            throw new NotImplementedException();
        }
    }
}
