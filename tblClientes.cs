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
    
    public partial class tblClientes
    {
        public System.Guid ClientesID { get; set; }
        public Nullable<int> TipoUsuarioID { get; set; }
        public Nullable<int> PerfilID { get; set; }
        public string CodigoUsuario { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string nombres { get; set; }
        public string apaterno { get; set; }
        public string amaterno { get; set; }
        public Nullable<int> GeneroID { get; set; }
        public Nullable<int> TipoRFCID { get; set; }
        public string RFC { get; set; }
        public string email { get; set; }
        public string Telefono { get; set; }
        public string CalleNumero { get; set; }
        public string CodigoPostal { get; set; }
        public Nullable<int> ColoniaID { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public System.Guid UsuarioID { get; set; }
        public System.Guid CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
    }
}