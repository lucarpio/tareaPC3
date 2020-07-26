using La_Pirana_Ejemplo.Models;
using Microsoft.EntityFrameworkCore;

namespace La_Pirana_Ejemplo.Data
{
    public class PiranaContext :DbContext
    {
        public PiranaContext (DbContextOptions<PiranaContext> options) : base (options) { }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Empleado> Empleados { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
    }
}