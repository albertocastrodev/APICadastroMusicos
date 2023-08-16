using ApiCadastroMusico.DTO;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusicos.Application.AppServices
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly DbContext _dbContext;

        public PessoaAppService(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(PessoaRequestDTO pessoaRequestDTO)
        {
            var pessoa = new Pessoa
            {
                Nome = pessoaRequestDTO.Nome,
                SobreNome = pessoaRequestDTO.SobreNome,
                Idade = pessoaRequestDTO.Idade,
                DataCadastro = pessoaRequestDTO.DataNascimento,
                EnderecoId = pessoaRequestDTO.EnderecoId
            };


            _dbContext.Set<Pessoa>().Add(pessoa);
            _dbContext.SaveChanges();
        }


        public void GetById(int id)
        {

            var pessoa = _dbContext.Set<Pessoa>().FirstOrDefault(x => x.Id == id);


            var pessoaDTO = new PessoaDTO()

            {
                Nome = pessoa.Nome,
                SobreNome = pessoa.SobreNome,
                Idade = pessoa.Idade,
                DataCadastro = pessoa.DataCadastro
            };


        }

        public void Update(int id, PessoaRequestDTO pessoaDTO )
        {
            var pessoaASerAlterada = _dbContext.Set<Pessoa>().FirstOrDefault(x => x.Id == id);
            pessoaASerAlterada.Nome = pessoaDTO.Nome;
            pessoaASerAlterada.Idade = pessoaDTO.Idade;


            _dbContext.Set<Pessoa>().Update(pessoaASerAlterada);
            _dbContext.SaveChanges();
        }

        public void Update(PessoaDTO pessoaDTO)
        {
            throw new NotImplementedException();
        }
    }

}

