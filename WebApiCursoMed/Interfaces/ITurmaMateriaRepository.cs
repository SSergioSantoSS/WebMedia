using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Interfaces
{
    public interface ITurmaMateriaRepository : IBaseRepository<TurmaMateria>
    {
        List<TurmaMateria> ObterPorIdTurma(Guid idTurma);
    }
}
