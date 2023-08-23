using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites
{

    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }

        public Endereco(Musico musico, string logradouro, string numero, string bairro, string cidade, string cep, string uF)
        {
            ArgumentNullException.ThrowIfNull(musico);

            ArgumentNullException.ThrowIfNull(logradouro);
            ArgumentNullException.ThrowIfNull(numero);
            ArgumentNullException.ThrowIfNull(bairro);
            ArgumentNullException.ThrowIfNull(cidade);
            ArgumentNullException.ThrowIfNull(cep);
            ArgumentNullException.ThrowIfNull(uF);

            Musico = musico;

            Logradouro = logradouro;
            Numero = numero;
            Bairro = bairro;
            Cidade = cidade;
            Cep = cep;
            UF = uF;
        }

        public string Numero { get; private set; }

        public string Bairro { get; private set; }

        public string Cidade { get; private set; }

        public string Cep { get; private set; }

        public string UF { get; private set; }

        public Musico Musico { get; private set; }
        public Guid MusicoId { get; private set; }
    }
}