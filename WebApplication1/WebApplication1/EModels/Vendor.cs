using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class Vendor : Base
    {
        internal override string _Id => this.Id.ToString();
        public Vendor() : base() { }

        public Vendor(VendorEntity VendorEntity) : base(VendorEntity)
        {
        }
    }
}