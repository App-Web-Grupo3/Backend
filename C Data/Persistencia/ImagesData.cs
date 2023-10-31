using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class ImagesData : IImagesData
{
    private readonly AppDbContext _appDbContext;

    public ImagesData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<Images> GetById(int id)
    {
        return await _appDbContext.Images.Where(r => r.Id == id && r.IsActive == true).FirstOrDefaultAsync();

    }

    public async Task<List<Images>> GetAll()
    {
        return await _appDbContext.Images.Where(r => r.IsActive == true).ToListAsync();

    }

    public async Task<bool> Create(Images images)
    {
        try
        {
            _appDbContext.Images.Add(images);
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

    public async Task<bool> Update(Images images, int id)
    {
        try
        {
            var imagesUpdated = _appDbContext.Images.Where(r => r.Id == id).FirstOrDefault();

            imagesUpdated.Url = images.Url;
            imagesUpdated.IsActive = images.IsActive;
            imagesUpdated.DateUpdated = DateTime.Now;

            _appDbContext.Images.Update(imagesUpdated);
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
            var imagesDeleted = _appDbContext.Images.Where(r => r.Id == id).FirstOrDefault();

            imagesDeleted.IsActive = false;
            imagesDeleted.DateUpdated = DateTime.Now;
            _appDbContext.Images.Update(imagesDeleted);
            await _appDbContext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            return false;
        }
    }
}