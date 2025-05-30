using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class Empleado
    {
        [Key]

        public int Id { get; set; }
        public string Cedula { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public int PuestoId { get; set; }
        public Puesto Puesto { get;  set; }
        public string Departamento { get; set; }
        public double SalarioMensual { get; set; }
        public bool Estado { get; set; }
    } 
}
