using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class RFQDetailEntity : BaseEntity
    {

        public Guid Id { get; set; }

        public Guid? RFQId { get; set; }

        public Guid? CategoryId { get; set; }

        public Guid? SubRootCategoryId { get; set; }

        public string Description { get; set; }

        public int? Quantity { get; set; }
        
        public string Unit { get; set; }
        
        public string Note { get; set; }
        
        public string NoteForVendor { get; set; }

        public bool? IsApproved { get; set; }

        public int? Orderr { get; set; }
        
        public string RFQEntity { get; set; }
        
    }
    public partial class RFQDetailSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
    }
}