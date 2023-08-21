using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.DTO;

namespace ApiCadastroMusicos.Application.Interfaces
{
    public interface IPessoaAppService: IAppService
    {
        void Create(PessoaRequestDTO pessoaRequestDTO);

        Task<MusicoDto> GetById(int id);
        void Update(int id, PessoaRequestDTO pessoaDTO);
    }
}
