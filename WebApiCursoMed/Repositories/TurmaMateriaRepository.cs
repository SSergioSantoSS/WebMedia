using System;
using System.Collections.Generic;
using System.Linq;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;
using WebApiCursoMed.Repositories;

namespace WebApiCursoMed.Repositoriesi
{
    public class TurmaMateriaRepository : BaseRepository<TurmaMateria>, ITurmaMateriaRepository
    {
        private readonly SqlServerContext _context;

        public TurmaMateriaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public List<TurmaMateria> ObterPorIdTurma(Guid idTurma)
        {
            return _context.TurmaMateria.Where(x => x.IdTurma == idTurma).ToList();
        }
    }
}
