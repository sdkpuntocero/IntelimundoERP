using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public partial class Test : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                }
                else
                {
                    Page.Validate();

                    if (Page.IsValid == true)
                    {
                        guarda_registro();
                    }
                }
            }
            catch
            {
                //Response.Redirect("acceso.aspx");
            }
        }

        private void guarda_registro()
        {
            string i_nombres_o = Request.Form["i_nombres"];
            string i_aparterno_o = Request.Form["i_apellidos"];
          
       
          
            string i_emal_c = Request.Form["i_email"];
            string i_clave = Request.Form["i_clave"]; 

             TextInfo t_nombres = new CultureInfo("es-MX", false).TextInfo;
            TextInfo t_apateno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo t_amateno = new CultureInfo("es-MX", false).TextInfo;

            string dd_nombres = t_nombres.ToTitleCase(i_nombres_o.ToLower());
            string dd_apaterno = t_apateno.ToTitleCase(i_aparterno_o.ToLower());

            //ControlUsuarios.AltaUsuario(Guid.Parse("FB41A6C7-F0DA-4877-B7E0-5784FF4E4A35"),dd_nombres,i_clave,i_emal_c,Guid.NewGuid(), 1, "USR0050");
        }


        protected void lkbCentroAgregar_Click(object sender, EventArgs e)
        {
        
        }
    }
}