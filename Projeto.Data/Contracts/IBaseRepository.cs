using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto.Data.Contracts
{
    public interface IBaseRepository<T>
        where T : class
    {
        void Inserir(T obj);
        void Alterar(T obj);
        void Excluir(T obj);

        List<T> ObterTodo();
        T ObterPorId(int id);
    }
}
