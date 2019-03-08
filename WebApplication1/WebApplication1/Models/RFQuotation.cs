namespace WebApplication1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("RFQuotation")]
    public partial class RFQuotation
    {
        //[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        //public RFQuotation()
        //{
        //    QuotationHeaders = new HashSet<QuotationHeader>();
        //    RFQuotationDetails = new HashSet<RFQuotationDetail>();
        //}

        public Guid id { get; set; }

        public int? number { get; set; }

        public string Description { get; set; }

        public string ReceivedAddress { get; set; }

        [StringLength(100)]
        public string OrganizationUnitId { get; set; }

        [StringLength(100)]
        public string OrganizationId { get; set; }

        public Guid UserId { get; set; }

        public Guid handerId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        [Column(TypeName = "date")]
        public DateTime? CreatedDate { get; set; }

        public virtual category category { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<QuotationHeader> QuotationHeaders { get; set; }

        public virtual User User { get; set; }

        public virtual User User1 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RFQuotationDetail> RFQuotationDetails { get; set; }
    }
}
