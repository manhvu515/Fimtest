using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Modules.MUser
{
    public interface IUserValidator : IScopedService
    {

    }
    public class UserValidator : CommonValidator, IUserValidator
    {
        public UserValidator()
        {
           
        }
    }
}