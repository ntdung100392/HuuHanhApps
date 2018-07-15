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
        public int Id { get; set; }
        public Guid UniqueId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        public string Status { get; set; }
        public decimal BaseCost { get; set; }
        public decimal InputCost { get; set; }
        public string StatusDisplay => Status;
        public DateTime IssuedDate { get; set; }
        public DateTime? ExpiredDate { get; set; }
        public int Stock { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
    }
}
