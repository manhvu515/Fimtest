namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("category")]
    public partial class category
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public category()
        //{
        //    RFQuotations = new HashSet<RFQuotation>();
        //}

        public Guid id { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(100)]
        public string ExpertId { get; set; }

        [StringLength(100)]
        public string ExpertEntity { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DateTime { get; set; }

        [StringLength(100)]
        public string ParentCategoryId { get; set; }

        public int? Level { get; set; }

        [StringLength(100)]
        public string ParentCategoryEntities { get; set; }

        [StringLength(100)]
        public string MasterContractEntities { get; set; }

        [StringLength(100)]
        public string CategoryOrganizationEntity { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQuotation> RFQuotations { get; set; }
    }
}
