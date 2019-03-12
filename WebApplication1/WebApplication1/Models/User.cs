namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            RFQs = new HashSet<RFQ>();
        }

        public Guid Id { get; set; }

        [StringLength(100)]
        public string Display { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(100)]
        public string ADGroupEntities { get; set; }

        [StringLength(100)]
        public string RoleEntities { get; set; }

        public Guid? Oraganizationid { get; set; }

        [StringLength(100)]
        public string Toke { get; set; }

        [StringLength(100)]
        public string Version { get; set; }

        public bool? Isdeleted { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQ> RFQs { get; set; }
    }
}
