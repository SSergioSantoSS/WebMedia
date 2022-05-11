using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Interfaces
{
    public interface ITurmaRepository : IBaseRepository<Turma>
    {
        Turma ObterPorNome(string nome);

        Turma ObterTodosInclude();
    }
}
