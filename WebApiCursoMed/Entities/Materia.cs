using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class Materia 
    {
        public Guid IdMateria { get; set; }
        
        public string Nome { get; set; }


        public List<TurmaMateria> TurmaMaterias { get; set; }

        public List<AlunoTurmaMateria> AlunoTurmaMaterias { get; set; }

    }
}
