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
        return await _appDbContext.PaymentMethod.ToListAsync();
    }

    public async Task AddAsync(PaymentMethod paymentMethod)
    {
        
        _appDbContext.PaymentMethod.AddAsync(paymentMethod);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<PaymentMethod> FindByIdAsync(int id)
    {
        return await _appDbContext.PaymentMethod.FindAsync(id);
    }

    public void Update(PaymentMethod paymentMethod)
    {
        _appDbContext.PaymentMethod.Update(paymentMethod);
        _appDbContext.SaveChangesAsync();
    }

    public void Remove(PaymentMethod paymentMethod)
    {
        _appDbContext.PaymentMethod.Remove(paymentMethod);
        _appDbContext.SaveChangesAsync();
    }
}