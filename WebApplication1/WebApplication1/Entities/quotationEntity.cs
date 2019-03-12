using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class QuotationEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? QuotationHeaderId { get; set; }

        public Guid? RFQDetailId { get; set; }

        public double? UnitPrice { get; set; }

        public double? Price { get; set; }
        
        public string TaxType { get; set; }
        
        public string TaxAmount { get; set; }

        public double? Total { get; set; }
        
        public string Note { get; set; }

        public string NoteForVendor { get; set; }

        public virtual QuotationHeader QuotationHeader { get; set; }
        
    }
    public partial class QuotationSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string Name { get; set; }
    }
}