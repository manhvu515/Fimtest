using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;
using WebApplication1.Models;

namespace WebApplication1.Modules.MUser
{
    public interface IUserRepository : IScopedService {
        int Count(UserSearchEntity UserSearchEntity);
        List<User> List(UserSearchEntity UserSearchEntity);
        User Get(Guid Id);
        User Find(Guid Id);
        bool Add(User User);
        bool Update(User User);
        bool Delete(Guid Id);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(DbReadContext readContext, DbWriteContext writeContext) : base(readContext,writeContext) {
            
        }
        public bool Add(User User)
        {
            User.id = Guid.NewGuid();
            // writeContext.
            return true;
        }

        public int Count(UserSearchEntity UserSearchEntity)
        {
            if (UserSearchEntity == null) UserSearchEntity = new UserSearchEntity();
            IQueryable<User> Users = readContext.Users;
            Users = Apply(Users, UserSearchEntity);
            return Users.Count();
        }

        public bool Delete(Guid Id)
        {
            User User = readContext.Users.Where(x => x.id == Id).FirstOrDefault();
            readContext.Users.Remove(User);
            readContext.SaveChanges();
            return true;
        }

        public User Get(Guid Id)
        {
            User User = readContext.Users.Where(mc => mc.id == Id)
                .FirstOrDefault();
            return User;
        }

        public List<User> List(UserSearchEntity UserSearchEntity)
        {
            IQueryable<User> Users = readContext.Users
               .AsNoTracking()
               .OrderBy(m => m.name);
            Users = Apply(Users, UserSearchEntity);
            Users = SkipAndTake(Users, UserSearchEntity);
            Users.OrderBy(m => m.name);
            return Users.ToList();
        }

        public bool Update(User Vendor)
        {
            throw new NotImplementedException();
        }

        private IQueryable<User> Apply(IQueryable<User> Users, UserSearchEntity UserSearchEntity)
        {
            if (UserSearchEntity.id.HasValue)
                Users = Users.Where(wh => wh.id == UserSearchEntity.id.Value);
            if (!string.IsNullOrEmpty(UserSearchEntity.name))
                Users = Users.Where(mc => mc.name.Contains(UserSearchEntity.name));
            Users = Users.OrderBy(m => m.name);
            //if (!string.IsNullOrEmpty(VendorSearchEntity.name))
            //    Vendors = Vendors.Where(T => T.Code.ToLower().Contains(VendorSearchEntity.Code.ToLower()));
            //if (VendorSearchEntity.ParentId.HasValue)
            //    Vendors = Vendors.Where(T => T.ParentId.HasValue && T.ParentId.Value == VendorSearchEntity.ParentId.Value);
            return Users;
        }
    }
}