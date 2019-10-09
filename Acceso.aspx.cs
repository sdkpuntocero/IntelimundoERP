using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public partial class Acceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_acceso_Click(object sender, EventArgs e)
        {
            string strUsuario, strClave, strValClave;
            int intPerfilID;
            Guid GuidUsario;

            strUsuario = i_usuario.Value;
            strClave = Encrypta.Encrypt(i_clave.Value);

            try

            {
                using (var m_usr = new IntelimundoERPEntities())
                {
                    var i_usr = (from i_u in m_usr.tblUsuarios
                                 where i_u.Usuario == strUsuario
                                 select new
                                 {
                                     i_u.UsuarioID,
                                     i_u.Clave,
                                     i_u.PerfilID
                                 }).ToList();

                    intPerfilID = int.Parse(i_usr[0].PerfilID.ToString());
                    GuidUsario = i_usr[0].UsuarioID;
                    strValClave = i_usr[0].Clave;
                    string dos = "fGVifCvpWWGgKTZ46axSOQ==";


                    string pass_de = Encrypta.Decrypt(dos);
                    using (var m_corp = new IntelimundoERPEntities())
                    {
                        var d_corp = (from i_corp in m_corp.tblCorporativo
                                      select i_corp).ToList();

                        if (d_corp.Count == 0)
                        {
                            //HttpCookie usr_cookie = new HttpCookie("usr_cookie", usrf_ID.ToString());
                            //Response.Cookies.Add(usr_cookie);
                            Session["UsuarioFirmadoID"] = GuidUsario;

                            Response.Redirect("PanelDeControl.aspx");
                        }
                        else
                        {
                            if (i_usr.Count == 0)
                            {
                                Mensaje("Usuario no existe, favor de re-intentar");
                            }
                            else
                            {
                                if (strClave == strValClave)
                                {
                                    //HttpCookie usr_cookie = new HttpCookie("usr_cookie", usrf_ID.ToString());
                                    //Response.Cookies.Add(usr_cookie);
                                    Session["UsuarioFirmadoID"] = GuidUsario;
                                    switch (intPerfilID)
                                    {
                                        case 1:

                                            Response.Redirect("PanelDeControl.aspx");
                                            break;
                                        case 2:

                                            Response.Redirect("PanelDeControl.aspx");
                                            break;
                                        case 3:



                                            Response.Redirect("pnl_control.aspx");
                                            break;

                                        case 4:

                                            Response.Redirect("pnl_control.aspx");

                                            break;

                                        case 5:
                                            Mensaje("Sin Acceso, favor de contactar al Corporativo");
                                            break;

                                        case 6:
                                            Mensaje("Sin Acceso, favor de contactar al Corporativo");
                                            break;

                                        case 7:

                                            Mensaje("Sin Acceso, favor de contactar al Corporativo");
                                            break;

                                        case 8:



                                            Response.Redirect("pnl_control.aspx");
                                            break;
                                        case 9:

                                            Response.Redirect("pnl_control.aspx");
                                            break;
                                        case 10:

                                            Response.Redirect("pnl_control.aspx");
                                            break;

                                        default:

                                            break;
                                    }
                                }
                                else
                                {
                                    Mensaje("Contraseña incorrecta, favor de re-intentar");
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                Mensaje("Datos incorrectos, favor de re-intentar");
            }
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}