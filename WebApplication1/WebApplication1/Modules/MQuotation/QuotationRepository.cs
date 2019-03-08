using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.Models;
using WebApplication1.Entities;

namespace WebApplication1.Modules.MQuotation
{
    public interface IQuotationRepository : IScopedService {
        int Count(quotationSearchEntity quotationSearchEntity);
        List<quotation> List(quotationSearchEntity quotationSearchEntity);
        quotation Get(Guid Id);
        quotation Find(Guid Id);
        bool Add(quotation quotation);
        bool Update(quotation quotation);
        bool Delete(Guid Id);

    }
    public class QuotationRepository : Repository<quotation>, IQuotationRepository
    {
        public QuotationRepository(DbReadContext readContext, DbWriteContext writeContext) : base(readContext, writeContext) {

        }

        public bool Add(quotation quotation)
        {
            throw new NotImplementedException();
        }

        public int Count(quotationSearchEntity quotationSearchEntity)
        {
            if (quotationSearchEntity == null) quotationSearchEntity = new quotationSearchEntity();
            IQueryable<quotation> quotations = readContext.quotations;
            quotations = Apply(quotations, quotationSearchEntity);
            return quotations.Count();
        }

        public bool Delete(Guid Id)
        {
            throw new NotImplementedException();
        }

        public quotation Get(Guid Id)
        {
            throw new NotImplementedException();
        }

        public List<quotation> List(quotationSearchEntity quotationSearchEntity)
        {
            throw new NotImplementedException();
        }

        public bool Update(quotation quotation)
        {
            throw new NotImplementedException();
        }

        private IQueryable<quotation> Apply(IQueryable<quotation> quotation, quotationSearchEntity quotationSearchEntity)
        {
            //if (quotationSearchEntity.id.HasValue)
            //    quotation = quotation.Where(wh => wh.id == quotationSearchEntity.id.Value);
            //if (!string.IsNullOrEmpty(quotationSearchEntity.))
            //    quotation = quotation.Where(mc => mc.name.Contains(quotationSearchEntity.name));
            //quotation = quotation.OrderBy(m => m.name);
            

            //if (!string.IsNullOrEmpty(VendorSearchEntity.name))
            //    Vendors = Vendors.Where(T => T.Code.ToLower().Contains(VendorSearchEntity.Code.ToLower()));
            //if (VendorSearchEntity.ParentId.HasValue)
            //    Vendors = Vendors.Where(T => T.ParentId.HasValue && T.ParentId.Value == VendorSearchEntity.ParentId.Value);
            return quotation;
        }


    }
}