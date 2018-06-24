using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HHCoApps.Core.Core.Imp
{
    public abstract class CoreEntity<T>: Interface.IAuditableEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public virtual T Id { get; set; }

        [ScaffoldColumn(false)]
        public DateTime CreatedDate { get; set; }

        [ScaffoldColumn(false)]
        public string CreatedBy { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? ModifiedDate { get; set; }

        [ScaffoldColumn(false)]
        public string ModifiedBy { get; set; }
    }
}
