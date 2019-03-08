namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("product")]
    public partial class product
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public product()
        //{
        //    Quotations = new HashSet<Quotation>();
        //}

        public Guid id { get; set; }

        [StringLength(100)]
        public string rfqid { get; set; }

        public Guid categoryid { get; set; }

        public Guid subRootcategoryid { get; set; }

        public string description { get; set; }

        public double? quantity { get; set; }

        [StringLength(50)]
        public string unit { get; set; }

        public string note { get; set; }

        public string NoteForVendor { get; set; }

        public bool? IsApproved { get; set; }

        public int? Orders { get; set; }

        [StringLength(100)]
        public string RFQEntity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }
    }
}
