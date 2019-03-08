using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class OrganizationEntity : BaseEntity
    {
        public Guid id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string parentid { get; set; }
        public string taxcode { get; set; }
        public string version { get; set; }
        public bool? isdelete { get; set; }
        public string OrganizationUnitEntities { get; set; }
        public string ADGroupEntities { get; set; }
    }
    public partial class OrganizationSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string name { get; set; }

    }
}