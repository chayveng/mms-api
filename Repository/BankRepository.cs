using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Bank;
using mms_api.Domain.Business;
using mms_api.Infrastucture;

namespace mms_api.Repository;

public class BankRepository : IBankRepository
{
    private readonly DatabaseContext _context;

    public BankRepository(DatabaseContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IQueryable<Bank> GetQuery()
    {
        return _context.Banks;
    }

    public IEnumerable<Bank> GetAll()
    {
        return _context.Banks.ToList();
    }

    public async Task<Bank> GetById(Guid id)
    {
        var result = await _context.Banks.FirstOrDefaultAsync(e => e.Id == id);
        return result;
    }

    public async Task<Bank> GetByBankName(string bankName)
    {
        var result = await _context.Banks.FirstOrDefaultAsync(e => e.Name == bankName);
        return result;
    }

    public async Task<Bank> GetByInitials(string initials)
    {
        var result = await _context.Banks.FirstOrDefaultAsync(e => e.Initials == initials);
        return result;
    }

    public Bank Create(Bank bank)
    {
        var entity = _context.Banks.Add(bank);
        return entity.Entity;
    }

    public Bank Update(Bank bank)
    {
        var entity = _context.Banks.Update(bank);
        return entity.Entity;
    }

    public Bank Delete(Bank bank)
    {
        var entity = _context.Banks.Remove(bank);
        return entity.Entity;
    }

    public async Task<IEnumerable<Bank>> Search(string name)
    {
        IQueryable<Bank> query = _context.Banks;
        if (!string.IsNullOrEmpty(name))
        {
            query = query.Where(e => e.Name.Contains(name));
        }
        return await query.ToListAsync();
    }

}