using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Microsoft.EntityFrameworkCore;

namespace Data.Persistencia;

public class UserData : IUserData
{
    private readonly AppDbContext _appDbContext; 
    
    public UserData(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }

    public async Task<Tourist?> GetMailByTourist(string mail)
    {
        return await _appDbContext.Tourists.FirstOrDefaultAsync(t => t.Mail == mail);
    }

    public async Task<Representative?> GetMailByRepresentative(string mail)
    {
        return await _appDbContext.Representatives.FirstOrDefaultAsync(r => r.Mail == mail);
    }

    public async Task<int> RegisterTourist(Tourist tourist)
    {
        tourist.DateCreated = DateTime.Now;
        _appDbContext.Tourists.Add(tourist);
        
        var userRole = new UserRole
        {
            RoleType = tourist.SelectedRole, 
            TouristId = tourist.Id,
            Tourist = tourist
        };
        _appDbContext.UserRoles.Add(userRole);
        
        var user = new User
        {
            SelectedRole = userRole.RoleType, 
            UserRoleId = userRole.Id,
            UserRole = userRole
        };
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
        return tourist.Id;
    }
    
    public async Task<int> RegisterRepresentative(Representative representative)
    {
        representative.DateCreated = DateTime.Now;
        _appDbContext.Representatives.Add(representative);
        
        var userRole = new UserRole
        {
            RoleType = representative.SelectedRole,
            RepresentativeId = representative.Id,
            Representative = representative
        };
        _appDbContext.UserRoles.Add(userRole);
        
        var user = new User
        {
            SelectedRole = userRole.RoleType, 
            UserRoleId = userRole.Id,
            UserRole = userRole
        };
        _appDbContext.Users.Add(user);
        await _appDbContext.SaveChangesAsync();
        return representative.Id;
    }
}