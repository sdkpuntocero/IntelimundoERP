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
    
    public partial class tblNotificacion
    {
        public System.Guid NotificacionID { get; set; }
        public Nullable<int> Notificacion { get; set; }
        public string email { get; set; }
        public string Usuario { get; set; }
        public string Clave { get; set; }
        public string Asunto { get; set; }
        public string SMTP { get; set; }
        public Nullable<int> Puerto { get; set; }
        public Nullable<int> EstatusRegistroID { get; set; }
        public Nullable<System.DateTime> FechaRegistro { get; set; }
        public Nullable<System.Guid> CorporativoID { get; set; }
    
        public virtual tblCorporativo tblCorporativo { get; set; }
    }
}