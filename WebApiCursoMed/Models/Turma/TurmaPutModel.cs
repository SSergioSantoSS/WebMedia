using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models
{
    public class TurmaPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id da turma.")]
        public Guid IdTurma { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome da turma.")]
        public string Nome { get; set; }
    }
}
