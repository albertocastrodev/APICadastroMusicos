using ApiCadastroMusico.DTO;
using ApiCadastroMusicos.DTO;

namespace ApiCadastroMusicos.Application.Interfaces
{
    public interface IPessoaAppService: IAppService
    {
        void Create(PessoaRequestDTO pessoaRequestDTO);

        void GetById (int id);
        void Update(PessoaDTO pessoaDTO);
    }
}
