namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        

        public Guid id { get; set; }

        [StringLength(100)]
        public string display { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string ADGroupEntities { get; set; }

        public Guid oraganizationid { get; set; }

        [StringLength(100)]
        public string RoleEntities { get; set; }

        [StringLength(100)]
        public string Toke { get; set; }

        [StringLength(100)]
        public string version { get; set; }

        public bool? isdeleted { get; set; }

        public virtual Organization Organization { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQuotation> RFQuotations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQuotation> RFQuotations1 { get; set; }
    }
}
