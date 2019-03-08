using WebApplication1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class categoryEntity :BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpertId { get; set; }
        public string ExpertEntity { get; set; }
        public DateTime? DateTime { get; set; }
        public string ParentCategoryId { get; set; }
        public int? Level { get; set; }
        public string ParentCategoryEntities { get; set; }
        public string MasterContractEntities { get; set; }
        public string CategoryOrganizationEntity { get; set; }
        public categoryEntity(category category, params object[] args) : base(category)
        {
        }
    }
    public partial class ecategorySearchEntity : FilterEntity {
        public Guid? id { get; set; }
        public string Name { get; set; }
    }
}