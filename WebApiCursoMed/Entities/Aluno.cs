using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class Aluno 
    {

        public Guid IdAluno { get; set; }
        
        public string Nome { get; set; }
        
        public string Matricula { get; set; }

        public string Email { get; set; }

        public string Senha { get; set; }

        public List<AlunoTurmaMateria> AlunoTurmaMaterias { get; set; }

    }
}
