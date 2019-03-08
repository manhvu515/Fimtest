using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class Quotation : Base
    {
        internal override string _Id => this.id.ToString();
        public Quotation() : base() { }

        public Quotation(QuotationEntity QuotationEntity) : base(QuotationEntity)
        {
        }
    }
}