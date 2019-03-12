using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class OrganizationUnitEntity : BaseEntity
    {
        public Guid Id { get; set; }

        public Guid? OrganizationId { get; set; }
        
        public string Code { get; set; }
        
        public string Name { get; set; }
        
        public string Version { get; set; }

        public bool? IsDeleted { get; set; }
    }

    public partial class OrganizationUnitSearchEntity : FilterEntity
    {
        public Guid? Id { get; set; }
        public string Name { get; set; }
    }
}