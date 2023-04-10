using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mms_api.Domain.Business
{
    public interface IBusinessRepository
    {
        bool SaveChanges();
        IQueryable<Business> GetQuery();
        string Running(string businessId);
        IEnumerable<Business> GetAll();
        Task<Business?> GetById(Guid id);
        Task<Business?> GetByBusinessId(string businessId);
        Task<Business?> GetByName(string typeName);
        Business Create(Business business);
        Business Update(Business business);
        Business Delete(Business business);
        Task<IEnumerable<Business>> Search(string name);
    }
}