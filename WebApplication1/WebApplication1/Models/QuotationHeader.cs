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
        
        public Guid id { get; set; }

        public Guid idRFQuotation { get; set; }

        public Guid idvendor { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Quotation> Quotations { get; set; }

        public virtual RFQuotation RFQuotation { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
