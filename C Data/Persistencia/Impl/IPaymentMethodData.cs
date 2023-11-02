using Data.Model;

namespace Data.Persistencia.Impl;

public interface IPaymentMethodData
{
    Task AddAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> FindByIdAsync(int id);
    void Update(PaymentMethod paymentMethod);
    void Remove(PaymentMethod paymentMethod);
    Task<IEnumerable<PaymentMethod>> ListAsync();
}