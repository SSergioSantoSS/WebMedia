using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;

namespace WebApiCursoMed.Repositories
{
    public class MateriaRepository : BaseRepository<Materia>, IMateriaRepository
    {
        private readonly SqlServerContext _context;

        public MateriaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }

        public Materia ObterPorNome(string nome)
        {
            return _context.Materia.FirstOrDefault(a => a.Nome.Equals(nome));
        }
    }
}
