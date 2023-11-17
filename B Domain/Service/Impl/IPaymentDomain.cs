using Data.Model;

namespace Domain.Service.Impl;

public interface IPaymentDomain
{
    public Task<Payment> GetById(int id);
    public Task<List<Payment>> GetByAmount(Payment payment);
    public Task<List<Payment>> GetAll();
    
    public Task<bool> Create(Payment payment);
    public Task<bool> Update(Payment payment, int id);
    public Task<bool> Delete(int id);

}