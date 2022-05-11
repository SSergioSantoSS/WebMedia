using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;
using WebApiCursoMed.Repositories;

namespace WebApiCursoMed.Interfaces
{
    public interface IAlunoTurmaMateriaRepository : IBaseRepository<AlunoTurmaMateria>
    {
        List<AlunoTurmaMateria> ObterPorIdTurma(Guid idTurma); 
        List<AlunoTurmaMateria> ObterPorIdMateria(Guid idMateria); 

    }
}
