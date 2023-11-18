namespace Data.Persistencia;

public interface IPurchaseDetail
{
    public Task<PurchaseDetail> GetById(int id);
    public Task<List<PurchaseDetail>> GetByState(PurchaseDetail purchaseDetail);
    public Task<List<PurchaseDetail>> GetAll();
    public Task<bool> Create(PurchaseDetail purchaseDetail);
    public Task<bool> Update(PurchaseDetail purchaseDetail, int id);
    public Task<bool> Delete(int id);
}