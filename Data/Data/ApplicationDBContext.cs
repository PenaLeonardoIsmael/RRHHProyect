using Microsoft.EntityFrameworkCore;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Data
{
    public class ApplicationDBContext:DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }

        public DbSet<Candidato> Candidatos{ get; set; }
        public DbSet<Capacitacion> Capacitaciones { get; set; }
        public DbSet<Competencia> Competencias { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Experiencia> Experiencias { get; set; }
        public DbSet<Idioma> Idiomas { get; set; }
        public DbSet<Puesto> Puestos { get; set; }
    }
}
