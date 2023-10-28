using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class ResponseDomain : IResponseDomain
{
    private readonly IResponseData _responseData;
    
    public ResponseDomain(IResponseData responseData)
    {
        _responseData = responseData;
    }
    public async Task<Answer> GetById(int id)
    {
        var result = await _responseData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Response not found");

        return result;
    }

    public async Task<List<Answer>> GetByResponse(Answer answer)
    {
        return await _responseData.GetByResponse(answer);
    }

    public async Task<List<Answer>> GetAll()
    {
        return await _responseData.GetAll();
    }

    public async Task<bool> Create(Answer answer)
    {
        try
        {
            var result = await _responseData.GetByResponse(answer);

            if (result != null && result.Count == 0)
            {
                return await _responseData.Create(answer);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }


    public async Task<bool> Update(Answer answer, int id)
    {
        try
        {
            var result = await _responseData.GetByResponse(answer);

            if (result != null && result.Count == 0)
            {
                return await _responseData.Update(answer, id);
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
            var result = await _responseData.GetById(id);

            if (result != null)
            {
                return await _responseData.Delete(id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}