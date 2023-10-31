using Data.Model;

namespace Data.Persistencia.Impl;

public interface IActivitiesData
{
    public Task<Activities> GetById(int id);
    public Task<List<Activities>> GetByTitle(Activities title);
    public Task<List<Activities>> GetAll();
    public Task<bool> Create(Activities activity);
    public Task<bool> Update(Activities activity, int id);
    public Task<bool> Delete(int id);
}