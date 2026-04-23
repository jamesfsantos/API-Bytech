using ByTech_API.Dtos;
using ByTech_API.Models;

namespace ByTech_API.Contracts.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<UsuarioDto>> ObterTodos();
        Task<UsuarioDto> ObterPorId(int id);
        Task<UsuarioDto> AtualizarUsuario(int id, UsuarioDto usuarioDto);
        Task<UsuarioDto> AdicionarUsuario(UsuarioDto usuarioDto);
        Task<bool> ExcluirUsuario(int id);

        Task<bool> ValidarLogin(string email, string senha);
    }
}
