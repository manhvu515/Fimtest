using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Modules.MVendor
{
    public interface IVendorValidator : IScopedService
    {
        //bool Get(VendorEntity VendorEntity);
        //bool Create(VendorEntity VendorEntity);
        //bool Update(VendorEntity VendorEntity);
        //bool Delete(VendorEntity VendorEntity);
    }
    public class VendorValidator : IVendorValidator
    {

        public VendorValidator() {

        }

        //public bool Create(VendorEntity VendorEntity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Delete(VendorEntity VendorEntity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Get(VendorEntity VendorEntity)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool Update(VendorEntity VendorEntity)
        //{
        //    throw new NotImplementedException();
        //}
    }
}