﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class QuotationHeader : Base
    {
        internal override string _Id => this.Id.ToString();
        public QuotationHeader() : base() { }

        public QuotationHeader(QuotationHeaderEntity QuotationHeaderEntity) : base(QuotationHeaderEntity)
        {
        }
    }
}