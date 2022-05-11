using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class TurmaMateria
    {
        public Guid IdTurmaMateria { get; set; }

        public Guid IdTurma { get; set; }

        public Guid IdMateria { get; set; }

        public Turma Turma { get; set; }

        public Materia Materia { get; set; }

    }
}
