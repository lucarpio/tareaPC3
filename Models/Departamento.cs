using System.ComponentModel.DataAnnotations;

namespace La_Pirana_Ejemplo.Models
{
    public class Departamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Ingrese un nombre")]
        public string Nombre { get; set; }
    }
}