using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;

namespace HHCoApps.Services.Implementation
{
    internal class ImportProductServices : IImportProductServices
    {
        private readonly IProductServices _productServices;

        public ImportProductServices(IProductServices productServices)
        {
            _productServices = productServices;
        }

        public void AddImport(ImportLogModel model)
        {
            if (model.Quantity == 0)
                throw new ArgumentException("Số lượng phải lớn hơn 0!");

        }

        public IDictionary<string, int> GetAllProductModels()
        {
            var products = _productServices.GetAllProduct();
            return products.Any() ? products.ToDictionary(p => p.Name, p => p.Id) : new Dictionary<string, int>();
        }
    }
}
