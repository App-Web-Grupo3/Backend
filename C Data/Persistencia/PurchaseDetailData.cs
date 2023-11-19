using Data.Context;
using Data.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class PurchaseDetailData : IPurchaseDetailData
{
     private readonly AppDbContext _appDbContext;
    
    public PurchaseDetailData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<PurchaseDetail> GetById(int id)
    {
        return await _appDbContext.PurchaseDetails.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<PurchaseDetail>> GetByState(PurchaseDetail purchaseDetail)
    {
        return await _appDbContext.PurchaseDetails.Where(c => c.State.Contains(purchaseDetail.State)
                                                              && c.IsActive == true).ToListAsync();
    }

    public async Task<List<PurchaseDetail>> GetAll()
    {
        return await _appDbContext.PurchaseDetails.Where(c => c.IsActive == true).ToListAsync();
    }
    
    public async Task<bool> Create(PurchaseDetail purchaseDetail)
    {
        try
        {
            _appDbContext.PurchaseDetails.Add(purchaseDetail);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(PurchaseDetail purchaseDetail, int id)
    {
        try
        {
            var purchaseDetailUpdated = _appDbContext.PurchaseDetails.Where(c => c.Id == id).FirstOrDefault();

            purchaseDetailUpdated.State = purchaseDetailUpdated.State;
            purchaseDetailUpdated.PricePaid = purchaseDetailUpdated.PricePaid;
            purchaseDetailUpdated.DepartureDate = purchaseDetailUpdated.DepartureDate;
            purchaseDetailUpdated.PaymentDate = purchaseDetailUpdated.PaymentDate;
            purchaseDetailUpdated.DateUpdated = DateTime.Now;

            _appDbContext.PurchaseDetails.Update(purchaseDetailUpdated);
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
            var purchaseDetailDeleted = _appDbContext.PurchaseDetails.Where(c => c.Id == id).FirstOrDefault();
            
            purchaseDetailDeleted.IsActive = false;
            purchaseDetailDeleted.DateUpdated = DateTime.Now;

            _appDbContext.PurchaseDetails.Update(purchaseDetailDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}