using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace Proyecto.Models
{
    public class Linea
    {
        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdLinea { get; set; }

        [RegularExpression("^[0-9]*$", ErrorMessage = "Sólo se permiten números")]
        public int IdEmpresa { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Código CTP")]
        public string CodigoCTP { get; set; }

        public char Provincia { get; set; }

        [Display(Name = "Cantón")]
        public string Canton { get; set; }

        public string Distrito { get; set; }

        public bool Estado { get; set; }

        public string ProvinciaDesc { get; set; }

        public string CantonDesc { get; set; }

        public string DistritoDesc { get; set; }

        public int IdTarifa { get; set; }

        [Display(Name = "Descripción Tarifa")]
        public string DescripcionT { get; set; }
    }
}