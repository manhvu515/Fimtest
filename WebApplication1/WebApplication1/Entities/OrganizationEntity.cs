﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class OrganizationEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public Guid? ParentId { get; set; }
        public string TaxCode { get; set; }
        public string Version { get; set; }
        public bool? IsDeleted { get; set; }
        public string OrganizationUnitEntities { get; set; }
        public string ADGroupEntities { get; set; }
    }
    public partial class OrganizationSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string Name { get; set; }
    }
}