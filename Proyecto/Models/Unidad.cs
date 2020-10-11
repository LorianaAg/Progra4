using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services.Description;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Unidad
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdUnidad { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        public int IdTipoPlaca { get; set; }

        [Required]
        [StringLength(50)]
        public string Placa { get; set; }

        public bool Estado { get; set; }

        public string TipoPlacaDesc { get; set; }

        public int IdLinea { get; set; }

        [Display(Name = "Descripción Linea")]
        public string DescripcionLinea { get; set; }
    }
}