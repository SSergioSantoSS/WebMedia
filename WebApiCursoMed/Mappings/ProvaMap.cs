using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Mappings
{
    public class ProvaMap : IEntityTypeConfiguration<Prova>
    {
        public void Configure(EntityTypeBuilder<Prova> builder)
        {
            //NOME DA TABELA NO BANCO
            builder.ToTable("PROVA");

            //Chave Primaria
            builder.HasKey(n => n.IdProva);

            //Demais Campos da Tabela
            builder.Property(n => n.IdProva)
                .HasColumnName("IDPROVA")
                .IsRequired();

            builder.Property(n => n.Nota)
                .HasColumnName("NOTA")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            //builder.Property(n => n.Nota02)
            //    .HasColumnName("NOTA02")
            //    .HasColumnType("decimal(10,2")
            //    .IsRequired();

            //builder.Property(n => n.Nota03)
            //    .HasColumnName("NOTA03")
            //    .HasColumnType("decimal(10,2")
            //    .IsRequired();

            builder.Property(n => n.Peso)
                .HasColumnName("PESO")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(n => n.Pf)
                .HasColumnName("PROVAFINAL")
                .HasColumnType("decimal(10,2)")
                .IsRequired();

            builder.Property(n => n.Media)
               .HasColumnName("MEDIA")
               .HasColumnType("decimal(10,2)");

            builder.Property(n => n.IdAlunoTurmaMateria)
                .HasColumnName("IDALUNOTURMAMATERIA")
                .HasColumnType("integer")
                .IsRequired();
        }
    }
}
