namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Category")]
    public partial class Category
    {
        

        public Guid Id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string ExpertId { get; set; }

        [StringLength(100)]
        public string ExpertEntity { get; set; }

        public DateTime? DateTime { get; set; }

        public Guid? ParentCategoryId { get; set; }

        public int? Level { get; set; }

        [StringLength(100)]
        public string ParentCategoryEntities { get; set; }

        [StringLength(100)]
        public string MasterContractEntities { get; set; }

        [StringLength(100)]
        public string CategoryOrganizationEntity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQDetail> RFQDetails { get; set; }
    }
}
