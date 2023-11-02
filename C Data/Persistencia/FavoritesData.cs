using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia
{
    public class FavoritesData : IFavoritesData
    {
        private readonly AppDbContext _appDbContext;

        public FavoritesData(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<Favorites> GetById(int id)
        {
            return await _appDbContext.Favorites.Where(f => f.Id == id && f.IsActive == true).FirstOrDefaultAsync();
        }

        public async Task<List<Favorites>> GetAll()
        {
            return await _appDbContext.Favorites.Where(f => f.IsActive == true).ToListAsync();
        }

        public async Task<bool> Create(Favorites favorites)
        {
            try
            {
                _appDbContext.Favorites.Add(favorites);
                await _appDbContext.SaveChangesAsync();

                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Update(Favorites favorites)
        {
            try
            {
                var existingFavorites = await _appDbContext.Favorites.FindAsync(favorites.Id);

                if (existingFavorites != null)
                {
                    existingFavorites.TouristId = favorites.TouristId;
                    existingFavorites.ActivitiesId = favorites.ActivitiesId;
                    existingFavorites.DateUpdated = DateTime.Now;

                    _appDbContext.Favorites.Update(existingFavorites);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public async Task<bool> Delete(int favorites)
        {
            try
            {
                var existingFavorites = await _appDbContext.Favorites.FindAsync(favorites.ToString());

                if (existingFavorites != null)
                {
                    existingFavorites.IsActive = false;
                    existingFavorites.DateUpdated = DateTime.Now;
                    _appDbContext.Favorites.Update(existingFavorites);
                    await _appDbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
