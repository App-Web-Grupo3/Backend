using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class CommentDomain :ICommentDomain
{
    private readonly ICommentData _commentData;
    
    public CommentDomain(ICommentData commentData)
    {
        _commentData = commentData;
    }
    
    public async Task<Comment> GetById(int id)
    {
        var result = await _commentData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Response not found");

        return result;
    }

    public async Task<List<Comment>> GetByContent(Comment content)
    {
        return await _commentData.GetByContent(content);
    }

    public async Task<List<Comment>> GetAll()
    {
        return await _commentData.GetAll();
    }

    public async Task<bool> Create(Comment content)
    {
        try
        {
            var result = await _commentData.GetByContent(content);

            if (result != null && result.Count == 0)
            {
                Console.WriteLine("Domain:)");
                return await _commentData.Create(content);
            }
            Console.WriteLine("pipipiDomain");
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "pipipi");
        }
    }

    public async Task<bool> Update(Comment content, int id)
    {
        try
        {
            var result = await _commentData.GetByContent(content);

            if (result != null && result.Count == 0)
            {
                return await _commentData.Update(content, id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var result = await _commentData.GetById(id);

            if (result != null)
            {
                return await _commentData.Delete(id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}