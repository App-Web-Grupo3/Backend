using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class PaymentMethodData : IPaymentMethodData
{
    private readonly AppDbContext _appDbContext;
    
    public PaymentMethodData( AppDbContext appDbContext) 
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<IEnumerable<PaymentMethod>> ListAsync()
    {
        return await _appDbContext.PaymentMethods.ToListAsync();
    }

    public async Task AddAsync(PaymentMethod paymentMethod)
    {
        
        _appDbContext.PaymentMethods.AddAsync(paymentMethod);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<PaymentMethod> FindByIdAsync(int id)
    {
        return await _appDbContext.PaymentMethods.FindAsync(id);
    }

    public void Update(PaymentMethod paymentMethod)
    {
        _appDbContext.PaymentMethods.Update(paymentMethod);
        _appDbContext.SaveChangesAsync();
    }

    public void Remove(PaymentMethod paymentMethod)
    {
        _appDbContext.PaymentMethods.Remove(paymentMethod);
        _appDbContext.SaveChangesAsync();
    }
}