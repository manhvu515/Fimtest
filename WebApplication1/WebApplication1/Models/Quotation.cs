namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quotation")]
    public partial class Quotation
    {
        public Guid Id { get; set; }

        public Guid? QuotationHeaderId { get; set; }

        public Guid? RFQDetailId { get; set; }

        public double? UnitPrice { get; set; }

        public double? Price { get; set; }

        [StringLength(100)]
        public string TaxType { get; set; }

        [StringLength(100)]
        public string TaxAmount { get; set; }

        public double? Total { get; set; }

        [StringLength(100)]
        public string Note { get; set; }

        [StringLength(100)]
        public string NoteForVendor { get; set; }

        public virtual QuotationHeader QuotationHeader { get; set; }

        public virtual RFQDetail RFQDetail { get; set; }
    }
}
