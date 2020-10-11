using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class TipoPlaca
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdTipoPlaca { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción Tipo Placa")]
        public string DescripcionTP { get; set; }

        public bool Estado { get; set; }
    }
}