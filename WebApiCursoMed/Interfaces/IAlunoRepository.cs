using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Entities;

namespace WebApiCursoMed.Interfaces
{
    public interface IAlunoRepository : IBaseRepository<Aluno>
    {
        Aluno ObterPorMatricula(string matricula);
        Aluno ObterPorEmailESenha(string email, string senha);
    }
}
