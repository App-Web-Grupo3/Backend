using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;

namespace Domain.Service;

public class RepresentanteDomain : IRepresentanteDomain
{
    private readonly IRepresentanteData _representanteData;
    public RepresentanteDomain(IRepresentanteData representanteData)
    {
        _representanteData = representanteData;
    }
    
    
    public async Task<IEnumerable<Representante>> ListAsync()
    {
        return await _representanteData.ListAsync();
    }

    public async Task<Representante> SaveAsync(Representante representante)
    {
        try
        {
            await _representanteData.AddAsync(representante);
            return representante;
        }
        catch(Exception e)
        {
            throw new Exception(e.Message);
        }

    }

    public async Task<Representante> UpdateAsync(int idRepresentante, Representante representante)
    {
        var existeRepresentante = await _representanteData.FindByIdAsync(idRepresentante);
        if(existeRepresentante == null)
            throw new Exception("Representante no encontrado");
        
        
        existeRepresentante.Apellido= representante.Apellido;
        existeRepresentante.Nombre = representante.Nombre;
        existeRepresentante.Contrasenia = representante.Contrasenia;
        existeRepresentante.Correo= representante.Correo;
        existeRepresentante.Telefono= representante.Telefono;

        try
        {
            _representanteData.Update(existeRepresentante);
            return existeRepresentante;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
        
    }

    public async Task<Representante> DeleteAsync(int idRepresentante)
    {
        var existeRepresentante = await _representanteData.FindByIdAsync(idRepresentante);
        if(existeRepresentante == null)
            throw new Exception("Representante no encontrado");
        
        

        try
        {
            _representanteData.Remove(existeRepresentante);
            return existeRepresentante;
        }
        catch (Exception e)
        {
            throw new Exception(e.Message);
        }
    }

    public async Task<Representante> GetByIdAsync(int idRepresentante)
    {
        var exite = await _representanteData.FindByIdAsync(idRepresentante);
        if (exite == null)
            throw new KeyNotFoundException("Representante no encontrado");

        return exite;
    }
}
