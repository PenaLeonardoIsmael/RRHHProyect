using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Candidato
    {
        [Key]
        public int IDCandidato { get; set; }
        [Required]
        public string Cedula { get; set; }
        public int PuestoId { get; set; }
        public Puesto PuestoAspira { get; set; }
        public string Departamento { get; set; }
        public double Salario { get; set; }
        public int CompetenciaId { get; set; }
        public Competencia Competencia { get; set; }

        public string Capacitacion { get; set; }

        public ICollection<Experiencia>Experiencias{get;}=new List<Experiencia>();

    }
}
