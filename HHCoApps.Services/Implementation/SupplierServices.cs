using AutoMapper;
using HHCoApps.Core;
using HHCoApps.Repository;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Transactions;

namespace HHCoApps.Services.Implementation
{
    internal class SupplierServices : ISupplierServices
    {
        private readonly ISupplierRepository _supplierRepository;
        private readonly IProductRepository _productRepository;

        public SupplierServices(ISupplierRepository supplierRepository, IProductRepository productRepository)
        {
            _supplierRepository = supplierRepository;
            _productRepository = productRepository;
        }

        public IEnumerable<SupplierModel> GetSuppliers()
        {
            var suppliers = _supplierRepository.GetSuppliers();
            return suppliers.Any() ? suppliers.Select(s => Mapper.Map<SupplierModel>(s)).ToList() : Enumerable.Empty<SupplierModel>();
        }

        public int AddNewSupplier(SupplierModel model)
        {
            var entity = Mapper.Map<Supplier>(model);
            return _supplierRepository.AddNewSupplier(entity);
        }

        public int UpdateSupplier(SupplierModel model)
        {
            var entity = Mapper.Map<Supplier>(model);
            return _supplierRepository.UpdateSupplier(entity);
        }

        public int DeleteSupplier(SupplierModel model)
        {
            var entity = Mapper.Map<Supplier>(model);
            var supplierProducts = _productRepository.GetProductsBySupplierId(entity.Id);
            int rowAffected;

            using (var transaction = new TransactionScope(TransactionScopeOption.Required, TimeSpan.FromMinutes(1)))
            {
                if (supplierProducts.Any())
                {
                    rowAffected = _productRepository.DeleteProductsByUniqueIds(supplierProducts.Select(sp => sp.Id));
                }
                rowAffected =+ _supplierRepository.DeleteSupplier(entity);
                transaction.Complete();
            }

            return rowAffected;
        }
    }
}
