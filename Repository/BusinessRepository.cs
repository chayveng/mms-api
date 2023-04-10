using System;
using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Business;
using mms_api.Infrastucture;

namespace mms_api.Repository
{
    public class BusinessRepository : IBusinessRepository
    {
        private readonly DatabaseContext _context;

        public BusinessRepository(DatabaseContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public IQueryable<Business> GetQuery()
        {
            return _context.Businesses;
        }

        public string Running(string businessId)
        {
            var count = _context.Businesses.Where(e => e.BusinessId.Contains(businessId));
            var count2 = _context.Businesses.Count();
            // return count.Count();
            var date = DateTime.Now.ToString("yyyyMM");
            var p = $"{date}-{(count2 + 1).ToString().PadLeft(8, '0')}";
            return p;
        }

        public IEnumerable<Business> GetAll()
        {
            return _context.Businesses.ToList();
        }

        public async Task<Business?> GetById(Guid id)
        {
            var result = await _context.Businesses.FirstOrDefaultAsync(t => t.Id == id);
            return result;
        }

        public async Task<Business?> GetByBusinessId(string businessId)
        {
            var result = await _context.Businesses.FirstOrDefaultAsync(t => t.BusinessId == businessId);
            return result;
        }

        public async Task<Business?> GetByName(string name)
        {
            var result = await _context.Businesses.FirstOrDefaultAsync(t => t.Name == name);
            return result;
        }

        public Business Create(Business business)
        {
            var entity = _context.Businesses.Add(business);
            return entity.Entity;
        }

        public Business Update(Business business)
        {
            var entity = _context.Businesses.Update(business);
            return entity.Entity;
        }

        public Business Delete(Business business)
        {
            var entity = _context.Businesses.Remove(business);
            return entity.Entity;
        }

        public async Task<IEnumerable<Business>> Search(string name)
        {
            IQueryable<Business> query = _context.Businesses;
            if (!string.IsNullOrEmpty(name))
            {
                query = query.Where(e => e.Name.Contains(name));
            }
            return await query.ToListAsync();
        }
    }
}