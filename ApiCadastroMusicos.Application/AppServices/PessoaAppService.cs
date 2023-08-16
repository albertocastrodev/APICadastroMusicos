using ApiCadastroMusico.DTO;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.Domain.Repositories;
using ApiCadastroMusicos.DTO;
using ApiCadastroMusicos.Infra.Database.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusicos.Application.AppServices
{
    public class PessoaAppService : IPessoaAppService
    {
        private readonly DbContext _dbContext;
        private readonly IGenericRepository<Pessoa> _pessoaRepository;

        public PessoaAppService(DbContext dbContext, IGenericRepository<Pessoa> pessoaRepository)
        {
            _dbContext = dbContext;
            _pessoaRepository = pessoaRepository;
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


        public async Task<PessoaDTO> GetById(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);

            return new PessoaDTO()

            {
                Nome = pessoa.Nome,
                SobreNome = pessoa.SobreNome,
                Idade = pessoa.Idade,
                DataCadastro = pessoa.DataCadastro
            };
        }

        public void Update(int id, PessoaRequestDTO pessoaDTO)
        {
            var pessoaASerAlterada = _dbContext.Set<Pessoa>().FirstOrDefault(x => x.Id == id);

            if (pessoaASerAlterada is null) return;

            pessoaASerAlterada.Nome = pessoaDTO.Nome;
            pessoaASerAlterada.Idade = pessoaDTO.Idade;

            _dbContext.Set<Pessoa>().Update(pessoaASerAlterada);
            _dbContext.SaveChanges();
        }
    }

}

