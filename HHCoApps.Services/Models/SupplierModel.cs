using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Services.Models
{
    public class SupplierModel
    {
        public int Id { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string TaxCode { get; set; }
        public string DirectorName { get; set; }
        public string HomeTown { get; set; }
        public string Note { get; set; }
        public bool IsActive { get; set; }
    }
}
