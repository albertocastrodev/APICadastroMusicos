using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.DTO;

namespace ApiCadastroMusicos.Application.Interfaces
{
    public interface IMusicoAppService: IAppService
    {

        Task Create(MusicoCreateDto musicoDto);
        Task<List<MusicoGetDto>> Get();
        Task<MusicoGetDto> GetById(Guid id);
        Task<EnderecoDTO> GetEndereco(Guid musicoId);
    }
}
