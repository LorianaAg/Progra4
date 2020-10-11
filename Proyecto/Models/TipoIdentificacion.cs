using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class TipoIdentificacion
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdTipoIdentificacion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public bool Estado { get; set; }
    }
}