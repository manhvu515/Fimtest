using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Modules.MVendor
{
    public interface IVendorRepository :IScopedService
    {
        int Count(VendorSearchEntity VendorRepository);
        List<Vendor> List(VendorSearchEntity VendorSearchEntity);
        Vendor Get(Guid Id);
        bool Add(Vendor Vendor);
        bool Update(Vendor Vendor);
        bool Delete(Guid Id);
    }

    public class VendorRepository : Repository<Vendor>, IVendorRepository
    {

        public VendorRepository(DbReadContext readContext, DbWriteContext writeContext) : base(readContext, writeContext) {

        }

        public bool Add(Vendor Vendor)
        {

            if (Vendor.id == null || Vendor.id == Guid.Empty)
            {
                Vendor.id = Guid.NewGuid();
            }
            writeContext.BulkMerge(new List<Vendor> { Vendor });
            return true;
        }

        public int Count(VendorSearchEntity VendorSearchEntity)
        {
            if (VendorSearchEntity == null) VendorSearchEntity = new VendorSearchEntity();
            IQueryable<Vendor> Vendors = readContext.Vendors;
            Vendors = Apply(Vendors, VendorSearchEntity);
            return Vendors.Count();
        }

        public bool Delete(Guid Id)
        {
            Vendor vendor = readContext.Vendors.Where(x => x.id == Id).Single();
            readContext.Vendors.Remove(vendor);
            readContext.SaveChanges();
            return true;
        }

        public Vendor Get(Guid Id)
        {
            Vendor Vendor = readContext.Vendors.Where(mc => mc.id == Id)
                .FirstOrDefault();
            return Vendor;
        }

        public List<Vendor> List(VendorSearchEntity VendorSearchEntity)
        {
            IQueryable<Vendor> Vendors = readContext.Vendors
                .AsNoTracking()
                .OrderBy(m => m.name);
            Vendors = Apply(Vendors, VendorSearchEntity);
            Vendors = SkipAndTake(Vendors, VendorSearchEntity);
            Vendors.OrderBy(m => m.name);
            return Vendors.ToList();
        }

        public bool Update(Vendor Vendor)
        {
            throw new NotImplementedException();
        }

        private IQueryable<Vendor> Apply(IQueryable<Vendor> Vendors, VendorSearchEntity VendorSearchEntity)
        {
            if (VendorSearchEntity.id.HasValue)
                Vendors = Vendors.Where(wh => wh.id == VendorSearchEntity.id.Value);
            if (!string.IsNullOrEmpty(VendorSearchEntity.name))
                Vendors = Vendors.Where(mc => mc.name.Contains(VendorSearchEntity.name));
            Vendors = Vendors.OrderBy(m => m.name);
            //if (!string.IsNullOrEmpty(VendorSearchEntity.name))
            //    Vendors = Vendors.Where(T => T.Code.ToLower().Contains(VendorSearchEntity.Code.ToLower()));
            //if (VendorSearchEntity.ParentId.HasValue)
            //    Vendors = Vendors.Where(T => T.ParentId.HasValue && T.ParentId.Value == VendorSearchEntity.ParentId.Value);
            return Vendors;
        }

    }
}