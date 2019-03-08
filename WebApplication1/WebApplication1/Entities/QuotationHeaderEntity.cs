using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class QuotationHeaderEntity : BaseEntity
    {
        public Guid id { get; set; }
        public Guid idRFQuotation { get; set; }
        public Guid idvendor { get; set; }
    }
    public partial class QuotationHeaderSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }

    }
}