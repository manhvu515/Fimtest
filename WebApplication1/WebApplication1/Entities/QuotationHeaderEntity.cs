using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class QuotationHeaderEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? RFQId { get; set; }

        public Guid? VendorId { get; set; }
    }
    public partial class QuotationHeaderSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
    }
       
}