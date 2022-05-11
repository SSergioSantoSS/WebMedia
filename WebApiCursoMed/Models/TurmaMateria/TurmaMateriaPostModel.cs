using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models.TurmaMateria
{
    public class TurmaMateriaPostModel
    {       
        public Guid IdMateria { get; set; }

        public string Nome { get; set; }
    }
}
