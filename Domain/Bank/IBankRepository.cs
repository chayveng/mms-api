namespace mms_api.Domain.Bank;

public interface IBankRepository
{
    bool SaveChanges();
    IQueryable<Bank> GetQuery();
    IEnumerable<Bank> GetAll();
    Task<Bank> GetById(Guid id);
    Task<Bank> GetByBankName(string bankName);
    Task<Bank> GetByInitials(string initials);
    Bank Create(Bank bank);
    Bank Update(Bank bank);
    Bank Delete(Bank bank);
    Task<IEnumerable<Bank>> Search(string name);
}