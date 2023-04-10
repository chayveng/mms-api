namespace mms_api.Domain.Payment;

public interface IPaymentRepository
{
    bool SaveChanges();
    IQueryable<Payment> GetQuery();
    // int Running(string imageId);
    IEnumerable<Payment> GetAll();
    int Counter();
    Task<Payment> GetById(Guid id);
    Task<Payment> GetByCode(string code);
    Task<Payment> GetByInitials(string initials);
    Task<Payment> GetByPaymentName(string paymentName);
    Payment Create(Payment payment);
    Payment Update(Payment payment);
    Payment Delete(Payment payment);
    Task<IEnumerable<Payment>> Search(string name);
}