using HHCoApps.Core.Core.Imp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Core.EF
{
    public class Product : CoreEntity<Guid>
    {
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public Guid SupplierId { get; set; }
        public decimal BasePrice { get; set; }
        public int Status { get; set; }
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }

        public virtual Supplier Supplier { get; set; }
        public virtual Category Category { get; set; }
    }
}
