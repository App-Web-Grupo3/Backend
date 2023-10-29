using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class ActivitiesDomain : IActivitiesDomain
{
    private readonly IActivitiesData _activitiesData;
    
    public ActivitiesDomain(IActivitiesData activitiesData)
    {
        _activitiesData = activitiesData;
    }
    
    public async Task<Activities> GetById(int id)
    {
        var result = await _activitiesData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Response not found");

        return result;
    }

    public async Task<List<Activities>> GetByTitle(Activities title)
    {
        return await _activitiesData.GetByTitle(title);
    }

    public async Task<List<Activities>> GetAll()
    {
        return await _activitiesData.GetAll();
    }

    public async Task<bool> Create(Activities activity)
    {
        try
        {
            var result = await _activitiesData.GetByTitle(activity);

            if (result != null && result.Count == 0)
            {
                Console.WriteLine("Domain:)");
                return _activitiesData.Create(activity);
            }
            Console.WriteLine("pipipiDomain");
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message + "pipipi");
        }
    }

    public async Task<bool> Update(Activities activity, int id)
    {
        try
        {
            var result = await _activitiesData.GetByTitle(activity);

            if (result != null && result.Count == 0)
            {
                return await _activitiesData.Update(activity, id);
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
            var result = await _activitiesData.GetById(id);

            if (result != null)
            {
                return await _activitiesData.Delete(id);
            }
            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}