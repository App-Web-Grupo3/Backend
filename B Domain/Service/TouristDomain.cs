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

    public async Task<List<Tourist>> GetFilteredData(Tourist tourist)
    {
        return await _touristData.GetFilteredData(tourist);
    }

    public async Task<List<Tourist>> GetAll()
    {
        return await _touristData.GetAll();
    }

    public async Task<bool> GetByPhone(string phone)
    {
        var result = await _touristData.GetByPhone(phone);
        if (result == false)
            throw new KeyNotFoundException("Phone not found");

        return result;
    }

    public async Task<bool> Create(Tourist tourist)
    {

            var result = await _touristData.GetByPhone(tourist.Phone);

            if (!result)
            {
                return await _touristData.Create(tourist);
            }

            return false;

    }

    public async Task<bool> Update(Tourist tourist, int id)
    {
        try
        {
            var result = await _touristData.GetByPhone(tourist.Phone);

            if (!result)
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