using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;

namespace WebApiCursoMed.Repositories
{
    public class AlunoTurmaMateriaRepository : BaseRepository<AlunoTurmaMateria>, IAlunoTurmaMateriaRepository
    {
        private readonly SqlServerContext _context;

        public AlunoTurmaMateriaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<AlunoTurmaMateria> ObterPorIdTurma(Guid idTurma)
        {
            return _context.AlunoTurmaMateria.Where(x => x.IdTurma == idTurma).ToList();
        }

        public List<AlunoTurmaMateria> ObterPorIdMateria(Guid idMateria)
        {
            return _context.AlunoTurmaMateria.Where(x => x.IdMateria == idMateria).ToList();
        }
    }
}
