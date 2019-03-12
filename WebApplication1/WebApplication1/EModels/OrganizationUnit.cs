using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class OrganizationUnit : Base
    {
        internal override string _Id => this.Id.ToString();
        public OrganizationUnit() : base() { }

        public OrganizationUnit(OrganizationUnitEntity OrganizationUnitEntity) : base(OrganizationUnitEntity)
        {
        }
    }
}