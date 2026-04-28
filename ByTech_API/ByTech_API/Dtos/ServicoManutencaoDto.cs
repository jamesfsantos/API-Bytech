using ByTech_API.Enums;
using ByTech_API.Models;

namespace ByTech_API.Dtos
{
    public class ServicoManutencaoDto
    {
        public ServicoManutencaoDto()
        {

        }
        public ServicoManutencaoDto(ServicoManutencao servicoManutencao)
        {
            Id = servicoManutencao.Id;
            Protocolo = servicoManutencao.Protocolo;
            ClienteId = servicoManutencao.ClienteId;
            TecnicoId = servicoManutencao.TecnicoId;
            Equipamento = servicoManutencao.Equipamento;
            Descricao_Problema = servicoManutencao.Descricao_Problema;
            Observacoes_Tecnicas = servicoManutencao.Observacoes_Tecnicas;
            Status_Servico = servicoManutencao.Status_Servico;
            Data_Entrada = servicoManutencao.Data_Entrada;
            

        }
        public int Id { get; set; }
        public string Protocolo { get; set; }
        public int ClienteId { get; set; }
        public int TecnicoId { get; set; }
        public string Equipamento { get; set; }
        public string Descricao_Problema { get; set; }
        public string Observacoes_Tecnicas { get; set; }
        public StatusServico Status_Servico { get; set; }
        public DateTime Data_Entrada { get; set; }

        public Usuario? Cliente { get; set; }
        public Usuario? Tecnico { get; set; }
    }
}
