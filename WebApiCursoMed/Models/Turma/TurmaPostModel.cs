using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WebApiCursoMed.Models.TurmaMateria;

namespace WebApiCursoMed.Models
{
    public class TurmaPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da turma.")]
        public string Nome { get; set; }

        public List<TurmaMateriaPostModel> TurmaMaterias { get; set; }
    }
}
