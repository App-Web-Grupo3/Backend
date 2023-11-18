namespace Domain.Service.Impl;

public interface ITokenDomain
{
    string GenerateJwt(string username);

    string ValidateJwt(string token);
}