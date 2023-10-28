using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;

namespace Data.Persistencia;

public class ActivitiesData : IActivitiesData
{
    private readonly AppDbContext _appDbContext;

    public ActivitiesData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public Task<Activities> GetById(int id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Activities>> GetByTitle(Activities answer)
    {
        throw new NotImplementedException();
    }

    public Task<List<Activities>> GetAll()
    {
        throw new NotImplementedException();
    }

    public Task<bool> Create(Activities answer)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Update(Activities answer, int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> Delete(int id)
    {
        throw new NotImplementedException();
    }
}