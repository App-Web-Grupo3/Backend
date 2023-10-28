using Data.Model;

namespace Domain.Service.Impl;

public interface ITouristDomain
{
    public Task<Tourist> GetById(int id);
    public Task<List<Tourist>> GetByName(Tourist tourist);
    public Task<List<Tourist>> GetAll();
    public Task<List<Tourist>> GetByPhone(Tourist tourist);
    public Task<bool> Create(Tourist tourist);
    public Task<bool> Update(Tourist tourist, int id);
    public Task<bool> Delete(int id);
}