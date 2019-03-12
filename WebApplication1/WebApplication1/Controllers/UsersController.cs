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
using WebApplication1.Modules.MUser;
using WebApplication1.Entities;

namespace WebApplication1.Controllers
{
    [RoutePrefix ("api/User")]
    public class UsersController : ApiController
    {
        //private testContext db = new testContext();

        private IUserService UserService;
        public UsersController(IUserService UserService)
        {
            this.UserService = UserService;
        }

        [Route("Count"), HttpGet]
        public long Count(UserSearchEntity UserSearchEntity)
        {
            return UserService.Count(UserSearchEntity);
        }

        [Route("Users"), HttpGet]
        public List<UserEntity> Get(UserSearchEntity UserSearchEntity)
        {
            return UserService.Get(UserSearchEntity);
        }

        [Route("UserId"), HttpGet]
        public UserEntity Get(Guid UserId)
        {
            return UserService.Get(UserId);
        }

        [Route("Create"), HttpPost]
        public UserEntity Create([FromBody]UserEntity UserEntity)
        {
            return UserService.Create(UserEntity);
        }

        [Route("Update"), HttpPut]
        public UserEntity Update(Guid UserId, [FromBody]UserEntity UserEntity)
        {
            return UserService.Update( UserEntity, UserId);
        }

        [Route("Delete"), HttpDelete]
        public bool Delete(Guid UserId)
        {
            return UserService.Delete(UserId);
        }

        //// GET: api/Users
        //public IQueryable<User> GetUsers()
        //{
        //    return db.Users;
        //}

        //// GET: api/Users/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> GetUser(Guid id)
        //{
        //    User user = await db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(user);
        //}

        //// PUT: api/Users/5
        //[ResponseType(typeof(void))]
        //public async Task<IHttpActionResult> PutUser(Guid id, User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != user.id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(user).State = EntityState.Modified;

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!UserExists(id))
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

        //// POST: api/Users
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> PostUser(User user)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(user);

        //    try
        //    {
        //        await db.SaveChangesAsync();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (UserExists(user.id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = user.id }, user);
        //}

        //// DELETE: api/Users/5
        //[ResponseType(typeof(User))]
        //public async Task<IHttpActionResult> DeleteUser(Guid id)
        //{
        //    User user = await db.Users.FindAsync(id);
        //    if (user == null)
        //    {
        //        return NotFound();
        //    }

        //    db.Users.Remove(user);
        //    await db.SaveChangesAsync();

        //    return Ok(user);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool UserExists(Guid id)
        //{
        //    return db.Users.Count(e => e.id == id) > 0;
        //}
    }
}