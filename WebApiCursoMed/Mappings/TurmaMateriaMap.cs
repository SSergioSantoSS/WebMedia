using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Mappings
{
    public class TurmaMateriaMap : IEntityTypeConfiguration<TurmaMateria>
    {
        public void Configure(EntityTypeBuilder<TurmaMateria> builder)
        {
            builder.ToTable("TURMAMATERIA");

            builder.HasKey(x => x.IdTurmaMateria);

            builder.Property(x => x.IdTurmaMateria)
                .HasColumnName("IDTURMAMATERIA")
                .IsRequired();

            builder.Property(x => x.IdTurma)
               .HasColumnName("IDTURMA")
               .IsRequired();

            builder.Property(x => x.IdMateria)
               .HasColumnName("IDMATERIA")
               .IsRequired();


            //Mapeamento de ralacionamento
            builder.HasOne(t => t.Turma)//1 turma pertence a uma materia
                .WithMany(m => m.TurmaMaterias)//1 materia pertence a muitas turmas
                .HasForeignKey(x => x.IdTurma);//Chave estrangeira

            //Mapeamento de relacionamento
            builder.HasOne(m => m.Materia) //Materia possui 1 turma
            .WithMany(t => t.TurmaMaterias) //turma pode ter muitas materias
            .HasForeignKey(x => x.IdMateria); //chave estrangeira

        }
    }
}
