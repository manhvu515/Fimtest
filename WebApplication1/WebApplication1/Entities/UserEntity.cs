using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid Id { get; set; }
        
        public string Display { get; set; }
        
        public string Name { get; set; }
        
        public string ADGroupEntities { get; set; }
        
        public string RoleEntities { get; set; }

        public Guid? Oraganizationid { get; set; }
        
        public string Toke { get; set; }
        
        public string Version { get; set; }

        public bool? Isdeleted { get; set; }
    }

    public partial class UserSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
    }
}