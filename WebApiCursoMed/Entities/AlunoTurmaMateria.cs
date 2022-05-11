using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class AlunoTurmaMateria
    {

        public Guid IdAlunoTurmaMateria { get; set; }

        public Aluno Aluno { get; set; }
        public Guid IdAluno { get; set; }

        public Turma Turma { get; set; }
        public Guid IdTurma { get; set; }

        public Materia Materia { get; set; }
        public Guid IdMateria { get; set; }


    }
}
