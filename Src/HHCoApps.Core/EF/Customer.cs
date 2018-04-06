using HHCoApps.Core.Core.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Core.EF
{
    public class Customer : CoreEntity<int>
    {
        public string FullName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? DOB { get; set; }
        public int HomeTown { get; set; }
        public bool IsOrganization { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
