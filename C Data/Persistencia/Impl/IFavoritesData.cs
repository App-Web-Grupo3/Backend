using Data.Model;

namespace Data.Persistencia.Impl
{
    public interface IFavoritesData
    {
        Task<Favorites> GetById(int id);
        Task<List<Favorites>> GetAll();
        Task<bool> Create(Favorites favorites);
        Task<bool> Update(Favorites favorites);
        Task<bool> Delete(int favorites);
    }
}