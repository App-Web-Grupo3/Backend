using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class PaymentDomain:IPaymentDomain
{
     private readonly IPaymentData _paymentData;
    
    public PaymentDomain(IPaymentData paymentData)
    {
        _paymentData = paymentData;
    }
    public async Task<Payment> GetById(int id)
    {
        var result = await _paymentData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Company not found");
        return result;
    }
    
    public async Task<List<Payment>> GetByAmount(Payment payment)
    {
        var result = await _paymentData.GetByAmount(payment);
        if (result == null)
            throw new KeyNotFoundException("Company not found");
        return result;
    }
    
    public async Task<List<Payment>> GetAll()
    {
        var result = await _paymentData.GetAll();
        if (result == null)
            throw new KeyNotFoundException("We dont' have registered companies");
        return result;
    }

    public async Task<bool> Create(Payment payment)
    {
        try
        {
            var result = await _paymentData.GetByAmount(payment);

            if (result != null )
            {
                return await _paymentData.Create(payment);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Payment payment, int id)
    {
        try
        {
            var result = await _paymentData.GetByAmount(payment);

            if (result != null)
            {
                return await _paymentData.Update(payment, id);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _paymentData.GetById(id);

            if (result != null )
            {
                return await _paymentData.Delete(id);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}