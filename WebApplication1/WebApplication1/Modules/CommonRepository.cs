using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;

namespace WebApplication1.Modules
{
    public abstract class Repository<T> where T : Base
    {
        protected readonly DbReadContext readContext;
        protected readonly DbWriteContext writeContext;
        public Repository(DbReadContext readContext, DbWriteContext writeContext)
        {
            this.readContext = readContext;
            this.readContext.Configuration.LazyLoadingEnabled = false;
            this.readContext.Configuration.AutoDetectChangesEnabled = false;

            this.writeContext = writeContext;
        }

        public virtual T Find(Guid Id)
        {
            return readContext.Set<T>().Find(Id);
        }

        protected IQueryable<T> SkipAndTake(IQueryable<T> source, FilterEntity FilterEntity)
        {
            source = source.Skip(FilterEntity.Skip).Take(FilterEntity.Take);
            return source;
        }
    }
}