using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Entities;
using WebApplication1.Modules.MUser;

namespace WebApplication1.Modules.MUser
{
    public interface IUserService : IScopedService {
        int Count(UserSearchEntity UserSearchEntity);
        List<UserEntity> Get(UserSearchEntity UserSearchEntity);
        UserEntity Get(Guid UserId);
        UserEntity Create(UserEntity UserEntity);
        UserEntity Update(UserEntity UserEntity, Guid UserId);
        bool Delete(Guid UserId);
    }
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IUserValidator userValidator;
        public UserService(IUserRepository userRepository, IUserValidator userValidator) {
            this.userRepository = userRepository;
            this.userValidator = userValidator;
        }

        public int Count(UserSearchEntity UserSearchEntity)
        {
            return userRepository.Count(UserSearchEntity);
        }

        public UserEntity Create(UserEntity UserEntity)
        {
            User User = new User(UserEntity);
            userRepository.Add(User);
            return Get(User.id);
        }

        public bool Delete( Guid UserId)
        {
            return userRepository.Delete(UserId);
        }

        public List<UserEntity> Get(UserSearchEntity UserSearchEntity)
        {
            List<User> Users = userRepository.List(UserSearchEntity);
            return Users.Select(u => new UserEntity(u)).ToList();
        }

        public UserEntity Get(Guid UserId)
        {
            User User = userRepository.Get(UserId);
            if (User == null) return null;
            UserEntity UserEntity = new UserEntity(User);
            return UserEntity;
        }

        public UserEntity Update(UserEntity UserEntity, Guid UserId)
        {
            throw new NotImplementedException();
        }
    }
}