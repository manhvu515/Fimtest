using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication1.Models;
using WebApplication1.Modules.MVendor;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [RoutePrefix("api/Vendor")]
    public class VendorsController : ApiController
    {

        private IVendorService VendorService;
        public VendorsController(IVendorService VendorService)
        {
            this.VendorService = VendorService;
        }

        [Route("Count"), HttpGet]
        public long Count(VendorSearchEntity VendorSearchEntity)
        {
            return VendorService.Count(VendorSearchEntity);
        }

        [Route("Vendors"), HttpGet]
        public List<VendorEntity> Get(VendorSearchEntity VendorSearchEntity)
        {
            return VendorService.Get(VendorSearchEntity);
        }

        [Route("VendorId"), HttpGet]
        public VendorEntity Get(Guid VendorID)
        {
            return VendorService.Get(VendorID);
        }

        [Route("Create"), HttpPost]
        public VendorEntity Create([FromBody]VendorEntity VendorEntity)
        {
            return VendorService.Create(VendorEntity);
        }

        [Route("Update"), HttpPut]
        public VendorEntity Update(Guid VendorId, [FromBody]VendorEntity VendorEntity)
        {
            return VendorService.Update(VendorEntity, VendorId);
        }

        [Route("Delete"), HttpDelete]
        public bool Delete(Guid VendorId)
        {
            return VendorService.Delete(VendorId);
        }

        //private VendorContext db = new VendorContext();

        //// GET: api/Vendors
        //public IQueryable<Vendor> GetVendors()
        //{
        //    return db.Vendors;
        //}

        //// GET: api/Vendors/5
        //[ResponseType(typeof(Vendor))]
        //public async Task<IHttpActionResult> GetVendor(Guid id)
        //{
        //    Vendor vendor = await db.Vendors.FindAsync(id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(vendor);
        //}

        //// PUT: api/Vendors/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutVendor(Guid id, Vendor vendor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != vendor.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(vendor).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!VendorExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Vendors
        //[ResponseType(typeof(Vendor))]
        //public async Task<IHttpActionResult> PostVendor(Vendor vendor)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Vendors.Add(vendor);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (VendorExists(vendor.id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = vendor.id }, vendor);
        //}

        //// DELETE: api/Vendors/5
        //[ResponseType(typeof(Vendor))]
        //public async Task<IHttpActionResult> DeleteVendor(Guid id)
        //{
        //    Vendor vendor = await db.Vendors.FindAsync(id);
        //    if (vendor == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Vendors.Remove(vendor);
        //    await db.SaveChangesAsync();

        //    return Ok(vendor);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool VendorExists(Guid id)
        //{
        //    return db.Vendors.Count(e => e.id == id) > 0;
        //}
    }
}