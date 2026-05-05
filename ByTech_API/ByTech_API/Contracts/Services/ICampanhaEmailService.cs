using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface ICampanhaEmailService
    {
        Task<IEnumerable<CampanhaEmailDto>> ObterTodos();
    }
}
