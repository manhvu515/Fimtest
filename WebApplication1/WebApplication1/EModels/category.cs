using WebApplication1.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public partial class category : Base
    {
        internal override string _Id => this.id.ToString();
        public category() : base() { }

        public category(categoryEntity categoryEntity) : base(categoryEntity)
        {
        }
    }
}