

namespace ByTech_API.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string SenhaSalt { get; set; }
        public string Celular { get; set; }
        public int TipoUsuarioId { get; set; }
        public string Cpf { get; set; }
        public string Endereco { get; set; }
        public string  Complemento{ get; set; }
        public string Cidade { get; set; }
        public string Cep { get; set; }
        public TipoUsuario? TipoUsuario { get; set; }
    
     
    }
}
