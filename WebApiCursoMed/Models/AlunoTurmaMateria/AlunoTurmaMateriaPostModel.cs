using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models.AlunoTurmaMateria
{
    public class AlunoTurmaMateriaPostModel
    {               
            public Guid IdTurmaMateria { get; set; }

            public string Nome { get; set; }
    }
}
