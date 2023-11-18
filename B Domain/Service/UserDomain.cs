using AutoMapper;
using Data.Context;
using Data.Model;
using Data.Persistencia.Impl;
using Domain.Service.Impl;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging; 
namespace Domain.Service;

public class UserDomain : IUserDomain
{
    private IUserData _userData;
    private IEncryptDomain _encryptDomain;
    private ITokenDomain _tokenDomain;
    private IMapper _mapper;
    private readonly AppDbContext _appDbContext;

    public UserDomain(IUserData userData,IEncryptDomain encryptDomain,ITokenDomain tokenDomain, AppDbContext appDbContext, IMapper mapper)
    {
        _userData = userData;
        _encryptDomain = encryptDomain;
        _tokenDomain = tokenDomain;
        _appDbContext = appDbContext;
        _mapper = mapper;
    }

    public async Task<string> Login(UserBase user)
    {
        var tourist = await _userData.GetMailByTourist(user.Mail);
        var representative = await _userData.GetMailByRepresentative(user.Mail);

        if ((tourist != null || representative != null) &&
            _encryptDomain.Ecnrypt(user.Password) == (tourist?.Password ?? representative?.Password))
        {
            var userRole = tourist != null
                ? await _appDbContext.UserRoles.FirstOrDefaultAsync(ur => ur.TouristId == tourist.Id)
                : await _appDbContext.UserRoles.FirstOrDefaultAsync(ur => ur.RepresentativeId == representative.Id);

            if (userRole != null)
            {
                if (userRole.RoleType is "Tourist" or "Representative")
                {
                    return _tokenDomain.GenerateJwt(user.Mail);
                }
            }
        }

        throw new ArgumentException("Invalid username or password");
    }

    public async Task<int> Register(UserBase user)
    {
        var existingTourist = await _userData.GetMailByTourist(user.Mail);
        var existingRepresentative = await _userData.GetMailByRepresentative(user.Mail);

        if (existingTourist != null || existingRepresentative != null)
        {
            throw new ArgumentException("Email already in use");
        }

        switch (user.SelectedRole)
        {
            case "Tourist":
                var tourist = _mapper.Map<UserBase,Tourist>(user);
                return await RegisterTourist(tourist);

            case "Representative":
                var representative = _mapper.Map<UserBase, Representative>(user);
                return await RegisterRepresentative(representative);

            default:
                throw new ArgumentException("Invalid user type");
        }
    }

    

    public async Task<int> RegisterTourist(Tourist tourist)
    {
        var foundUser = await _userData.GetMailByTourist(tourist.Mail);

        if (foundUser != null) throw new ArgumentException("User already exits");
        
        tourist.Password = _encryptDomain.Ecnrypt(tourist.Password);
        return await _userData.RegisterTourist(tourist);
    }

    public async Task<int> RegisterRepresentative(Representative representative)
    {
        var foundUser = await _userData.GetMailByRepresentative(representative.Mail);

        if (foundUser != null) throw new ArgumentException("User already exits");
        
        representative.Password = _encryptDomain.Ecnrypt(representative.Password);
        return await _userData.RegisterRepresentative(representative);
    }
}