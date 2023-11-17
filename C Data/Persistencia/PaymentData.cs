using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class PaymentData: IPaymentData
{
    private readonly AppDbContext _appDbContext;
    
    public PaymentData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Payment> GetById(int id)
    {
        return await _appDbContext.Payments.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<Payment>> GetAll()
    {
        return await _appDbContext.Payments.Where(c => c.IsActive == true).ToListAsync();
    }
    
    public async Task<List<Payment>> GetByAmount(Payment payment)
    {
        return await _appDbContext.Payments
            .Where(c => c.Amount == payment.Amount && c.IsActive == true)
            .ToListAsync();
    }



    public async Task<bool> Create(Payment payment)
    {
        try
        {
            _appDbContext.Payments.Add(payment);
            await _appDbContext.SaveChangesAsync();

            return true;
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
            var paymentUpdated = _appDbContext.Payments.Where(c => c.Id == id).FirstOrDefault();

            paymentUpdated.Month = payment.Month;
            paymentUpdated.Year = payment.Year;
            paymentUpdated.Amount = payment.Amount;
            paymentUpdated.TaxInformation = payment.TaxInformation;
            
            paymentUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Payments.Update(paymentUpdated);
            await _appDbContext.SaveChangesAsync();
            return true;
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
            var paymentDeleted = _appDbContext.Payments.Where(c => c.Id == id).FirstOrDefault();
            
            paymentDeleted.IsActive = false;
            paymentDeleted.DateUpdated = DateTime.Now;

            _appDbContext.Payments.Update(paymentDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}