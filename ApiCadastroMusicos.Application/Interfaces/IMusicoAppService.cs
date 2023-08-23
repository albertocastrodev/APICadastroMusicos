using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.DTO;

namespace ApiCadastroMusicos.Application.Interfaces
{
    public interface IMusicoAppService: IAppService
    {

        Task Create(MusicoCreateDto musicoDto);
        //Task<M> GetById(Guid id);
        //void Update(int id, PessoaRequestDTO pessoaDTO);
    }
}
