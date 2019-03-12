namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class FimTest : DbContext
    {
        public FimTest()
            : base("name=FimTest")
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<OrganizationUnit> OrganizationUnits { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationHeader> QuotationHeaders { get; set; }
        public virtual DbSet<RFQ> RFQs { get; set; }
        public virtual DbSet<RFQDetail> RFQDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
