using HHCoApps.Core.EF;
using HHCoApps.Services.Models;
using System.Collections.Generic;

namespace HHCoApps.Services.Interfaces
{
    public interface ISupplierServices
    {
        IEnumerable<Supplier> GetSuppliers();
        int AddNewSupplier(SupplierModel model);
        int UpdateSupplier(SupplierModel model);
        int DeleteSupplier(SupplierModel model);
    }
}
