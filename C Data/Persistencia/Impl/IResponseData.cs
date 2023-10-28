using Data.Model;

namespace Data.Persistencia.Impl;

public interface IResponseData
{
    public Task<Answer> GetById(int id);
    public Task<List<Answer>> GetByResponse(Answer answer);
    public Task<List<Answer>> GetAll();
    public Task<bool> Create(Answer answer);
    public Task<bool> Update(Answer answer, int id);
    public Task<bool> Delete(int id);
}