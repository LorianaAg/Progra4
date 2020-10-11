using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Usuario
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo Nombre")]
        public string Nombre2 { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Primer Apellido")]
        public string Apellido1 { get; set; }

        [StringLength(50)]
        [Display(Name = "Segundo Apellido")]
        public string Apellido2 { get; set; }

        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public decimal Saldo { get; set; }

        [Required]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(50)]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [StringLength(50)]
        public string Clave { get; set; }

        public bool Estado { get; set; }

        public int IdRol { get; set; }

        public string DescrRol { get; set; }
    }
}