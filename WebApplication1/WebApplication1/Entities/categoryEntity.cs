using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class CategoryEntity : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ExpertId { get; set; }
        public string ExpertEntity { get; set; }
        public DateTime? DateTime { get; set; }
        public Guid? ParentCategoryId { get; set; }
        public int? Level { get; set; }
        public string ParentCategoryEntities { get; set; }
        public string MasterContractEntities { get; set; }
        public string CategoryOrganizationEntity { get; set; }
    }
    public partial class CategorySearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string Name { get; set; }
    }
}