using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HHCoApps.Core;

namespace HHCoApps.Repository.Interfaces
{
    public interface IImportProductRepository
    {
        int AddImportLog(ImportLog entity);
    }
}
