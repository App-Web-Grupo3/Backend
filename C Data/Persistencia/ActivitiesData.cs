using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class ActivitiesData : IActivitiesData
{
    private readonly AppDbContext _appDbContext;

    public ActivitiesData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Activities> GetById(int id)
    {
        return await _appDbContext.Activities.Where(r => r.Id == id && r.IsActive == true).FirstOrDefaultAsync();

    }

    public async Task<List<Activities>> GetByTitle(Activities activity)
    {
        return await _appDbContext.Activities.Where(a => a.Title.Contains(activity.Title) && a.IsActive == true)
            .ToListAsync();
    }

    public async Task<List<Activities>> GetAll()
    {
        return await _appDbContext.Activities.Where(r => r.IsActive == true).ToListAsync();

    }

    public async Task<bool> Create(Activities activity)
    {
        try
        {
            _appDbContext.Activities.Add(activity);
            await _appDbContext.SaveChangesAsync();
            Console.WriteLine("Data:)");

            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("pipipiData");
            return false;
        }
    }

    public async Task<bool> Update(Activities activity, int id)
    {
        try
        {
            var activityUpdated = _appDbContext.Activities.Where(r => r.Id == id).FirstOrDefault();

            activityUpdated.Title = activity.Title;
            activityUpdated.Description = activity.Description;
            activityUpdated.Discount = activity.Discount;
            activityUpdated.Percentage = activity.Percentage;
            activityUpdated.Restriction = activity.Restriction;
            activityUpdated.People = activity.People;
            activityUpdated.Price = activity.Price;
            activityUpdated.IsActive = activity.IsActive;
            activityUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Activities.Update(activityUpdated);
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
            var responseDeleted = _appDbContext.Activities.Where(r => r.Id == id).FirstOrDefault();

            responseDeleted.IsActive = false;
            responseDeleted.DateUpdated = DateTime.Now;
            _appDbContext.Activities.Update(responseDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}