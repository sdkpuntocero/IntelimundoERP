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
    
    public partial class tblEgresos
    {
        public System.Guid EgresosID { get; set; }
        public string Descripcion { get; set; }
        public string Caracteristica { get; set; }
        public Nullable<decimal> Costo { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public System.Guid CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
    }
}
