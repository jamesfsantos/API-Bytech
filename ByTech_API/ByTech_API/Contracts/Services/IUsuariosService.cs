using ByTech_API.Dtos;
using ByTech_API.Models;

namespace ByTech_API.Contracts.Services
{
    public interface IUsuariosService
    {
        Task<IEnumerable<UsuarioDto>> ObterTodos();
    }
}
