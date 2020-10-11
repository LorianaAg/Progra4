using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Empresa
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public int IdTipoIdentificacion { get; set; }

        [Required]
        [Display(Name = "Identificación")]
        public string Identificacion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [StringLength(50)]
        public string Contacto { get; set; }

        public bool Estado { get; set; }
    }
}