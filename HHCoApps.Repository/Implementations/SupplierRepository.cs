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
        private readonly string SQL_CONNECTION_STRING = "HHCoApps";
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
            if (string.IsNullOrEmpty(model.CompanyName))
                throw new ArgumentNullException(nameof(model.CompanyName));

            if (model.Id == null || model.Id == Guid.Empty)
                throw new ArgumentNullException(nameof(model.Id));

            var keyName = new[]
            {
                "CompanyName"
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(SUPPLIER_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), model, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
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

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
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

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        internal Supplier GetSupplierByCompanyName(string companyName, IQueryable<Supplier> suppliers)
        {
            return suppliers.FirstOrDefault(s => s.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }
    }
}
