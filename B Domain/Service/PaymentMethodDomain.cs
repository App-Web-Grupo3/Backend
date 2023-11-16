using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class PaymentMethodDomain : IPaymentMethodDomain
{
    private readonly IPaymentMethodData _paymentMethodDataData;
    public PaymentMethodDomain(IPaymentMethodData paymentMethodDataData)
    {
        _paymentMethodDataData = paymentMethodDataData;
    }
    
    
    public async Task<IEnumerable<PaymentMethod>> ListAsync()
    {
        return await _paymentMethodDataData.ListAsync();
    }

    public async Task<PaymentMethod> SaveAsync(PaymentMethod paymentMethod)
    {
        try
        {
            await _paymentMethodDataData.AddAsync(paymentMethod);
            return paymentMethod;
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task<PaymentMethod> UpdateAsync(int idPaymentMethod, PaymentMethod paymentMethod)
    {
        var existePaymentMethod = await _paymentMethodDataData.FindByIdAsync(idPaymentMethod);
        if(existePaymentMethod == null)
            throw new Exception("PaymentMethod no encontrado");
        
        
        existePaymentMethod.CardNumber= paymentMethod.CardNumber;
        existePaymentMethod.AccountHolderName = paymentMethod.AccountHolderName;
        existePaymentMethod.Month= paymentMethod.Month;
        existePaymentMethod.Year = paymentMethod.Year;
        existePaymentMethod.CVC= paymentMethod.CVC;
        existePaymentMethod.TouristId = paymentMethod.TouristId;
        
        try
        {
            _paymentMethodDataData.Update(existePaymentMethod);
            return existePaymentMethod;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task<PaymentMethod> DeleteAsync(int idPaymentMethod)
    {
        var existePaymentMethod = await _paymentMethodDataData.FindByIdAsync(idPaymentMethod);
        if(existePaymentMethod == null)
            throw new Exception("PaymentMethod no encontrado");
        
        

        try
        {
            _paymentMethodDataData.Remove(existePaymentMethod);
            return existePaymentMethod;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<PaymentMethod> GetByIdAsync(int idPaymentMethod)
    {
        var existe = await _paymentMethodDataData.FindByIdAsync(idPaymentMethod);
        if (existe == null)
            throw new KeyNotFoundException("PaymentMethod no encontrado");

        return existe;
    }    
}
