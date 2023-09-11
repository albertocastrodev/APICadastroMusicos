using ApiCadastroMusico;
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
        private readonly IGenericRepository<GrupoMusical> _grupoMusicalRepository;
        private readonly IGenericRepository<Endereco> _enderecoRepository;
        private readonly IGenericRepository<Telefone> _telefoneRepository;

        public MusicoAppService(DbContext dbContext,

            IGenericRepository<Musico> musicoRepository,
            IGenericRepository<Instrumento> instrumentoRepository,
            IGenericRepository<Endereco> enderecoRepository,
            IGenericRepository<GrupoMusical> grupoRepository,
            IGenericRepository<Telefone> telefoneRepository)

        {
            _dbContext = dbContext;
            _musicoRepository = musicoRepository;
            _instrumentoRepository = instrumentoRepository;
            _grupoMusicalRepository = grupoRepository;
            _enderecoRepository = enderecoRepository;
        }


        public async Task<List<MusicoGetDto>> Get()
        {
            var musicosAchados = await _musicoRepository.GetAllAsQueryable().ToListAsync();


            List<MusicoGetDto> musicos = new();

            foreach (var musico in musicosAchados)
            {
                var musicoDTO = new MusicoGetDto()
                {
                    Id = musico.Id,
                    DataCadastro = musico.DataCadastro,
                    DataNascimento = musico.DataNascimento,
                    Nome = musico.Nome,
                    SobreNome = musico.SobreNome
                };

                musicos.Add(musicoDTO);
            }

            return musicos;
        }

        public async Task<MusicoGetDto> GetById(Guid id)
        {
            var musico = await _musicoRepository.GetById(id);

            if (musico is null) return null;

            var musicoDTO = new MusicoGetDto()
            {
                Id = musico.Id,
                DataCadastro = musico.DataCadastro,
                DataNascimento = musico.DataNascimento,
                Nome = musico.Nome,
                SobreNome = musico.SobreNome
            };

            return musicoDTO;
        }

        public async Task<EnderecoDTO> GetEndereco(Guid musicoId)
        {
            var endereco = await _enderecoRepository
                .GetAllAsQueryable()
                .Include(x => x.Musico)
                .FirstOrDefaultAsync(x => x.Musico.Id == musicoId);


            var enderecoDto = new EnderecoDTO
            {
                Bairro = endereco.Bairro,
                Cep = endereco.Cep,
                Cidade = endereco.Cidade,
                Logradouro = endereco.Logradouro,
                Numero = endereco.Numero,
                UF = endereco.UF
            };

            return enderecoDto;
        }


        public async Task<List<TelefoneDTO>> GetTelefones(Guid musicoId)
        {
            var telefones = new List<TelefoneDTO>();

            var telefonesAchados = await _telefoneRepository.GetAllAsQueryable().Where(x => x.MusicoId == musicoId).ToListAsync();


            foreach (var telefone in telefonesAchados)
            {


                var telefoneDto = new TelefoneDTO()
                {
                    DDD = telefone.DDD,
                    Numero = telefone.Numero

                };

                telefones.Add(telefoneDto);
            }


            return telefones;
        }


        public async Task Create(MusicoCreateDto musicoDto)
        {
            if (musicoDto.GruposMusicais.Count > 3)
                throw new ApplicationException("No máximo 3 grupos musicais são permitidos.");

            // Iniciando endereço porque o Endereço é um parâmetro do Músico.

            var endereco = new Endereco(musicoDto.Endereco.Logradouro, musicoDto.Endereco.Numero, musicoDto.Endereco.Bairro, musicoDto.Endereco.Cidade, musicoDto.Endereco.Cep, musicoDto.Endereco.UF); // Parâmetros do Endereço


            var musico = new Musico(musicoDto.Nome, musicoDto.SobreNome, endereco); // criando um novo músico e passando os paramêtros pelo construtor 


            // ADD INSTRUMENTO


            if (musicoDto.Instrumentos.Count() > 0)

            {
                var instrumentosDoBanco = await _instrumentoRepository.GetAll(); // Trazendo todos os intrumentos do Banco pra memória 

                foreach (var instrumentoId in musicoDto.Instrumentos.Distinct()) // Iterando sobre a lista de instrumentos  // Distinc ilimina todas as duplicidades
                {
                    var instrumentoRecord = instrumentosDoBanco.FirstOrDefault(x => x.Id == instrumentoId); // verificando se o instrumento Id é igual ao id do instrumento recebido no DTO

                    var instrumentoNaoExiste = instrumentoRecord is null;

                    if (instrumentoNaoExiste) throw new ApplicationException("Instrumento informado não existe.");

                    musico.HabilidadeMusical.AdicionarHabilidadeInstrumental(instrumentoRecord);

                }
            }


            if (musicoDto.GruposMusicais.Any())
            {
                foreach (var grupoMusicalId in musicoDto.GruposMusicais.Distinct())
                {
                    var grupoMusicalRecord = await _grupoMusicalRepository.GetById(grupoMusicalId);

                    var grupoMusicalNaoExiste = grupoMusicalRecord is null;

                    if (grupoMusicalNaoExiste) throw new ApplicationException("Grupo musical informado não existe.");

                    musico.AdicionarGrupoMusical(grupoMusicalRecord);
                }
            }

            //ADD HABILIDADES MUSICAIS

            musico.HabilidadeMusical.LeituraDeCifra = musicoDto.LeituraDeCifra;
            musico.HabilidadeMusical.LeituraDePartitura = musicoDto.LeituraDePartitura;
            musico.DataNascimento = musicoDto.DataNascimento;

            //ADD TELEFONE

            //Recebe DTO 
            //Cria um novo Objeto Telefone 
            //Passa as informações de DTO para o Objeto 
            // Chama o método adicionar telefone

            foreach (var telefonedto in musicoDto.Telefones)
            {
                var telefone = new Telefone();
                telefone.DDD = telefonedto.DDD;
                telefone.Numero = telefonedto.Numero;
                musico.AdicionarTelefone(telefone);
            }

            await _dbContext.Set<Musico>().AddAsync(musico);
            await _dbContext.SaveChangesAsync();
        }
    }
}

