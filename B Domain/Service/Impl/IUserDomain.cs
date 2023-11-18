using Data.Model;

namespace Domain.Service.Impl;

public interface IUserDomain
{
    public Task<string> Login(UserBase user);
    public Task<int> RegisterTourist(Tourist tourist);
    public Task<int> Register(UserBase user);
    public Task<int> RegisterRepresentative(Representative representative);
}