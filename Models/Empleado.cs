using System;
using System.ComponentModel.DataAnnotations;

namespace La_Pirana_Ejemplo.Models
{
    public class Empleado
    {
        public int Id { get; set; }
        [Required(ErrorMessage="Ingrese un nombre")]
        [MinLength(2,ErrorMessage="Nombre muy corto, <2 caracteres"), MaxLength(25, ErrorMessage="Nombre muy largo, >25 caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage="Ingrese un apellido")]
        [MinLength(2,ErrorMessage="Apellido muy corto, <2 caracteres"), MaxLength(25, ErrorMessage="Apellido muy largo, >25 caracteres")]
        public string Apellido { get; set; }
        [Required(ErrorMessage="Ingrese fecha")]
        [DataType(DataType.Date)]
        [Display(Name="Fecha de nacimiento")]
        public DateTime FecNac { get; set; }
        [Required(ErrorMessage="Campo requerido")]
        public string TipoDoc { get; set; }
        [RegularExpression(@"([0-9]{8})", ErrorMessage = "Numero de doc invalido (8 digitos 0-9)")]
        [Required(ErrorMessage="Ingrese un numero de documento")]
        public string NroDoc { get; set; }
        public Departamento Departamento { get; set; }
        //shadow property
        [Required(ErrorMessage="Campo requerido")]
        public int DepartamentoId { get; set; }
        public Sucursal Sucursal { get; set; }
        //shadow property
        [Required(ErrorMessage="Campo requerido")]
        public int SucursalId { get; set; }
        // [RegularExpression(@"([0-9])", ErrorMessage="Solo ingrese numeros")]
        [Range(1, Double.MaxValue, ErrorMessage = "El salario no puede ser 0!")]
        public double Salario { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage="Fecha requerida")]
        public DateTime FechaIngreso { get; set; }
    }
}