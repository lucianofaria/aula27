using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity; // EntityFramework
using Projeto.Data.Entities; // classes de entidades
using Projeto.Data.Contracts; // interfaces
using Projeto.Data.Context; // classe de acesso ao BD

namespace Projeto.Data.Repositories
{
    public class DependenteRepository : IDependenteRepository
    {
        public void Inserir(Dependente obj)
        {
            using (DataContext context = new DataContext())
            {
                context.Entry(obj).State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Alterar(Dependente obj)
        {
            using (DataContext context = new DataContext())
            {
                context.Entry(obj).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Excluir(Dependente obj)
        {
            using (DataContext context = new DataContext())
            {
                context.Entry(obj).State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public List<Dependente> ObterTodo()
        {
            using (DataContext context = new DataContext())
            {
                return context.Dependente.ToList();
            }
        }

        public Dependente ObterPorId(int id)
        {
            using (DataContext context = new DataContext())
            {
                return context.Dependente.Find(id);
            }
        }
    }
}
