using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class productEntity : BaseEntity
    {
        public Guid id { get; set; }
        public string rfqid { get; set; }
        public Guid categoryid { get; set; }
        public Guid subRootcategoryid { get; set; }
        public string description { get; set; }
        public double? quantity { get; set; }
        public string unit { get; set; }
        public string note { get; set; }
        public string NoteForVendor { get; set; }
        public bool? IsApproved { get; set; }
        public int? Orders { get; set; }
        public string RFQEntity { get; set; }
    }
    public partial class productSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }

    }
}