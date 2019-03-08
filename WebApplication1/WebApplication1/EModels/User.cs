using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Entities;

namespace WebApplication1.Models
{
    public partial class User : Base
    {
        internal override string _Id => this.id.ToString();
        public User() : base() { }

        public User(UserEntity userEntity) : base(userEntity)
        {
        }
    }
}