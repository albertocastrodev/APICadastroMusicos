using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.DTO;

namespace ApiCadastroMusicos.Application.Interfaces
{
    public interface IMusicoAppService: IAppService
    {

        void Create(MusicoCreateDto musicoDto);
        Task<MusicoDto> GetById(int id);
        void Update(int id, PessoaRequestDTO pessoaDTO);
    }
}
