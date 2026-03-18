using ByTech_API.Contracts.Services;
using ByTech_API.Data;
using ByTech_API.Dtos;
using ByTech_API.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;

namespace ByTech_API.Services
{
    public class ServicoManutencaoService : IServicoManutencaoService
    {
        private readonly AppDbContext _context;
        public ServicoManutencaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ServicoManutencaoDto> AdicionarServicoManutencao(ServicoManutencaoDto servicoManutencaoDto)
        {

            var servico = new ServicoManutencao
            {
                Id = servicoManutencaoDto.Id,
                ClienteId = servicoManutencaoDto.ClienteId,
                Data_Entrada = servicoManutencaoDto.Data_Entrada,
                Descricao_Problema = servicoManutencaoDto.Descricao_Problema,
                Equipamento = servicoManutencaoDto.Equipamento,
                Observacoes_Tecnicas = servicoManutencaoDto.Observacoes_Tecnicas,
                Protocolo = servicoManutencaoDto.Protocolo,
                Status_Servico = servicoManutencaoDto.Status_Servico,
                TecnicoId = servicoManutencaoDto.TecnicoId
            };
            _context.Add(servico);
            await _context.SaveChangesAsync();
            servicoManutencaoDto.Id = servico.Id;
            return servicoManutencaoDto;

        }

        public async Task<IEnumerable<ServicoManutencaoDto>> ObterServicosManutencao()
        {
            var servicos = await _context.ServicoManutencoes.ToListAsync();

            if (servicos == null || !servicos.Any())
                return null;


            return servicos.Select(servico => new ServicoManutencaoDto(servico));
        }
    }
}
