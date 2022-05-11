using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Mappings;

namespace WebApiCursoMed.Contexts
{
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options)
            : base(options)
        {

        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<Materia> Materia { get; set; }
        public DbSet<Turma> Turma { get; set; }
        public DbSet<Prova> Prova { get; set; }
        public DbSet<TurmaMateria> TurmaMateria { get; set; }
        public DbSet<AlunoTurmaMateria> AlunoTurmaMateria { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AlunoMap());
            modelBuilder.ApplyConfiguration(new MateriaMap());
            modelBuilder.ApplyConfiguration(new TurmaMap());
            modelBuilder.ApplyConfiguration(new ProvaMap());
            modelBuilder.ApplyConfiguration(new TurmaMateriaMap());
            modelBuilder.ApplyConfiguration(new AlunoTurmaMateriaMap());
        }

    }
}
