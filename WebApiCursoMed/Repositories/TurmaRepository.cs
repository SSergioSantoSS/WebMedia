using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;

namespace WebApiCursoMed.Repositories
{
    public class TurmaRepository :BaseRepository<Turma>, ITurmaRepository
    {
        private readonly SqlServerContext _context;

        public TurmaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Turma ObterPorNome(string nome)
        {
            return _context.Turma.FirstOrDefault(t => t.Nome.Equals(nome));
        }

        public Turma ObterTodosInclude()
        {
            return _context.Turma.Include(x => x.TurmaMaterias).ThenInclude(t => t.Turma)
                .Include(x => x.TurmaMaterias).ThenInclude(m => m.Materia)
                .Include(x => x.AlunoTurmaMaterias).ThenInclude(a => a.Aluno).FirstOrDefault();
        }
    }
}
