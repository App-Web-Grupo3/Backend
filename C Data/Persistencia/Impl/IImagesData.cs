using Data.Model;

namespace Data.Persistencia.Impl;

public interface IImagesData
{
    public Task<Images> GetById(int id);
    public Task<List<Images>> GetAll();
    public Task<Images> Create(Images images);
    public Task<bool> Update(Images images, int id);
    public Task<bool> Delete(int id);
}