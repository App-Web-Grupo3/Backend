using Data.Model;

namespace Data.Persistencia.Impl;

public interface ICommentData
{
    public Task<Comment> GetById(int id);
    public Task<List<Comment>> GetByContent(Comment comment);
    public Task<List<Comment>> GetAll();
    public Task<bool> Create(Comment comment);
    public Task<bool> Update(Comment comment, int id);
    public Task<bool> Delete(int id);
}