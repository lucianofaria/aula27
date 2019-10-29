using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Projeto.Data.Entities; // importando
using System.Data.Entity.ModelConfiguration; // mapeamento ORM

namespace Projeto.Data.Mappings
{
    public class DependenteMap : EntityTypeConfiguration<Dependente>
    {
        public DependenteMap()
        {
            // nome da tabela
            ToTable("Dependente");
            // chave primaria
            HasKey(d => d.IdDependente);
            //mapear os demais campos da tabela Funcionario
            Property(d => d.IdDependente)
                .HasColumnName("IdDependente") // nome do campo
                .IsRequired(); // not null

            Property(d => d.Nome)
                .HasColumnName("Nome") // nome do campo
                .HasMaxLength(150) // tamanho do campo texto
                .IsRequired(); // not null

            Property(d => d.DataNascimento)
                .HasColumnName("DataNascimento") // nome do campo
                .IsRequired(); // not null

            Property(d => d.IdFuncionario)
                .HasColumnName("IdFuncionario") // nome do campo
                .IsRequired(); // not null

            // Criando relacionamento de Dependente com Funcionario
            HasRequired(d => d.Funcionario) // Dependente tem 1 funcionario
                .WithMany(f => f.Dependentes) // Funcionario tem muitos dependentes
                .HasForeignKey(d => d.IdFuncionario); // Chave estrangeira
        }
    }
}
