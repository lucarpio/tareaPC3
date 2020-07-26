using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace La_Pirana_Ejemplo.Models
{
    public class Sucursal
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Nombre requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="Direccion requerida")]
        public string Direccion { get; set; }
    }
}