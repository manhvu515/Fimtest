using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class RFQuotationEntity : BaseEntity
    {
        public Guid id { get; set; }
        public int? number { get; set; }
        public string Description { get; set; }
        public string ReceivedAddress { get; set; }
        public string OrganizationUnitId { get; set; }
        public string OrganizationId { get; set; }
        public Guid UserId { get; set; }
        public Guid handerId { get; set; }
        public Guid? SubRootCategoryId { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
    public partial class RFQuotationSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string name { get; set; }

    }
}