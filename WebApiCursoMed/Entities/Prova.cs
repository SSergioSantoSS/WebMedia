using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCursoMed.Entities
{
    public class Prova 
    {
        public Guid IdProva { get; set; } 
        public double Nota { get; set; }
        

        public double Peso { get; set; }
        public double Pf { get; set; }  
        public decimal Media { get; set; }  
        public List<AlunoTurmaMateria> AlunoTurmaMaterias { get; set; }  
        public Guid IdAlunoTurmaMateria { get; set; }
        public string SituacaoFinal { get; set; }

    }
}
