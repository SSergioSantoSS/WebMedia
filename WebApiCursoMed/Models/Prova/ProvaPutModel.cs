using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models
{
    public class ProvaPutModel
    {
        [Required(ErrorMessage = "Por favor, informe o Id da Nota.")]
        public Guid IdMateria { get; set; }

        [Required(ErrorMessage = " Por favor, informe a primeira nota")]
        public double Nota01 { get; set; }

        [Required(ErrorMessage = " Por favor, informe a segunda nota")]
        public double Nota02 { get; set; }

        [Required(ErrorMessage = " Por favor, informe a terceira nota")]
        public double Nota03 { get; set; }

        [DisplayName("Prova Final")]
        public double Pf { get; set; }

        public double Premio { get; set; }

        [DisplayName("Média")]
        public decimal Media { get; set; }
    }
}
