using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class RFQDetail : Base
    {
        internal override string _Id => this.Id.ToString();
        public RFQDetail() : base() { }

        public RFQDetail(RFQDetailEntity RFQDetailEntity) : base(RFQDetailEntity)
        {
        }
    }
}