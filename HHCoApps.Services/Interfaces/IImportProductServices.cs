﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Interfaces
{
    public interface IImportProductServices
    {
        IDictionary<string, int> GetAllProductModels();
    }
}
