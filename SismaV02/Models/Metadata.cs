using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SismaV02.Models
{
    public class BarrioMetadata
    {
        [Display(Name = "Código")]
        public string CodBarrio;

        [StringLength(50)]
        [Display(Name = "Barrio")]
        public string NomBarrio;
    }

    public class CalleMetadata
    {
        [Display(Name = "Código")]
        public int CodCalle { get; set; }
        [Display(Name = "Barrio")]
        public int CodBarrio { get; set; }
        [Display(Name = "Calle")]
        public string NomCalle { get; set; }
    }
}