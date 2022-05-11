using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Mappings
{
    public class MateriaMap : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            //NOME DA TABELA NO BANCO
            builder.ToTable("MATERIA");

            //Chave Primaria
            builder.HasKey(m => m.IdMateria);

            //Demais Campos da Tabela
            builder.Property(m => m.IdMateria)
                .HasColumnName("IDMATERIA")
                .IsRequired();

            builder.Property(m => m.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(20)
                .IsRequired();

        }
    }
}
