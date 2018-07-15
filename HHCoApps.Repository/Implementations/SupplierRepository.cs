using HHCoApps.Core;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace HHCoApps.Repository.Implementations
{
    internal class SupplierRepository : ISupplierRepository
    {
        private const string SQL_CONNECTION_STRING = "HHCoApps";
        private const string SUPPLIER_TABLE_NAME = "dbo.Supplier";

        public IEnumerable<Supplier> GetSuppliers()
        {
            using (var context = new HHCoAppsEntities())
            {
                return GetAllSuppliers(context.Suppliers).ToList();
            }
        }

        internal IQueryable<Supplier> GetAllSuppliers(IQueryable<Supplier> suppliers)
        {
            return suppliers.Where(s => !s.IsDeleted).OrderBy(s => s.CompanyName);
        }

        public int AddNewSupplier(Supplier model)
        {
            if (string.IsNullOrEmpty(model.CompanyName))
                throw new ArgumentNullException(nameof(model.CompanyName));

            var keyName = new[]
            {
                "CompanyName"
            };

            var parameter = new
            {
                model.CompanyName,
                model.Address,
                model.DirectorName,
                model.Email,
                model.Fax,
                model.HomeTown,
                model.Note,
                model.Phone,
                model.TaxCode
            };

            var rowAffected = DapperRepositoryUtil.InsertIfNotExist(SUPPLIER_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameter, keyName);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int UpdateSupplier(Supplier model)
        {
            if(string.IsNullOrEmpty(model.CompanyName))
                throw new ArgumentNullException(nameof(model.CompanyName));

            var parameter = new
            {
                model.CompanyName,
                model.Address,
                model.DirectorName,
                model.Email,
                model.Fax,
                model.HomeTown,
                model.IsActive,
                model.Note,
                model.Phone,
                model.TaxCode
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), "Id", model.Id, parameter, true);

            if (rowAffected < 1)
                throw new ArgumentException("Đã Có Lỗi Xảy Ra!");

            return rowAffected;
        }

        public int DeleteSupplier(Supplier entity)
        {
            var parameter = new
            {
                IsDeleted = true,
                entity.Id,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "Id"
            };

            var rowAffected = DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, DbUtilities.GetConnString(SQL_CONNECTION_STRING), parameter, keyName);

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
