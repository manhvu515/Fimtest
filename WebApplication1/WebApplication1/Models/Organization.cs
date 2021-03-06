namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Organization")]
    public partial class Organization
    {
       

        public Guid Id { get; set; }

        [StringLength(100)]
        public string Code { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        public Guid? ParentId { get; set; }

        [StringLength(100)]
        public string TaxCode { get; set; }

        [StringLength(100)]
        public string Version { get; set; }

        public bool? IsDeleted { get; set; }

        [StringLength(100)]
        public string OrganizationUnitEntities { get; set; }

        [StringLength(100)]
        public string ADGroupEntities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrganizationUnit> OrganizationUnits { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQ> RFQs { get; set; }
    }
}
