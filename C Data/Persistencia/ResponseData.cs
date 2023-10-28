using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class ResponseData : IResponseData
{
    private readonly AppDbContext _appDbContext;

    public ResponseData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Answer> GetById(int id)
    {
        return await _appDbContext.Responses.Where(r => r.Id == id && r.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<Answer>> GetByResponse(Answer answer)
    {
        return await _appDbContext.Responses.Where(r => r.response.Contains(answer.response) && r.IsActive == true)
            .ToListAsync();
    }


    public async Task<List<Answer>> GetAll()
    {
        return await _appDbContext.Responses.Where(r => r.IsActive == true).ToListAsync();
    }

    public async Task<bool> Create(Answer answer)
    {
        try
        {
            _appDbContext.Responses.Add(answer);
            await _appDbContext.SaveChangesAsync();

            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Answer answer, int id)
    {
        try
        {
            var responseUpdated = _appDbContext.Responses.Where(r => r.Id == id).FirstOrDefault();

            responseUpdated.response = answer.response;
            responseUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Responses.Update(responseUpdated);
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
            var responseDeleted = _appDbContext.Responses.Where(r => r.Id == id).FirstOrDefault();

            responseDeleted.IsActive = false;
            responseDeleted.DateUpdated = DateTime.Now;
            _appDbContext.Responses.Update(responseDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}