using HHCoApps.Libs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WareHouseApps.Models
{
    public class ProductViewModel
    {
        public Guid Id { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public string CategoryName { get; set; }
        public string SupplierName { get; set; }
        public int Status { get; set; }
        public decimal BasePrice { get; set; }
        public string StatusDisplay => StringHelper.GetEnumDescription((ProductStatus)Status);
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
