using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class CampanhaEmailDto
    {
        public CampanhaEmailDto()
        {
            
        }

        public CampanhaEmailDto(CampanhaEmail campanhaEmail)
        {
            Id = campanhaEmail.Id;
            AdminId = campanhaEmail.AdminId;
            Assunto = campanhaEmail.Assunto;
            CorpoMensagem = campanhaEmail.CorpoMensagem;
            Data_Disparo = campanhaEmail.Data_Disparo;
            UsuarioAdmin = campanhaEmail.UsuarioAdmin;
        }

        public int Id { get; set; }
        public int AdminId { get; set; }
        public string Assunto { get; set; }
        public string CorpoMensagem { get; set; }
        public DateTime Data_Disparo { get; set; }
        public Usuarios UsuarioAdmin { get; set; }
    }
}
