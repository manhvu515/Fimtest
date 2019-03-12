namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RFQDetail")]
    public partial class RFQDetail
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RFQDetail()
        {
            Quotations = new HashSet<Quotation>();
        }

        public Guid Id { get; set; }

        public Guid? RFQId { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }

        [StringLength(100)]
        public string Unit { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(100)]
        public string NoteForVendor { get; set; }

        public bool? IsApproved { get; set; }

        public int? Orderr { get; set; }

        [StringLength(100)]
        public string RFQEntity { get; set; }

        public virtual Category Category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }

        public virtual RFQ RFQ { get; set; }
    }
}
