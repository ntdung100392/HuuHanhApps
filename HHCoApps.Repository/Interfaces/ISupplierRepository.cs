using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHCoApps.Core;

namespace HHCoApps.Repository
{
    public interface ISupplierRepository
    {
        IEnumerable<Supplier> GetSuppliers();
        int AddNewSupplier(Supplier model);
        int UpdateSupplier(Supplier model);
        int DeleteSupplier(Supplier model);
    }
}
