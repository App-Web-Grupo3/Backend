using Data.Model;


namespace Domain.Service.Impl;

public interface IRepresentanteDomain
{
    Task < IEnumerable < Representante >> ListAsync();
    Task <Representante> SaveAsync(Representante representante);
    Task<Representante> UpdateAsync(int idRepresentante, Representante representante);
    Task<Representante> DeleteAsync(int idRepresentante);
    Task<Representante> GetByIdAsync(int idRepresentante);
    
}

