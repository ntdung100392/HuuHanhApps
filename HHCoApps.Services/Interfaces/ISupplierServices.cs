using HHCoApps.Services.Models;
using System.Collections.Generic;

namespace HHCoApps.Services.Interfaces
{
    public interface ISupplierServices
    {
        IEnumerable<SupplierModel> GetSuppliers();
        int AddNewSupplier(SupplierModel model);
        int UpdateSupplier(SupplierModel model);
        int DeleteSupplier(SupplierModel model);
    }
}
