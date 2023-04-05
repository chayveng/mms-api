using Microsoft.EntityFrameworkCore;
using mms_api.Domain.Payment;
using mms_api.Infrastucture;

namespace mms_api.Repository;

public class PaymentRepository : IPaymentRepository
{
    private readonly DatabaseContext _context;

    public PaymentRepository(DatabaseContext context)
    {
        _context = context;
    }

    public bool SaveChanges()
    {
        return (_context.SaveChanges() >= 0);
    }

    public IQueryable<Payment> GetQuery()
    {
        return _context.Payments;
    }

    public IEnumerable<Payment> GetAll()
    {
        return _context.Payments.ToList();
    }

    public async Task<Payment> GetById(Guid id)
    {
        var result = await _context.Payments.FirstOrDefaultAsync(e => e.Id == id);
        return result;
    }

    public async Task<Payment> GetByCode(string code)
    {
        var result = await _context.Payments.FirstOrDefaultAsync(e => e.Code == code);
        return result;
    }

    public async Task<Payment> GetByInitials(string initials)
    {
        var result = await _context.Payments.FirstOrDefaultAsync(e => e.Initials == initials);
        return result;
    }

    public async Task<Payment> GetByPaymentName(string paymentName)
    {
        var result = await _context.Payments.FirstOrDefaultAsync(e => e.PaymentName == paymentName);
        return result;
    }

    public Payment Create(Payment payment)
    {
        var entity = _context.Payments.Add(payment);
        return entity.Entity;
    }

    public Payment Update(Payment payment)
    {
        var entity = _context.Payments.Update(payment);
        return entity.Entity;
    }

    public Payment Delete(Payment payment)
    {
        var entity = _context.Payments.Remove(payment);
        return entity.Entity;
    }
}