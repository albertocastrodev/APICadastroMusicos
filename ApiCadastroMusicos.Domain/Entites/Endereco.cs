﻿using ApiCadastroMusicos.Domain.Entites;

namespace ApiCadastroMusico.Entites
{

    public class Endereco : Entidade
    {
        public string Logradouro { get; set; }

        public string Numero { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string Cep { get; set; }

        public string UF { get; set; }

        public int PessoaId { get; set; }
    }
}