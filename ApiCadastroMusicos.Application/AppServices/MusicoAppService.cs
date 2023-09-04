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
        private readonly IGenericRepository<Endereco> _enderecoRepository;
        private readonly IGenericRepository<Telefone> _telefoneRepository;

        public MusicoAppService(DbContext dbContext,

            IGenericRepository<Musico> musicoRepository,
            IGenericRepository<Instrumento> instrumentoRepository,
            IGenericRepository<Endereco> enderecorepository,
            IGenericRepository<GrupoMusical> grupoRepository,
            IGenericRepository<Telefone> telefoneResitory)


        {
            _dbContext = dbContext;
            _musicoRepository = musicoRepository;
            _instrumentoRepository = instrumentoRepository;
            _grupoRepository = grupoRepository;
        }


        //public async Task<MusicoDto> Get()
        //{
        //    var musicoAchado = await _musicoRepository.GetAll();

        //    List<MusicoDto> musicos = new List<MusicoDto>();

        //    foreach (var musico in musicoAchado)
        //    {
        //        var musicoDTO = new MusicoDto()
        //        {


        //        };



        //    }


        //}

        public async Task<MusicoDto> GetById(Guid id)
        {
            var musico = await _musicoRepository.GetById(id);

            var musicoDT0 = new MusicoDto()

            {
                Nome = musico.Nome,
                SobreNome = musico.SobreNome,
                DataCadastro = musico.DataCadastro
            };

            return musicoDT0;
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

                    musico.HabilidadeMusical.Instrumentos.Add(instrumentoRecord);

                    musico.HabilidadeMusical.Instrumentos = new List<Instrumento>();


                }

                //ADD GRUPO MUSICAL
            }



            if (musicoDto.GruposMusicais.Count() > 0)

            {


                foreach (var grupoMusicalId in musicoDto.GruposMusicais.Distinct())
                {
                    var grupoMusicalRecord = await _grupoRepository.GetById(grupoMusicalId);

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


            _dbContext.Set<Musico>().Add(musico);
            _dbContext.SaveChanges();

            // public void Update(int id, PessoaRequestDTO pessoaDTO)
            // {
            //var pessoaASerAlterada = _dbContext.Set<Musico>().FirstOrDefault(x => x.Id == id);

            //if (pessoaASerAlterada is null) return;

            //pessoaASerAlterada.Nome = pessoaDTO.Nome;
            //pessoaASerAlterada.Idade = pessoaDTO.Idade;

            //_dbContext.Set<Musico>().Update(pessoaASerAlterada);
            //_dbContext.SaveChanges();
            //}
        }
    }
}

