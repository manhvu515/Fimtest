namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RFQ")]
    public partial class RFQ
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RFQ()
        {
            QuotationHeaders = new HashSet<QuotationHeader>();
            RFQDetails = new HashSet<RFQDetail>();
        }

        public Guid Id { get; set; }

        public int? Number { get; set; }

        public string Description { get; set; }

        public string ReceivedAddress { get; set; }

        public Guid? OrganizationUnitId { get; set; }

        public Guid? OrganizationId { get; set; }

        public Guid? UserId { get; set; }

        public Guid? HanderId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        public DateTime? CreatedDate { get; set; }

        public virtual Organization Organization { get; set; }

        public virtual OrganizationUnit OrganizationUnit { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationHeader> QuotationHeaders { get; set; }

        public virtual User User { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQDetail> RFQDetails { get; set; }
    }
}
