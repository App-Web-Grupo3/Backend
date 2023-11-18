using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class RepresentativeData: IRepresentativeData
{
    private readonly AppDbContext _appDbContext;
    
    public RepresentativeData( AppDbContext appDbContext) 
    {
        _appDbContext = appDbContext;
    }
    
    public async Task<IEnumerable<Representative>> ListAsync()
    {
        return await _appDbContext.Representatives.ToListAsync();
    }

    public async Task AddAsync(Representative representative)
    {
        
        _appDbContext.Representatives.AddAsync(representative);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<Representative> FindByIdAsync(int id)
    {
        return await _appDbContext.Representatives.FindAsync(id);
    }

    public void Update(Representative representative)
    {
        _appDbContext.Representatives.Update(representative);
        _appDbContext.SaveChangesAsync();
    }

    public void Remove(Representative representative)
    {
        _appDbContext.Representatives.Remove(representative);
        _appDbContext.SaveChangesAsync();
    }
}