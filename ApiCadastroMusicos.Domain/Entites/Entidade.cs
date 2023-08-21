using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiCadastroMusicos.Domain.Entites
{
    public abstract class Entidade
    {
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
