using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class Organization : Base
    {
        internal override string _Id => this.id.ToString();
        public Organization() : base() { }

        public Organization(OrganizationEntity OrganizationEntity) : base(OrganizationEntity)
        {
        }
    }
}