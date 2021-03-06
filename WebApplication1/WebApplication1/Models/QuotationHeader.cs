namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("QuotationHeader")]
    public partial class QuotationHeader
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public QuotationHeader()
        {
            Quotations = new HashSet<Quotation>();
        }

        public Guid Id { get; set; }

        public Guid? RFQId { get; set; }

        public Guid? VendorId { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }

        public virtual RFQ RFQ { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
