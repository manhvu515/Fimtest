using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class RFQ : Base
    {
        internal override string _Id => this.Id.ToString();
        public RFQ() : base() { }

        public RFQ(RFQEntity RFQEntity) : base(RFQEntity)
        {
        }
    }
}