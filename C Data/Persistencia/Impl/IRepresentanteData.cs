using Data.Model;

namespace Data.Persistencia.Impl;

public interface IRepresentativeData
{
    Task<IEnumerable<Representative>> ListAsync();
    Task AddAsync(Representative representative);
    Task<Representative> FindByIdAsync(int id);
    void Update(Representative representative);
    void Remove(Representative representative);
}