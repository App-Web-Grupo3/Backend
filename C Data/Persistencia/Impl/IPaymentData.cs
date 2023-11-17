using Data.Model;

namespace Data.Persistencia.Impl;

public interface IPaymentData
{
    public Task<Payment> GetById(int id);
    public Task<List<Payment>> GetAll();
    public Task<List<Payment>> GetByAmount(Payment payment);
    public Task<bool> Create(Payment payment);
    public Task<bool> Update(Payment payment, int id);
    public Task<bool> Delete(int id);
}