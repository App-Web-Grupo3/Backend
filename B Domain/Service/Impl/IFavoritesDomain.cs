using Data.Model;

namespace Domain.Service.Impl
{
    public interface IFavoritesDomain
    {
        Task<Favorites> GetById(int id);
        Task<List<Favorites>> GetAll();
        Task<bool> Create(Favorites favorites);
        Task<bool> Update(Favorites favorites, int id);
        Task<bool> Delete(int id);
        
    }
}