using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class RFQEntity : BaseEntity
    {
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
        
    }
    public partial class RFQSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
    }
}