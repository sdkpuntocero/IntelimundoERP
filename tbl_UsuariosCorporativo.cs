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
    
    public partial class tbl_UsuariosCorporativo
    {
        public int UsuariosCorporativoID { get; set; }
        public Nullable<System.Guid> UsuarioID { get; set; }
        public System.Guid CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
        public virtual tblUsuarios tblUsuarios { get; set; }
    }
}
