using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration; // importando
using System.Data.Entity; // importando
using Projeto.Data.Entities; // importando
using Projeto.Data.Mappings; // importando

namespace Projeto.Data.Context
{
    // Regra 1) Herdar a classe DbContext do EntityFramework
    public class DataContext : DbContext
    {
        // Regra 2) Criar um construtor que deverá ler o camino da string de conexão
        // mapeado no arquivo web.config.xml e ebvia-la para a superclasse (DbContex)
        public DataContext()
            : base(ConfigurationManager.ConnectionStrings["projeto"].ConnectionString)
        {
        }

        // Regra 3) Sobrescrever (OVERRIDE) o método OnModelCreating de forma que possamos
        // adicionar dentro do método as classes de mapeamento criadas (Map)
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // adicionar cada classe de mapeamento...
            modelBuilder.Configurations.Add(new FuncionarioMap());
            modelBuilder.Configurations.Add(new DependenteMap());
        }

        // Regra 4) Declarar uma propriedade DbSet para cada entidade
        public DbSet<Funcionario> Funcionario { get; set; } // Lambda
        public DbSet<Dependente> Dependente { get; set; } // Lambda
    }
}
