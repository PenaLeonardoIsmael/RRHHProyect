using Shared.Enum;
using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Puesto
    {
        [Key]
        public int ID_Puesto { get; set; }
        public string Nombre { get; set; }
        [Required]
        public NivelPuesto Riesgo { get; set; }
        [Required]
        [Display(Name = "Salario Minimo")]
        public int Salario_Min { get; set; }
        [Display(Name = "Salario Maximo")]
        public int Salario_Max { get; set; }
      
        public bool Estado { get; set; }



    }
}