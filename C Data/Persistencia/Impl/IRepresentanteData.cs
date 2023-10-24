using Data.Model;

namespace Data.Persistencia.Impl;

public interface IRepresentanteData
{
    Task<IEnumerable<Representante>> ListAsync();
    Task AddAsync(Representante representante);
    Task<Representante> FindByIdAsync(int id);
    void Update(Representante representante);
    void Remove(Representante representante);
}