using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class CompetenciaCandidato
    {
        [Key]
        public int Id { get; set; }
        
        public int ID_Candidatos { get; set; }
        public Candidato Candidato { get; set; }
        public int ID_Competencias { get; set; }
        public Competencia Competencia { get; set; }


    }
}
