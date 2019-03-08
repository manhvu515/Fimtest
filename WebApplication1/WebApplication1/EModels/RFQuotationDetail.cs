using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class RFQuotationDetail : Base
    {
        internal override string _Id => this.id.ToString();
        public RFQuotationDetail() : base() { }

        public RFQuotationDetail(RFQuotationDetailEntity RFQuotationDetailEntity) : base(RFQuotationDetailEntity)
        {
        }
    }
}