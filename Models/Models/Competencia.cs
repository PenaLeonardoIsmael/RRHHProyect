using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Competencia
    {
        [Key]
        public int ID_Competencia { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public bool Estado { get; set; }
    }
}