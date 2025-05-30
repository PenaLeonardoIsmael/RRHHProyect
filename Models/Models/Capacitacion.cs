using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Capacitacion
    {
        [Key]
        public int Id { get; set; }
        public int Descripcion { get; set; }
        public int Nivel { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public string Institucion { get; set; }


    }
}
