using ApiCadastroMusico.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroMusicos.Domain.Entites
{
    public class Usuario:Entidade
    {
        public string Email { get; set; }
        public string Senha { get; set; }
        public Musico Musico { get; set; }
    }
}
