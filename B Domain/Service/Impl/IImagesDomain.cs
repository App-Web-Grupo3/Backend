using Data.Model;

namespace Domain.Service.Impl;

public interface IImagesDomain
{
    public Task<Images> GetById(int id);
    public Task<List<Images>> GetAll();
    public Task<ApiResponse<Images>> AddImage(Images image);
    public Task<bool> Update(Images images, int id);
    public Task<bool> Delete(int id);
}