using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Models
{
    public class ProvaGetModel
    {
        public Guid IdNota { get; set; }

        public double Nota01 { get; set; }
        public double Nota02 { get; set; }
        public double Nota03 { get; set; }

        [DisplayName("Prova Final")]

        public double Pf { get; set; }

        public double Premio { get; set; }

        [DisplayName("Média")]

        public decimal Media { get; set; }
    }
}
