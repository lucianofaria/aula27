using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Entities
{
    public class Dependente
    {
        public int IdDependente { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdFuncionario { get; set; }

        public Funcionario Funcionario { get; set; }
    }
}
