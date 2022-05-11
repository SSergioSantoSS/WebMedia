using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Mappings
{
    public class TurmaMap : IEntityTypeConfiguration<Turma>
    {
        public void Configure(EntityTypeBuilder<Turma> builder)
        {
            //NOME DA TABELA NO BANCO
            builder.ToTable("TURMA");

            //Chave Primaria
            builder.HasKey(t => t.IdTurma);

            //Demais Campos da Tabela
            builder.Property(t => t.IdTurma)
                .HasColumnName("IDTURMA")
                .IsRequired();

            builder.Property(t => t.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(20)
                .IsRequired();

            //builder.Property(p => p.IdAluno)
            //    .HasColumnName("IDALUNO")
            //    .IsRequired();

            ////Mapeamento de relacionamento
            ////Cardinalidade: 1 para muitos
            //builder.HasOne(p => p.Aluno) //Turma TEM-1 Aluno
            //.WithMany(c => c.Turmas) //Aluno TEM-MUITOS Turmas
            //.HasForeignKey(p => p.IdAluno); //Chave Estrangeira

        }
    }
}
