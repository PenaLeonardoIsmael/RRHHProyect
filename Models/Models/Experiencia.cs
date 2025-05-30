using System.ComponentModel.DataAnnotations;

namespace Models.Models
{
    public class Experiencia
    {
        [Key]
        public int Id { get; set; }
        public string Empresa { get; set; }
        public string Puesto { get; set; }
        public DateTime FechaDesde { get; set; }
        public DateTime FechaHasta { get; set; }
        public double Salario { get; set; }
        public int Candidato_ID { get; set; }
        public Candidato Candidato { get; set; }
    }
}