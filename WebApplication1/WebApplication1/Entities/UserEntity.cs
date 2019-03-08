using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class UserEntity : BaseEntity
    {
        public Guid id { get; set; }
        public string display { get; set; }
        public string name { get; set; }
        public string ADGroupEntities { get; set; }
        public Guid oraganizationid { get; set; }
        public string RoleEntities { get; set; }
        public string Toke { get; set; }
        public string version { get; set; }
        public bool? isdeleted { get; set; }
    }
    public partial class UserSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string name { get; set; }

    }
}