using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class RepresentativeDomain : IRepresentativeDomain
{
    private readonly IRepresentativeData _representativeData;
    public RepresentativeDomain(IRepresentativeData representativeData)
    {
        _representativeData = representativeData;
    }
    
    
    public async Task<IEnumerable<Representative>> ListAsync()
    {
        return await _representativeData.ListAsync();
    }

    public async Task<Representative> SaveAsync(Representative representative)
    {
        try
        {
            await _representativeData.AddAsync(representative);
            return representative;
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task<Representative> UpdateAsync(int id, Representative representative)
    {
        var existeRepresentante = await _representativeData.FindByIdAsync(id);
        if(existeRepresentante == null)
            throw new Exception("Representative not found");
        
        
        existeRepresentante.LastName= representative.LastName;
        existeRepresentante.Name = representative.Name;
        existeRepresentante.Password = representative.Password;
        existeRepresentante.Mail = representative.Mail;
        existeRepresentante.Phone = representative.Phone;

        try
        {
            _representativeData.Update(existeRepresentante);
            return existeRepresentante;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task<Representative> DeleteAsync(int id)
    {
        var existeRepresentante = await _representativeData.FindByIdAsync(id);
        if(existeRepresentante == null)
            throw new Exception("Representative not found");
        
        

        try
        {
            _representativeData.Remove(existeRepresentante);
            return existeRepresentante;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Representative> GetByIdAsync(int id)
    {
        var existe = await _representativeData.FindByIdAsync(id);
        if (existe == null)
            throw new KeyNotFoundException("Representative not found");

        return existe;
    }
}
