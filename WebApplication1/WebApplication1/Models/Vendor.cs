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
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Vendor()
        {
            QuotationHeaders = new HashSet<QuotationHeader>();
        }

        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string Address { get; set; }

        [StringLength(100)]
        public string TaxCode { get; set; }

        [StringLength(100)]
        public string Owner { get; set; }

        [StringLength(100)]
        public string Phone { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string Website { get; set; }

        [StringLength(100)]
        public string BankAccount { get; set; }

        [StringLength(100)]
        public string Bank { get; set; }

        [StringLength(100)]
        public string BankBranch { get; set; }

        public bool? IsLock { get; set; }

        public bool? Approved { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationHeader> QuotationHeaders { get; set; }
    }
}
