using AutoMapper;
using HHCoApps.Core.EF;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using HHCoApps.Services.Repos;
using HHCoApps.Services.Repos.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Transactions;

namespace HHCoApps.Services.Implementation
{
    public class SupplierServices : BaseServices, ISupplierServices
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// 
        private IRepository<Supplier> supplierRepository;
        public SupplierServices()
        {
            this.supplierRepository = new Repository<Supplier>(dbContext);
        }

        /// <summary>
        /// Get Supplier
        /// </summary>
        /// <returns></returns>
        public IEnumerable<SupplierModel> GetSuppliers()
        {
            try
            {
                var data = supplierRepository.GetAll().Where(s => !s.IsDeleted).OrderBy(s => s.CompanyName).ToList();
                if (data.Count() > 0)
                    return data.Select(s => Mapper.Map<Supplier, SupplierModel>(s));
                else
                    return null;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Add new Supplier
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool AddSupplier(SupplierModel model)
        {
            try
            {
                if (supplierRepository.GetAll().Where(s => s.CompanyName == model.CompanyName && s.IsActive).Count() == 0)
                {
                    Supplier entity = Mapper.Map<SupplierModel, Supplier>(model);
                    entity.IsActive = true;
                    entity.IsDeleted = false;
                    supplierRepository.Insert(entity);
                    SaveChanges();
                    _logger.Info(
                        string.Format("New Supplier has been added by {0}: {1}",
                        Thread.CurrentPrincipal.Identity.Name, model.CompanyName));
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Update supplier
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool UpdateSupplier(SupplierModel model)
        {
            try
            {
                var entity = supplierRepository.GetById(model.Id);
                entity.IsActive = model.IsActive;
                entity.Note = model.Note;
                entity.TaxCode = model.TaxCode;
                entity.HomeTown = model.HomeTown;
                entity.Fax = model.Fax;
                entity.Email = model.Email;
                entity.DirectorName = model.DirectorName;
                entity.CompanyName = model.CompanyName;
                entity.Address = model.Address;
                supplierRepository.Update(entity);
                SaveChanges();
                _logger.Info(string.Format("Supplier {0} has been updated by {1}", model.CompanyName, Thread.CurrentPrincipal.Identity.Name));
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Delete supplier
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool DeleteSupplier(SupplierModel model)
        {
            try
            {
                using (var scope = new TransactionScope())
                {
                    var entity = supplierRepository.GetById(model.Id);
                    entity.IsActive = false;
                    entity.IsDeleted = true;
                    supplierRepository.Update(entity);
                    this.SaveChanges();
                    scope.Complete();
                }

                _logger.Info(string.Format("Supplier {0} has been deleted by {1}", model.CompanyName, Thread.CurrentPrincipal.Identity.Name));
                return true;
            }
            catch (TransactionException ex)
            {
                _logger.Error(ex.Message);
                return false;
            }
        }
    }
}
