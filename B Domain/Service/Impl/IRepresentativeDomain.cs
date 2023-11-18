using Data.Model;


namespace Domain.Service.Impl;

public interface IRepresentativeDomain
{
    Task < IEnumerable < Representative >> ListAsync();
    Task <Representative> SaveAsync(Representative representative);
    Task<Representative> UpdateAsync(int id, Representative representative);
    Task<Representative> DeleteAsync(int id);
    Task<Representative> GetByIdAsync(int id);
    
}

