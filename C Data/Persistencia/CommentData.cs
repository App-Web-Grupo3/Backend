using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class CommentData :ICommentData
{
    private readonly AppDbContext _appDbContext;
    
    public CommentData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<Comment> GetById(int id)
    {
        return await _appDbContext.Comments.Where(c => c.Id == id && c.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<Comment>> GetByContent(Comment comment)
    {
        return await _appDbContext.Comments.Where(c => c.Content.Contains(comment.Content)
                                                       && c.IsActive == true).ToListAsync();
        
    }

    public async Task<List<Comment>> GetAll()
    {
        return await _appDbContext.Comments.Where(c => c.IsActive == true).ToListAsync();
    }
    

    public async Task<bool> Create(Comment comment)
    {
        try
        {
            _appDbContext.Comments.Add(comment);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Comment comment, int id)
    {
        try
        {
            var commentUpdated = _appDbContext.Comments.Where(c => c.Id == id).FirstOrDefault();

            commentUpdated.Content = comment.Content;
            commentUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Comments.Update(commentUpdated);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Delete(int id)
    {
        try
        {
            var commentDeleted = _appDbContext.Comments.Where(c => c.Id == id).FirstOrDefault();
            
            commentDeleted.IsActive = false;
            commentDeleted.DateUpdated = DateTime.Now;

            _appDbContext.Comments.Update(commentDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}