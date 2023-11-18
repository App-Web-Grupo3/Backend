using Data.Model;

namespace Data.Persistencia.Impl;

public interface IUserData
{
    public Task<Tourist?> GetMailByTourist(string mail);
    public Task<Representative?> GetMailByRepresentative(string mail);
    public Task<int> RegisterTourist(Tourist tourist);
    public Task<int> RegisterRepresentative(Representative representative);
}