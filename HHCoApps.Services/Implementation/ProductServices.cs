using HHCoApps.Repository;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HHCoApps.Core;

namespace HHCoApps.Services.Implementation
{
    internal class ProductServices : IProductServices
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryServices _categoryServices;

        public ProductServices(IProductRepository productRepository, ICategoryServices categoryServices)
        {
            _productRepository = productRepository;
            _categoryServices = categoryServices;
        }

        public IEnumerable<ProductModel> GetAllProductBySupplier(Guid supplierId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ProductModel> GetProductsOrderByIssuedDate()
        {
            var products = _productRepository.GetProductsOrderByIssuedDate();
            return products.Any() ? products.Select(Mapper.Map<ProductModel>).ToList() : Enumerable.Empty<ProductModel>();
        }

        public int AddNewProduct(ProductModel model)
        {
            var entity = Mapper.Map<Product>(model);
            entity.ProductCode = CalculateProductCode();
            return _productRepository.AddProduct(entity);
        }

        public int UpdateProductByUniqueId(ProductModel model)
        {
            var entity = Mapper.Map<Product>(model);
            return _productRepository.UpdateProductByUniqueId(entity);
        }

        private string CalculateProductCode()
        {
            var products = _productRepository.GetProducts();
            if (!products.Any())
                return "SP1";

            var productsCount = products.Count();
            return $"SP{productsCount}";
        }

        public IEnumerable<ProductModel> GetAllProduct()
        {
            return _productRepository.GetProducts().Select(Mapper.Map<ProductModel>).ToList();
        }

        public void UpdateProductStock(int productId, int quantity)
        {

        }
    }
}
