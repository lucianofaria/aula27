using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities; // importando

namespace Projeto.Data.Contracts
{
    public interface IDependenteRepository : IBaseRepository<Dependente>
    {
    }
}
