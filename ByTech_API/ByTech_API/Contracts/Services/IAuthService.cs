using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IAuthService
    {
        string GerarToken(string email, string role);
        string Autenticar(LoginDto loginDto);
    }
}
