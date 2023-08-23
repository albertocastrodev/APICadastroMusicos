using ApiCadastroMusico.DTO;
using ApiCadastroMusico.Entites;
using ApiCadastroMusicos.Application.DTO.Request;
using ApiCadastroMusicos.Application.Interfaces;
using ApiCadastroMusicos.Domain.Repositories;
using ApiCadastroMusicos.DTO;
using Microsoft.EntityFrameworkCore;

namespace ApiCadastroMusicos.Application.AppServices
{
    public class MusicoAppService : IMusicoAppService
    {
        private readonly DbContext _dbContext;
        private readonly IGenericRepository<Musico> _musicoRepository;
        private readonly IGenericRepository<Instrumento> _instrumentoRepository;
        private readonly IGenericRepository<GrupoMusical> _grupoRepository;

        public MusicoAppService(DbContext dbContext,
            IGenericRepository<Musico> musicoRepository,
            IGenericRepository<Instrumento> instrumentoRepository,
            IGenericRepository<GrupoMusical> grupoRepository)
        {
            _dbContext = dbContext;
            _musicoRepository = musicoRepository;
            _instrumentoRepository = instrumentoRepository;
            _grupoRepository = grupoRepository;
        }

        public async Task<MusicoDto> GetById(Guid id)
        {
            //var musico = await _musicoRepository.GetById(id);

            //return new MusicoDto()

            //{
            //    Nome = musico.Nome,
            //    SobreNome = musico.SobreNome,
            //    DataCadastro = musico.DataCadastro
            //};
            throw new NotImplementedException();
        }


        public async Task Create(MusicoCreateDto musicoDto)
        {
            if (musicoDto.GruposMusicais.Count > 3) 
                throw new ApplicationException("No máximo 3 grupos musicais são permitidos.");

            var musico = new Musico(musicoDto.Nome, musicoDto.SobreNome);

            var instrumentos = await _instrumentoRepository.GetAll();

            foreach (var instrumentoId in musicoDto.Instrumentos.Distinct())
            {
                var instrumentoRecord = instrumentos.FirstOrDefault(x => x.Id == instrumentoId);

                var instrumentoNaoExiste = instrumentoRecord is null;

                if (instrumentoNaoExiste) throw new ApplicationException("Instrumento informado não existe.");

                musico.HabilidadeMusical.AdicionarHabilidadeInstrumental(instrumentoRecord);
            }

            foreach (var grupoMusicalId in musicoDto.GruposMusicais.Distinct())
            {
                var grupoMusicalRecord = await _grupoRepository.GetById(grupoMusicalId);

                var grupoMusicalNaoExiste = grupoMusicalRecord is null;

                if (grupoMusicalNaoExiste) throw new ApplicationException("Grupo musical informado não existe.");

                musico.AdicionarGrupoMusical(grupoMusicalRecord);
            }

            musico.HabilidadeMusical.LeituraDeCifra = musicoDto.LeituraDeCifra;
            musico.HabilidadeMusical.LeituraDePartitura = musicoDto.LeituraDePartitura;
            musico.DataNascimento = musicoDto.DataNascimento;

            //todo: fazer endereço
            //musico.Endereco(new Endereco(musico, musicoDto.))

            _dbContext.Set<Musico>().Add(musico);
            _dbContext.SaveChanges();
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
    }
}

