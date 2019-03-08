using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class RFQuotation : Base
    {
        internal override string _Id => this.id.ToString();
        public RFQuotation() : base() { }

        public RFQuotation(RFQuotationEntity RFQuotationEntity) : base(RFQuotationEntity)
        {
        }
    }
}