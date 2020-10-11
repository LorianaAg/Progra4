using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Rol
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdRol { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        
        public bool Estado { get; set; }
    }
}