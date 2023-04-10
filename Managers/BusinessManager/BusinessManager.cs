using mms_api.Domain.Business;

namespace mms_api.Managers.BusinessManager;

public class BusinessManager
{
    private readonly Business _business;
    private readonly IBusinessRepository _repository;

    public BusinessManager(IBusinessRepository repository, Business business)
    {
        _repository = repository;
        _business = business;
    }

    public IEnumerable<Business> GetAll()
    {
        return _repository.GetAll();
    }
    public async Task<Business?> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public Business Create(Business business)
    {
        business.Id = new Guid();
        business.CREATE_DATETIME = DateTime.UtcNow;
        business.UPDATE_DATETIME = DateTime.UtcNow;
        var response = _repository.Create(business);
        _repository.SaveChanges();
        return response;
    }

    public Business Update(Business newBusiness, Business oldBusiness)
    {
        // oldBusiness.BusinessId = newBusiness.BusinessId;
        oldBusiness.Name = newBusiness.Name;
        oldBusiness.Status = newBusiness.Status;
        oldBusiness.UPDATE_DATETIME = DateTime.UtcNow;

        var response = _repository.Update(oldBusiness);
        _repository.SaveChanges();
        return response;
    }
    public Business Delete(Business business)
    {
        var response = _repository.Delete(business);
        _repository.SaveChanges();
        return response;
    }
}