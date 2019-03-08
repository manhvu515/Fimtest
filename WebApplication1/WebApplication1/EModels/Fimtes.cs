﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApplication1.Models
{
    public partial class Fimtes
    {
        public Fimtes(string str)
              : base(str)
        {
        }
    }
    public class DbReadContext : Fimtes
    {
        public DbReadContext() : base("name=ReadModel")
        {
            Database.SetInitializer<DbReadContext>(null);
        }
    }
    public class DbWriteContext : Fimtes
    {
        public DbWriteContext() : base("name=WriteModel")
        {
            Database.SetInitializer<DbReadContext>(null);
        }
    }
}