﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace IntelimundoERP
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class IntelimundoERPEntities : DbContext
    {
        public IntelimundoERPEntities()
            : base("name=IntelimundoERPEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<catAreas> catAreas { get; set; }
        public virtual DbSet<catBusquedaCentro> catBusquedaCentro { get; set; }
        public virtual DbSet<catBusquedaUsuario> catBusquedaUsuario { get; set; }
        public virtual DbSet<catEstatusRegistro> catEstatusRegistro { get; set; }
        public virtual DbSet<catGenero> catGenero { get; set; }
        public virtual DbSet<catLicencia> catLicencia { get; set; }
        public virtual DbSet<catPerfil> catPerfil { get; set; }
        public virtual DbSet<catTipoCentro> catTipoCentro { get; set; }
        public virtual DbSet<CatTipoRFC> CatTipoRFC { get; set; }
        public virtual DbSet<catTipoUsuario> catTipoUsuario { get; set; }
        public virtual DbSet<tblAreasPerfil> tblAreasPerfil { get; set; }
        public virtual DbSet<tblCentro> tblCentro { get; set; }
        public virtual DbSet<tblControlLicencias> tblControlLicencias { get; set; }
        public virtual DbSet<tblCorporativo> tblCorporativo { get; set; }
        public virtual DbSet<tblEgresos> tblEgresos { get; set; }
        public virtual DbSet<tblEmpresa> tblEmpresa { get; set; }
        public virtual DbSet<tblMexCP> tblMexCP { get; set; }
        public virtual DbSet<tblNotificacion> tblNotificacion { get; set; }
        public virtual DbSet<tblServicios> tblServicios { get; set; }
        public virtual DbSet<tblUsuarios> tblUsuarios { get; set; }
        public virtual DbSet<tblUsuariosCorporativo> tblUsuariosCorporativo { get; set; }
        public virtual DbSet<tblUsuariosEmpresa> tblUsuariosEmpresa { get; set; }
    }
}
