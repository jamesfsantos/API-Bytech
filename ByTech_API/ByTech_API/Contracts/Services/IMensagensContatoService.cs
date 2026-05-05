using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IMensagensContatoService
    {
        Task<IEnumerable<MensagensContatoDto>> ObterTodos();
    }
}
