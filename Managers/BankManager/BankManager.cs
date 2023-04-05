using mms_api.Domain.Bank;

namespace mms_api.Managers.BankManager;

public class BankManager
{
    private readonly IBankRepository _repository;

    public BankManager(IBankRepository repository)
    {
        _repository = repository;
    }
    
    public IEnumerable<Bank> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Bank> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public Bank Create(Bank bank)
    {
        bank.Id = new Guid();
        bank.CREATE_DATETIME = DateTime.UtcNow;
        bank.UPDATE_DATETIME = DateTime.UtcNow;
        var response = _repository.Create(bank);
        _repository.SaveChanges();
        return response;
    }

    public Bank Update(Bank newBank, Bank oldBank)
    {
        oldBank.Initials = newBank.Initials;
        oldBank.BankName = newBank.BankName;
        oldBank.Status = newBank.Status;
        oldBank.UPDATE_DATETIME =  DateTime.UtcNow;
        
        var response = _repository.Update(oldBank);
        _repository.SaveChanges();
        return response;
    }
    public Bank Delete(Bank bank)
    {
        var response = _repository.Delete(bank);
        _repository.SaveChanges();
        return response;
    }
}