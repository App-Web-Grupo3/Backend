using Data.Model;

namespace Domain.Service.Impl;

public interface IActivitiesDomain
{
    public Task<Activities> GetById(int id);
    public Task<List<Activities>> GetByTitle(Activities title);
    public Task<List<Activities>> GetAll();
    public Task<ApiResponse<Activities>> AddActivity(Activities activity);
    public Task<bool> Update(Activities title, int id);
    public Task<bool> Delete(int id);
    
}