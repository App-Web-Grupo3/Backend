using Data.Model;

namespace Domain.Service.Impl;

public interface IImagesDomain
{
    public Task<Images> GetById(int id);
    public Task<List<Images>> GetAll();
    public Task<bool> Create(Images images);
    public Task<bool> Update(Images images, int id);
    public Task<bool> Delete(int id);
}