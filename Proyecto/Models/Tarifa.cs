using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Tarifa
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdTarifa { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public decimal Monto { get; set; }

        public bool Estado { get; set; }
    }
}