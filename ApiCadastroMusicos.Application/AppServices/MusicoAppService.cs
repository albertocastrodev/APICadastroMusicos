using ApiCadastroMusico.DTO;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.Domain.Repositories;
using ApiCadastroMusicos.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusicos.Application.AppServices
{
    public class MusicoAppService : IPessoaAppService
    {
        private readonly DbContext _dbContext;
        private readonly IGenericRepository<Musico> _pessoaRepository;

        public MusicoAppService(DbContext dbContext, IGenericRepository<Musico> musicoRepository)
        {
            _dbContext = dbContext;
            _pessoaRepository = musicoRepository;
        }

        //public void Create(PessoaRequestDTO pessoaRequestDTO)
        //{
        //    var pessoa = new Musico
        //    {
        //        Nome = pessoaRequestDTO.Nome,
        //        SobreNome = pessoaRequestDTO.SobreNome,
        //        DataCadastro = pessoaRequestDTO.DataNascimento,
        //        EnderecoId = pessoaRequestDTO.EnderecoId
        //    };


        //    _dbContext.Set<Musico>().Add(pessoa);
        //    _dbContext.SaveChanges();
        //}


        public async Task<MusicoDto> GetById(int id)
        {
            var pessoa = await _pessoaRepository.GetById(id);

            return new MusicoDto()

            {
                Nome = pessoa.Nome,
                SobreNome = pessoa.SobreNome,
                DataCadastro = pessoa.DataCadastro
            };
        }

        public void Update(int id, PessoaRequestDTO pessoaDTO)
        {
            //var pessoaASerAlterada = _dbContext.Set<Musico>().FirstOrDefault(x => x.Id == id);

            //if (pessoaASerAlterada is null) return;

            //pessoaASerAlterada.Nome = pessoaDTO.Nome;
            //pessoaASerAlterada.Idade = pessoaDTO.Idade;

            //_dbContext.Set<Musico>().Update(pessoaASerAlterada);
            //_dbContext.SaveChanges();
        }

        public void Create(MusicoCreateDto musicoDto)
        {
            var musico = new Musico(musicoDto.Nome, musicoDto.SobreNome);

            musico.HabilidadeMusical.AdicionarHabilidadeInstrumental(new Instrumento() { Id = Guid.NewGuid() });

            _dbContext.Set<Musico>().Add(musico);
            _dbContext.SaveChanges();
        }

    }

}

