using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Interfaces
{
    public interface ISupplierServices
    {
        IEnumerable<SupplierModel> GetSuppliers();
        bool AddSupplier(SupplierModel model);
        bool UpdateSupplier(SupplierModel model);
        bool DeleteSupplier(SupplierModel model);
    }
}
