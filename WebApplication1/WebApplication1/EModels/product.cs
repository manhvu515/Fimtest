using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class product : Base
    {
        internal override string _Id => this.id.ToString();
        public product() : base() { }

        public product(productEntity productEntity) : base(productEntity)
        {
        }
    }
}