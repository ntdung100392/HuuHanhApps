using HHCoApps.Core;
using HHCoApps.Services.Repos;
using HHCoApps.Services.Repos.Impl;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Implementation
{
    public abstract class BaseServices
    {
        protected static readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected static readonly HHCoAppsDBContext dbContext = new HHCoAppsDBContext();

        public BaseServices()
        {
        }

        public void SaveChanges()
        {
            try
            {
                dbContext.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Console.WriteLine("Property: {0} Error: {1}",
                            validationError.PropertyName, validationError.ErrorMessage);
                    }
                }
            }
        }
    }
}
