using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class TouristDomain : ITouristDomain
{
    private readonly ITouristData _touristData;
    
    public TouristDomain(ITouristData touristData)
    {
        _touristData = touristData;
    }
    
    public async Task<Tourist> GetById(int id)
    {
        var result = await _touristData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Tourist not found");

        return result;
    }

    public async Task<List<Tourist>> GetByName(Tourist tourist)
    {
        return await _touristData.GetByName(tourist);
    }

    public async Task<List<Tourist>> GetAll()
    {
        return await _touristData.GetAll();
    }

    public async Task<List<Tourist>> GetByPhone(Tourist tourist)
    {
        return await _touristData.GetByPhone(tourist);
    }


    public async Task<bool> Create(Tourist tourist)
    {
        try
        {
            var result = await _touristData.GetByPhone(tourist);

            if (result != null && result.Count == 0)
            {
                return await _touristData.Create(tourist);
            }

            return false;
        }
        catch (Exception e)
        {
            return false;
        }

    }

    public async Task<bool> Update(Tourist tourist, int id)
    {
        try
        {
            var result = await _touristData.GetByPhone(tourist);

            if (result != null && result.Count == 0)
            {
                return await _touristData.Update(tourist, id);
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
            var result = await _touristData.GetById(id);

            if (result != null)
            {
                return await _touristData.Delete(id);
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}