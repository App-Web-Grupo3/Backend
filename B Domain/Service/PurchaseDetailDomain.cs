using Data.Model;
using Data.Persistencia;
using Data.Persistencia.Impl;

namespace Domain.Service;

public class PurchaseDetailDomain : IPurchaseDetailDomain
{
    private readonly IPurchaseDetailData _purchaseDetailData;
    
    public PurchaseDetailDomain(IPurchaseDetailData purchaseDetailData)
    {
        _purchaseDetailData = purchaseDetailData;
    }
    public async Task<PurchaseDetail> GetById(int id)
    {
        var result = await _purchaseDetailData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Company not found");
        return result;
    }

    public async Task<List<PurchaseDetail>> GetByState(PurchaseDetail purchaseDetail)
    {
        var result = await _purchaseDetailData.GetByState(purchaseDetail);
        if (result == null)
            throw new KeyNotFoundException("Name of Company not found");
        return result;
    }

    public async Task<List<PurchaseDetail>> GetAll()
    {
        var result = await _purchaseDetailData.GetAll();
        if (result == null)
            throw new KeyNotFoundException("We dont' have registered companies");
        return result;
    }

    public async Task<bool> Create(PurchaseDetail purchaseDetail)
    {
        try
        {
            var result = await _purchaseDetailData.GetByState(purchaseDetail);

            if (result != null && result.Count == 0)
            {
                return await _purchaseDetailData.Create(purchaseDetail);
            }

            return false;
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
            var result = await _purchaseDetailData.GetByState(purchaseDetail);

            if (result != null && result.Count == 0)
            {
                return await _purchaseDetailData.Update(purchaseDetail, id);
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
            var result = await _purchaseDetailData.GetById(id);

            if (result != null )
            {
                return await _purchaseDetailData.Delete(id);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}