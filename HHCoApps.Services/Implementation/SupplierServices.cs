using HHCoApps.Core;
using HHCoApps.Core.EF;
using HHCoApps.Services.DapperRepository;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

namespace HHCoApps.Services.Implementation
{
    public class SupplierServices : ISupplierServices
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

        public int AddNewSupplier(SupplierModel model)
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

        public int UpdateSupplier(SupplierModel model)
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
                model.IsActive,
                model.Note,
                model.Phone,
                model.TaxCode,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "CompanyName"
            };

            return DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);
        }

        public int DeleteSupplier(SupplierModel model)
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
                IsActive = false,
                model.Note,
                model.Phone,
                model.TaxCode,
                IsDeleted = true,
                ModifiedDate = DateTime.Now,
                ModifiedBy = Thread.CurrentPrincipal.Identity.Name
            };

            var keyName = new[]
            {
                "CompanyName"
            };

            return DapperRepositoryUtil.UpdateRecordInTable(SUPPLIER_TABLE_NAME, SQL_CONNECTION_STRING, parameter, keyName);
        }

        internal Supplier GetSupplierByCompanyName(string companyName, IQueryable<Supplier> suppliers)
        {
            return suppliers.FirstOrDefault(s => s.CompanyName.Equals(companyName, StringComparison.OrdinalIgnoreCase));
        }

        ///// <summary>
        ///// Update supplier
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public bool UpdateSupplier(SupplierModel model)
        //{
        //    try
        //    {
        //        var entity = supplierRepository.GetById(model.Id);
        //        entity.IsActive = model.IsActive;
        //        entity.Note = model.Note;
        //        entity.TaxCode = model.TaxCode;
        //        entity.HomeTown = model.HomeTown;
        //        entity.Fax = model.Fax;
        //        entity.Email = model.Email;
        //        entity.DirectorName = model.DirectorName;
        //        entity.CompanyName = model.CompanyName;
        //        entity.Address = model.Address;
        //        supplierRepository.Update(entity);
        //        SaveChanges();
        //        _logger.Info(string.Format("Supplier {0} has been updated by {1}", model.CompanyName, Thread.CurrentPrincipal.Identity.Name));
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.Error(ex.Message);
        //        return false;
        //    }
        //}

        ///// <summary>
        ///// Delete supplier
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public bool DeleteSupplier(SupplierModel model)
        //{
        //    try
        //    {
        //        using (var scope = new TransactionScope())
        //        {
        //            var entity = supplierRepository.GetById(model.Id);
        //            entity.IsActive = false;
        //            entity.IsDeleted = true;
        //            supplierRepository.Update(entity);
        //            this.SaveChanges();
        //            scope.Complete();
        //        }

        //        _logger.Info(string.Format("Supplier {0} has been deleted by {1}", model.CompanyName, Thread.CurrentPrincipal.Identity.Name));
        //        return true;
        //    }
        //    catch (TransactionException ex)
        //    {
        //        _logger.Error(ex.Message);
        //        return false;
        //    }
        //}
    }
}
