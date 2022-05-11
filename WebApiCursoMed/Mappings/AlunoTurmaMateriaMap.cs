using Microsoft.EntityFrameworkCore;
using WebApiCursoMed.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Mappings
{
    public class AlunoTurmaMateriaMap : IEntityTypeConfiguration<AlunoTurmaMateria>
    {
        public void Configure(EntityTypeBuilder<AlunoTurmaMateria> builder)
        {
            builder.ToTable("ALUNOTURMAMATERIA");

            builder.HasKey(x => x.IdAlunoTurmaMateria);

            builder.Property(x => x.IdAlunoTurmaMateria)
                .HasColumnName("IDALUNOTURMAMATERIA")
                .IsRequired();

            builder.Property(x => x.IdTurma)
               .HasColumnName("IDTURMA")
               .IsRequired();

            builder.Property(x => x.IdMateria)
               .HasColumnName("IDMATERIA")
               .IsRequired();


            //Mapeamento de ralacionamento
            builder.HasOne(t => t.Materia)
                .WithMany(m => m.AlunoTurmaMaterias)
                .HasForeignKey(x => x.IdMateria);

            //Mapeamento de relacionamento
            builder.HasOne(m => m.Turma) 
            .WithMany(t => t.AlunoTurmaMaterias) 
            .HasForeignKey(x => x.IdTurma); 

            //Mapeamento de relacionamento
            builder.HasOne(m => m.Aluno) 
            .WithMany(t => t.AlunoTurmaMaterias) 
            .HasForeignKey(x => x.IdAluno); 
        }
    }
}
