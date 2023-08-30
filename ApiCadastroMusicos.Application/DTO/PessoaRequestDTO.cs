namespace ApiCadastroMusicos.DTO
{
    public class PessoaRequestDTO
    
    {



       

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Idade { get; set; }
        
        public EnderecoDTO? Endereco { get; set; }

        public string EnderecoId { get; set; }



    }
}
