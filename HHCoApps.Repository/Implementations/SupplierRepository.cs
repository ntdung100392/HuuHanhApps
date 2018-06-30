using HHCoApps.Core;
using HHCoApps.Core.EF;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace HHCoApps.Repository.Implementations
{
    internal class SupplierRepository : ISupplierRepository
    {
        private readonly string SQL_CONNECTION_STRING = ConfigurationManager.ConnectionStrings["HHCoApps"].ConnectionString;
        private readonly string SUPPLIER_TABLE_NAME = "dbo.Suppliers";

        public IEnumerable<Supplier> GetSuppliers()
        {
            using (var context = new HHCoAppsDBContext())
            {
                return GetAllSuppliers(context.Suppliers).ToList();
            }
        }

        internal IEnumerable<Supplier> GetAllSuppliers(IQueryable<Supplier> suppliers)
        {
            return suppliers.Where(s => !s.IsDeleted).OrderBy(s => s.CompanyName);
        }

        public int AddNewSupplier(Supplier model)
        {
            var parameter = new
            {
                model.CompanyName,
                model.Address,
                model.DirectorName,
                model.Email,
                model.Fax,
                model.HomeTown,
                Id = Guid.NewGuid(),
                IsActive = true,
                model.Note,
                model.Phone,
                model.TaxCode,
                IsDeleted = false,
                CreatedDate = DateTime.Now,
                CreatedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "CompanyName"
            };

            return DapperRepositoryUtil.InsertIfNotExist(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);
        }

        public int UpdateSupplier(Supplier model)
        {
            if(string.IsNullOrEmpty(model.CompanyName))
                throw new ArgumentNullException(nameof(model.CompanyName));

            if (model.Id == null || model.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(model.Id));

            var parameter = new
            {
                model.CompanyName,
                model.Address,
                model.DirectorName,
                model.Email,
                model.Fax,
                model.HomeTown,
                model.Id,
                model.IsActive,
                model.Note,
                model.Phone,
                model.TaxCode,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "Id"
            };

            return DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);
        }

        public int DeleteSupplier(Supplier model)
        {
            var parameter = new
            {
                IsDeleted = true,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "Id"
            };

            return DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);
        }

        internal Supplier GetSupplierByCompanyName(string companyName, IQueryable<Supplier> suppliers)
        {
            return suppliers.FirstOrDefault(s => s.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
