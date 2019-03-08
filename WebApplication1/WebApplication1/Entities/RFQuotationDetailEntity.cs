using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class RFQuotationDetailEntity
    {
        public Guid id { get; set; }
        public Guid? idRFQuotation { get; set; }
    }
    public partial class RFQuotationDetailSearchEntity : FilterEntity
    {
        public Guid id { get; set; }
        public Guid? idRFQuotation { get; set; }
    
    }
}