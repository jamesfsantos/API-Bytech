using ByTech_API.Dtos;

namespace ByTech_API.Contracts.Services
{
    public interface IServicoManutencaoService
    {
        Task<IEnumerable<ServicoManutencaoDto>> ObterServicosManutencao();
        Task<ServicoManutencaoDto> AdicionarServicoManutencao(ServicoManutencaoDto servicoManutencaoDto);
    }
}
