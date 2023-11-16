using Data.Model;

namespace Domain.Service.Impl;

public interface ICommentDomain
{
    public Task<Comment> GetById(int id);
    public Task<List<Comment>> GetByContent(Comment content);
    public Task<List<Comment>> GetAll();
    public Task<bool> Create(Comment comment);
    public Task<bool> Update(Comment comment, int id);
    public Task<bool> Delete(int id);
}