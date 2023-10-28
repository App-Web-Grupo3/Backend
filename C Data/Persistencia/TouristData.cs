using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class TouristData : ITouristData
{
    private readonly AppDbContext _appDbContext;

    public TouristData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Tourist> GetById(int id)
    {
        return await _appDbContext.Tourists.Where(t => t.Id == id && t.IsActive == true).FirstOrDefaultAsync();
    }

    public async Task<List<Tourist>> GetByName(Tourist tourist)
    {
        return await _appDbContext.Tourists.Where(t => t.Name.Contains(tourist.Name)
                                                    && t.IsActive == true).ToListAsync();
    }

    public async Task<List<Tourist>> GetAll()
    {
        return await _appDbContext.Tourists.Where(t => t.IsActive == true).ToListAsync();
    }

    public async Task<List<Tourist>> GetByPhone(Tourist tourist)
    {
        return await _appDbContext.Tourists.Where(t => t.Phone.Contains(tourist.Phone)
                                                       && t.IsActive == true).ToListAsync();
    }

    public async Task<bool> Create(Tourist tourist)
    {
        try
        {
            _appDbContext.Tourists.Add(tourist);
            await _appDbContext.SaveChangesAsync();

            return true;
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
            var touristUpdated = _appDbContext.Tourists.Where(t => t.Id == id).FirstOrDefault();

            touristUpdated.Name = tourist.Name;
            touristUpdated.LastName = tourist.LastName;
            touristUpdated.Mail = tourist.Mail;
            touristUpdated.Password = tourist.Password;
            touristUpdated.Phone = tourist.Phone;
            touristUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Tourists.Update(touristUpdated);
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
            var touristDeleted = _appDbContext.Tourists.Where(t => t.Id == id).FirstOrDefault();

            touristDeleted.IsActive = false;
            touristDeleted.DateUpdated = DateTime.Now;
            _appDbContext.Tourists.Update(touristDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}