using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class MensagensContatoDto
    {
        public MensagensContatoDto()
        {
            
        }

        public MensagensContatoDto(MensagensContato mensagensContato)
        {
            UsuarioId = mensagensContato.UsuarioId;
            Nome = mensagensContato.Nome;
            Email = mensagensContato.Email;
            Celular = mensagensContato.Celular;
            Mensagem = mensagensContato.Mensagem;
            Data_Envio = mensagensContato.Data_Envio;
            Usuario = mensagensContato.Usuario;
        }

        public int UsuarioId { get; set; }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Celular { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data_Envio { get; set; }

        public Usuarios Usuario { get; set; }
    }
}
