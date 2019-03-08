using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class QuotationEntity : BaseEntity
    {

        public Guid id { get; set; }
        public Guid idRFQuotationDetail { get; set; }
        public Guid idproduct { get; set; }
        //public virtual product product { get; set; }

        //public virtual QuotationHeader QuotationHeader { get; set; }

        //public virtual RFQuotationDetail RFQuotationDetail { get; set; }
    }
    public partial class QuotationSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public Guid idRFQuotationDetail { get; set; }
        public Guid idproduct { get; set; }

    }
}