//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HHCoApps.Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product
    {
        public int Id { get; set; }
        public System.Guid UniqueId { get; set; }
        public string ProductCode { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }
        public decimal InputCost { get; set; }
        public decimal BaseCost { get; set; }
        public string ForeignCurrency { get; set; }
        public System.DateTime IssuedDate { get; set; }
        public System.DateTime ExpiredDate { get; set; }
        public int Stock { get; set; }
        public string Status { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        public virtual Category Category { get; set; }
        public virtual Supplier Supplier { get; set; }
    }
}
