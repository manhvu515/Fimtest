using WebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public partial class Category : Base
    {
        internal override string _Id => this.Id.ToString();
        public Category() : base() { }

        public Category(CategoryEntity CategoryEntity) : base(CategoryEntity)
        {
        }
    }
}