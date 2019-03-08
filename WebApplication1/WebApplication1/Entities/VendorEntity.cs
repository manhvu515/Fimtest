using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class VendorEntity : BaseEntity
    {
        public Guid id { get; set; }
        public string name { get; set; }
        public string taxcode { get; set; }
        public string owner { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string bankaccount { get; set; }
        public string bank { get; set; }
        public string bankBranch { get; set; }
        public bool? islock { get; set; }
        public bool? approved { get; set; }
    }
    public partial class VendorSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
        public string name { get; set; }

    }
}