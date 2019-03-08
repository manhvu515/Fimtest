namespace WebApplication1.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Fimtes : DbContext
    {
        public Fimtes()
            : base("name=Fimtes")
        {
        }

        public virtual DbSet<category> categories { get; set; }
        public virtual DbSet<Organization> Organizations { get; set; }
        public virtual DbSet<product> products { get; set; }
        public virtual DbSet<Quotation> Quotations { get; set; }
        public virtual DbSet<QuotationHeader> QuotationHeaders { get; set; }
        public virtual DbSet<RFQuotation> RFQuotations { get; set; }
        public virtual DbSet<RFQuotationDetail> RFQuotationDetails { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<category>()
                .HasMany(e => e.RFQuotations)
                .WithOptional(e => e.category)
                .HasForeignKey(e => e.SubRootCategoryId);

            modelBuilder.Entity<Organization>()
                .HasMany(e => e.Users)
                .WithRequired(e => e.Organization)
                .HasForeignKey(e => e.oraganizationid)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<product>()
                .HasMany(e => e.Quotations)
                .WithRequired(e => e.product)
                .HasForeignKey(e => e.idproduct)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<QuotationHeader>()
                .HasMany(e => e.Quotations)
                .WithRequired(e => e.QuotationHeader)
                .HasForeignKey(e => e.idQuotationHeader)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RFQuotation>()
                .HasMany(e => e.QuotationHeaders)
                .WithRequired(e => e.RFQuotation)
                .HasForeignKey(e => e.idRFQuotation)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RFQuotation>()
                .HasMany(e => e.RFQuotationDetails)
                .WithOptional(e => e.RFQuotation)
                .HasForeignKey(e => e.idRFQuotation);

            modelBuilder.Entity<RFQuotationDetail>()
                .HasMany(e => e.Quotations)
                .WithRequired(e => e.RFQuotationDetail)
                .HasForeignKey(e => e.idRFQuotationDetail)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RFQuotations)
                .WithRequired(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.RFQuotations1)
                .WithRequired(e => e.User1)
                .HasForeignKey(e => e.handerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Vendor>()
                .HasMany(e => e.QuotationHeaders)
                .WithRequired(e => e.Vendor)
                .HasForeignKey(e => e.idvendor)
                .WillCascadeOnDelete(false);
        }
    }
}
