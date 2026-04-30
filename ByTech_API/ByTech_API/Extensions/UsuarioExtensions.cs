using ByTech_API.Dtos;
using ByTech_API.Models;

namespace ByTech_API.Extensions
{
    public static class UsuarioExtensions
    {
        public static void AtualizaParaUsuarioDto(this Usuario usuario, UsuarioDto usuarioDto)
        {
            if (!string.IsNullOrWhiteSpace(usuarioDto.Nome) && usuarioDto.Nome != "string") usuario.Nome = usuarioDto.Nome;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Email) && usuarioDto.Email != "string") usuario.Email = usuarioDto.Email;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Celular) && usuarioDto.Celular != "string") usuario.Celular = usuarioDto.Celular;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Cpf) && usuarioDto.Cpf != "string") usuario.Cpf = usuarioDto.Cpf;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Endereco)  && usuarioDto.Nome != "string") usuario.Endereco = usuarioDto.Endereco;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Complemento) && usuarioDto.Complemento != "string") usuario.Complemento = usuarioDto.Complemento;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Cidade) && usuarioDto.Cidade != "string") usuario.Cidade = usuarioDto.Cidade;
            if (!string.IsNullOrWhiteSpace(usuarioDto.Cep) && usuarioDto.Cep != "string") usuario.Cep = usuarioDto.Cep;
        }
    }
}
