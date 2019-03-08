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
        public Guid id { get; set; }

        public Guid idRFQuotationDetail { get; set; }

        public Guid idQuotationHeader { get; set; }

        public Guid idproduct { get; set; }

        public virtual product product { get; set; }

        public virtual QuotationHeader QuotationHeader { get; set; }

        public virtual RFQuotationDetail RFQuotationDetail { get; set; }
    }
}
