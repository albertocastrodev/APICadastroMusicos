namespace ApiCadastroMusico.Entites
{
    public class Pessoa

    {

        public int Id { get; set; }

        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public virtual ICollection<Telefone> Telefones { get; set; }


        public DateTime DataCadastro { get; set; }

        public DateTime DataNascimento { get; set; }

        public string Idade { get; set; }

        public string EnderecoId { get; set; }

        public Endereco Endereco { get; set; }


        public int DadosMusicaisId { get; set; }
        public DadosMusicais DadosMusicais {get; set; }


       



    }
}
