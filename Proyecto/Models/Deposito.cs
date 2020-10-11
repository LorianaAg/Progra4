using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Deposito
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdDeposito { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del Usuario")]
        public string NombreUsuario { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public decimal Monto { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        public string Estado { get; set; }
    }
}