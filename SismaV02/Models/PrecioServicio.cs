//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SismaV02.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class PrecioServicio
    {
        public int CodCategoria { get; set; }
        public int CodServicio { get; set; }
        public decimal PrecioUnit { get; set; }
    
        public virtual CatServicio CatServicio { get; set; }
        public virtual Servicio Servicio { get; set; }
    }
}
