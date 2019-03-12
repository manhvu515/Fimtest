using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Entities;

namespace WebApplication1.Modules.MVendor
{
    public interface IVendorService : IScopedService {
        int Count(VendorSearchEntity VendorSearchEntity);
        List<VendorEntity> Get( VendorSearchEntity VendorSearchEntity);
        VendorEntity Get(Guid VendorId);
        VendorEntity Create(VendorEntity VendorEntity);
        VendorEntity Update(VendorEntity VendorEntity, Guid VendorId);
        bool Delete(Guid VendorId);
    }
    public class VendorService : IVendorService
    {
        private IVendorRepository vendorRepository;
        private IVendorValidator vendorValidator;
        public VendorService(IVendorRepository vendorRepository, IVendorValidator vendorValidator)
        {
            this.vendorRepository = vendorRepository;
            this.vendorValidator = vendorValidator;
        }

        public int Count(VendorSearchEntity VendorSearchEntity)
        {
            return vendorRepository.Count(VendorSearchEntity);
        }


        public VendorEntity Create(VendorEntity VendorEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete( Guid VendorId)
        {
            return vendorRepository.Delete(VendorId);
        }

        public List<VendorEntity> Get(VendorSearchEntity VendorSearchEntity)
        {
            List<Vendor> vendors = vendorRepository.List(VendorSearchEntity);
            return vendors.Select(u => new VendorEntity(u)).ToList();
        }

        public VendorEntity Get(Guid VendorId)
        {
            Vendor Vendor  = vendorRepository.Get(VendorId);
            if (Vendor == null) return null;
            VendorEntity VendorEntity = new VendorEntity(Vendor);
            return VendorEntity;
        }

        public VendorEntity Update(VendorEntity VendorEntity, Guid VendorId)
        {
            throw new NotImplementedException();
        }
    }
}