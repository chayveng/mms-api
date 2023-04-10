using mms_api.Domain.Payment;

namespace mms_api.Managers.PaymentManeger;

public class PaymentManager
{

    private readonly IPaymentRepository _repository;

    public PaymentManager(IPaymentRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<Payment> GetAll()
    {
        return _repository.GetAll();
    }

    public async Task<Payment> GetById(Guid id)
    {
        return await _repository.GetById(id);
    }

    public Payment Create(Payment payment)
    {
        var count = _repository.Counter();
        payment.Code = $"{(count + 1).ToString().PadLeft(3, '0')}";
        payment.CREATED_DATETIME = DateTime.UtcNow;
        payment.UPDATED_DATETIME = DateTime.UtcNow;
        var response = _repository.Create(payment);
        _repository.SaveChanges();
        return response;
    }

    public Payment Update(Payment newPayment, Payment oldPayment)
    {
        oldPayment.Initials = newPayment.Initials;
        oldPayment.Name = newPayment.Name;
        oldPayment.ImageId = newPayment.ImageId;
        oldPayment.Status = newPayment.Status;
        oldPayment.UPDATED_DATETIME = DateTime.UtcNow;

        var response = _repository.Update(oldPayment);
        _repository.SaveChanges();
        return response;
    }
    public Payment Delete(Payment payment)
    {
        var response = _repository.Delete(payment);
        _repository.SaveChanges();
        return response;
    }


}