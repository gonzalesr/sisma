﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SISMAEntities : DbContext
    {
        public SISMAEntities()
            : base("name=SISMAEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Barrio> Barrio { get; set; }
        public virtual DbSet<Bitacora> Bitacora { get; set; }
        public virtual DbSet<Calle> Calle { get; set; }
        public virtual DbSet<CatServicio> CatServicio { get; set; }
        public virtual DbSet<CobroServicio> CobroServicio { get; set; }
        public virtual DbSet<Contrato> Contrato { get; set; }
        public virtual DbSet<DetalleCobro> DetalleCobro { get; set; }
        public virtual DbSet<EstadoServicio> EstadoServicio { get; set; }
        public virtual DbSet<Lectura> Lectura { get; set; }
        public virtual DbSet<Medidor> Medidor { get; set; }
        public virtual DbSet<Periodo> Periodo { get; set; }
        public virtual DbSet<PrecioServicio> PrecioServicio { get; set; }
        public virtual DbSet<Privilegio> Privilegio { get; set; }
        public virtual DbSet<Servicio> Servicio { get; set; }
        public virtual DbSet<Socio> Socio { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuario { get; set; }
        public virtual DbSet<Transaccion> Transaccion { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
    }
}
