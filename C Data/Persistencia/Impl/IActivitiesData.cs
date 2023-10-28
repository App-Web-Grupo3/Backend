using Data.Model;

namespace Data.Persistencia.Impl;

public interface IActivitiesData
{
    public Task<Activities> GetById(int id);
    public Task<List<Activities>> GetByTitle(Activities answer);
    public Task<List<Activities>> GetAll();
    public Task<bool> Create(Activities answer);
    public Task<bool> Update(Activities answer, int id);
    public Task<bool> Delete(int id);
}