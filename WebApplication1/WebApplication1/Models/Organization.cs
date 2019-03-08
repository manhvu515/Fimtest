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
        

        public Guid id { get; set; }

        [StringLength(100)]
        public string code { get; set; }

        [StringLength(100)]
        public string name { get; set; }

        [StringLength(100)]
        public string parentid { get; set; }

        [StringLength(100)]
        public string taxcode { get; set; }

        [StringLength(100)]
        public string version { get; set; }

        public bool? isdelete { get; set; }

        [StringLength(100)]
        public string OrganizationUnitEntities { get; set; }

        [StringLength(100)]
        public string ADGroupEntities { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<User> Users { get; set; }
    }
}
