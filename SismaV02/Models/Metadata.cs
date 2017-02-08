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

    public class BitacoraMetadata
    {
        [Display(Name = "Código")]
        public int CodBitac { get; set; }
        [Display(Name = "Fecha")]
        public System.DateTime FechaBitac { get; set; }
        public System.TimeSpan Hora { get; set; }

        public string Tabla { get; set; }
        public string Registro { get; set; }
        [Display(Name = "Transacción")]
        public int CodTransac { get; set; }
        [Display(Name = "Usuario")]
        public int CodUsuario { get; set; }
    }
    public class CatServicioMetadata
    {
        [Display(Name = "Código")]
        public int CodCategoria { get; set; }
        [Display(Name = "Categoría")]
        public string NomCategoria { get; set; }

    }

    public class CobroServicioMetadata
    {
        [Display(Name = "Código")]
        public int CodCobro { get; set; }
        [Display(Name = "Monto Total")]
        public decimal MontoTotal { get; set; }
        public System.DateTime Fecha { get; set; }
        public string Glosa { get; set; }
        [Display(Name = "Usuario")]
        public int CodUsuario { get; set; }
        [Display(Name = "Contrato")]
        public int codContrato { get; set; }
    }

    public class PrecioServicioMetadata
    {
        [Key]
        [Column(Order = 0)]
        public int CodCategoria { get; set; }
        [Key]
        [Column(Order = 1)]
        public int CodServicio { get; set; }
        //public decimal PrecioUnit { get; set; }

        //public virtual CatServicio CatServicio { get; set; }
        //public virtual Servicio Servicio { get; set; }
    }
}