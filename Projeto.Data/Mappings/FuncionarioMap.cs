using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities; // importando
using System.Data.Entity.ModelConfiguration; // mapeamento ORM

namespace Projeto.Data.Mappings
{
    // Classe de Mapeamento para a entidade -> Funcionario
    class FuncionarioMap : EntityTypeConfiguration<Funcionario>
    {
        public FuncionarioMap()
        {
            // nome da tabela
            ToTable("Funcionario");
            // chave primaria
            HasKey(f => f.IdFuncionario);
            //mapear os demais campos da tabela Funcionario
            Property(f => f.IdFuncionario)
                .HasColumnName("IdFuncionario") // nome do campo
                .IsRequired(); // not null

            Property(f => f.Nome)
                .HasColumnName("Nome") // nome do campo
                .HasMaxLength(150) // tamanho do campo texto
                .IsRequired(); // not null

            Property(f => f.Salario)
                .HasColumnName("Salario") // nome do campo
                .HasPrecision(18,2) // tamanho do campo decimal
                .IsRequired(); // not null

            Property(f => f.DataAdmissao)
                .HasColumnName("DataAdmissao") // nome do campo
                .IsRequired(); // not null
        }
    }
}
