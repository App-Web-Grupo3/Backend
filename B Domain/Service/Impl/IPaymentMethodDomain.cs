using Data.Model;

namespace Domain.Service.Impl;

public interface IPaymentMethodDomain
{
    Task < IEnumerable < PaymentMethod >> ListAsync();
    Task <PaymentMethod> SaveAsync(PaymentMethod paymentMethod);
    Task<PaymentMethod> UpdateAsync(int idPaymentMethod, PaymentMethod paymentMethod);
    Task<PaymentMethod> DeleteAsync(int idPaymentMethod);
    Task<PaymentMethod> GetByIdAsync(int idPaymentMethod);
}