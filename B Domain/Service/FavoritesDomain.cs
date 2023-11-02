using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class FavoritesDomain : IFavoritesDomain
{
    private readonly IFavoritesData _favoritesData;

    public FavoritesDomain(IFavoritesData favoritesData)
    {
        _favoritesData = favoritesData;
    }

    public async Task<Favorites> GetById(int id)
    {
        var result = await _favoritesData.GetById(id);
        if (result == null)
            throw new KeyNotFoundException("Favorites not found");

        return result;
    }

    public async Task<List<Favorites>> GetAll()
    {
        return await _favoritesData.GetAll();
    }

    public async Task<bool> Create(Favorites favorites)
    {
        try
        {
            return await _favoritesData.Create(favorites);
        }
        catch (Exception e)
        {
            return false;
        }
    }

    public async Task<bool> Update(Favorites favorites, int id)
    {
        try
        {
            var result = await _favoritesData.GetById(id);

            if (result != null)
            {
                favorites.Id = id; // Asegura que el ID sea el correcto
                return await _favoritesData.Update(favorites);
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
            var result = await _favoritesData.GetById(id);

            if (result != null)
            {
                return await _favoritesData.Delete(id);
            }

            return false;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }
}
