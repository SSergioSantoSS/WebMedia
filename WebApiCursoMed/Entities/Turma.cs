using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class Turma 
    {
        public Guid IdTurma { get; set; }
        
        public string Nome { get; set; }

        //public List<Materia> Materias { get; set; }

        public List<TurmaMateria> TurmaMaterias { get; set; }

        public List<AlunoTurmaMateria> AlunoTurmaMaterias { get; set; }

    }
}

