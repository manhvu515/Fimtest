namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Vendor")]
    public partial class Vendor
    {
        
        public Guid id { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string taxcode { get; set; }

        [StringLength(100)]
        public string owner { get; set; }

        [StringLength(100)]
        public string phone { get; set; }

        [StringLength(100)]
        public string email { get; set; }

        [StringLength(100)]
        public string website { get; set; }

        [StringLength(100)]
        public string bankaccount { get; set; }

        [StringLength(100)]
        public string bank { get; set; }

        [StringLength(100)]
        public string bankBranch { get; set; }

        public bool? islock { get; set; }

        public bool? approved { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationHeader> QuotationHeaders { get; set; }
    }
}
