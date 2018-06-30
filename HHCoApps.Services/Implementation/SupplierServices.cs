using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using HHCoApps.Core.EF;
using HHCoApps.Repository;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using Ninject;

namespace HHCoApps.Services.Implementation
{
    internal class SupplierServices : ISupplierServices
    {
        [Inject]
        private readonly ISupplierRepository _supplierRepository;

        public SupplierServices(ISupplierRepository supplierRepository)
        {
            _supplierRepository = supplierRepository;
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
            return _supplierRepository.DeleteSupplier(entity);
        }
    }
}
