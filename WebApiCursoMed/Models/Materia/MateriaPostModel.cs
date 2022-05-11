using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models
{
    public class MateriaPostModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome da Matéria.")]
        public string Nome { get; set; }
    }
}
