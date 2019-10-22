//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class tblUsuarios
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tblUsuarios()
        {
            this.tblUsuariosCorporativo = new HashSet<tblUsuariosCorporativo>();
            this.tblUsuariosEmpresa = new HashSet<tblUsuariosEmpresa>();
        }
    
        public System.Guid UsuarioID { get; set; }
        public Nullable<int> TipoUsuarioID { get; set; }
        public Nullable<int> PerfilID { get; set; }
        public string CodigoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string nombres { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public Nullable<int> GeneroID { get; set; }
        public Nullable<System.DateTime> FechaNacimiento { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
    
        public virtual catGenero catGenero { get; set; }
        public virtual catTipoUsuario catTipoUsuario { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuariosCorporativo> tblUsuariosCorporativo { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tblUsuariosEmpresa> tblUsuariosEmpresa { get; set; }
        public virtual catEstatusRegistro catEstatusRegistro { get; set; }
    }
}
