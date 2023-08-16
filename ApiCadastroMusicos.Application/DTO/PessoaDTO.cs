using ApiCadastroMusicos.DTO;
using System.Text.Json.Serialization;

namespace ApiCadastroMusico.DTO
{
    public class PessoaDTO
    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }
        

        public List <TelefoneDTO> Telefones { get; set; }


        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Idade { get; set; }

        [JsonIgnore]
        public EnderecoDTO? Endereco { get; set; }

        public int EnderecoId { get; set; }







    }
}
