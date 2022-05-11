using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Contexts;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Interfaces;

namespace WebApiCursoMed.Repositories
{
    public class ProvaRepository : BaseRepository<Prova>, IProvaRepository
    {
        private readonly SqlServerContext _context;

        public ProvaRepository(SqlServerContext context) : base(context)
        {
            _context = context;
        }
    }
}
