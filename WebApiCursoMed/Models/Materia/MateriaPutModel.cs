using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models
{
    public class MateriaPutModel
    {

        [Required(ErrorMessage = "Por favor, informe o Id da Matéria.")]
        public Guid IdMateria { get; set; }


        [Required(ErrorMessage = "Por favor, informe o nome da Matéria.")]
        public string Nome { get; set; }
    }
}
