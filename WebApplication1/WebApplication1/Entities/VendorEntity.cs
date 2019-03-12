using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Entities
{
    public class VendorEntity : BaseEntity
    {
        public Guid Id { get; set; }
        
        public string Name { get; set; }
        
        public string Address { get; set; }
        
        public string TaxCode { get; set; }
        
        public string Owner { get; set; }
        
        public string Phone { get; set; }
        
        public string Email { get; set; }
        
        public string Website { get; set; }
        
        public string BankAccount { get; set; }
        
        public string Bank { get; set; }
        
        public string BankBranch { get; set; }

        public bool? IsLock { get; set; }

        public bool? Approved { get; set; }
    }
    public partial class VendorSearchEntity : FilterEntity
    {
        public Guid? id { get; set; }
    }
}