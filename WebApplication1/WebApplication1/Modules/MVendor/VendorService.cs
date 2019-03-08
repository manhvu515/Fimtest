using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Entities;

namespace WebApplication1.Modules.MVendor
{
    public interface IVendorService : IScopedService {
        int Count(VendorEntity VendorEntity, VendorSearchEntity VendorSearchEntity);
        List<VendorEntity> Get(VendorEntity VendorEntity, VendorSearchEntity VendorSearchEntity);
        VendorEntity Get(VendorEntity EmployeeEntity, Guid CategoryId);
        VendorEntity Create(VendorEntity VendorEntity, VendorEntity CategVendorEntityoryEntity);
        VendorEntity Update(VendorEntity VendorEntity, Guid CategoryId);
        bool Delete(VendorEntity VendorEntity, Guid VendorId);
    }
    public class VendorService : IVendorService
    {
        public int Count(VendorEntity VendorEntity, VendorSearchEntity VendorSearchEntity)
        {
            throw new NotImplementedException();
        }

        public VendorEntity Create(VendorEntity VendorEntity, VendorEntity CategVendorEntityoryEntity)
        {
            throw new NotImplementedException();
        }

        public bool Delete(VendorEntity VendorEntity, Guid VendorId)
        {
            throw new NotImplementedException();
        }

        public List<VendorEntity> Get(VendorEntity VendorEntity, VendorSearchEntity VendorSearchEntity)
        {
            throw new NotImplementedException();
        }

        public VendorEntity Get(VendorEntity EmployeeEntity, Guid CategoryId)
        {
            throw new NotImplementedException();
        }

        public VendorEntity Update(VendorEntity VendorEntity, Guid CategoryId)
        {
            throw new NotImplementedException();
        }
    }
}