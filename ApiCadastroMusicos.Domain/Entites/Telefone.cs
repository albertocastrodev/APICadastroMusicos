using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites;

public class Telefone : Entidade
{

        public string Numero { get; set; }

        public int DDD { get; set; }

        public int PessoaId { get; set; }

        public Musico Pessoa { get; set; }  


    }

