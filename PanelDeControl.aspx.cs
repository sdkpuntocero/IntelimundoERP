using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public partial class PanelDeControl : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usr_ID = Guid.Empty;
        public static string str_pnlID = string.Empty, nombre_rpt = string.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    try
                    {
                        UsuarioFiltrado();
                    }
                    catch
                    {
                    }
                }
            }
            catch
            {
                Response.Redirect("acceso.aspx");
            }
        }

        private void UsuarioFiltrado()
        {
            usr_ID = (Guid)(Session["UsuarioFirmadoID"]);
            using (var mUsuario = new IntelimundoERPEntities())
            {
                var iUsuario = (from a in mUsuario.tblUsuarios
                                where a.UsuarioID == usr_ID
                                select a
                                ).FirstOrDefault();

                switch (iUsuario.TipoUsuarioID)
                {
                    case 1:

                        break;

                    case 2:

                        var iUsuarioEmpresa = (from a in mUsuario.tblUsuarios
                                               join b in mUsuario.tblUsuariosEmpresa on a.UsuarioID equals b.UsuarioID
                                               join c in mUsuario.tblEmpresa on b.EmpresaID equals c.EmpresaID
                                               where a.UsuarioID == usr_ID
                                               select new
                                               {
                                                   a.PerfilID,
                                                   a.nombres,
                                                   a.apaterno,
                                                   a.amaterno,
                                                   c.Nombre
                                               }
                                ).FirstOrDefault();

                        lblNombreUsuario.Text = iUsuarioEmpresa.nombres;
                        lblNombreApellidos.Text = iUsuarioEmpresa.apaterno + ' ' + iUsuarioEmpresa.amaterno;
                        lblCorporativo.Text = "Empresa: " + iUsuarioEmpresa.Nombre;

                        break;

                    case 3:

                        var iUsuarioCorp = (from a in mUsuario.tblUsuarios
                                            join b in mUsuario.tbl_UsuariosCorporativo on a.UsuarioID equals b.UsuarioID
                                            join c in mUsuario.tblCorporativo on b.CorporativoID equals c.CorporativoID
                                            where a.UsuarioID == usr_ID
                                            select new
                                            {
                                                a.PerfilID,
                                                a.nombres,
                                                a.apaterno,
                                                a.amaterno,
                                                c.Nombre
                                            }).FirstOrDefault();

                        lblNombreUsuario.Text = iUsuarioCorp.nombres;
                        lblNombreApellidos.Text = iUsuarioCorp.apaterno + ' ' + iUsuarioCorp.amaterno;
                        lblCorporativo.Text = "Corporativo: " + iUsuarioCorp.Nombre;

                        break;
                }
            }

            i_EstatusUsuario.Attributes["style"] = "color: green";
            lbl_EstatusUsuario.Text = "Conectado";
        }

        #region funciones

        [WebMethod]
        public static List<string> busca_pnl(string prefixText, int count)
        {
            List<String> columnData = new List<String>();
            string d_f = prefixText.ToUpper();

            if (str_pnlID == "pnl_usr")
            {
                using (IntelimundoERPEntities m_df = new IntelimundoERPEntities())
                {
                    var i_df = (from i_u in m_df.tblUsuarios
                                where i_u.nombres.Contains(d_f)

                                select new
                                {
                                    nom_comp = i_u.nombres + " " + i_u.apaterno + " " + i_u.amaterno,
                                    i_u.CodigoUsuario,
                                }).ToList();

                    foreach (var ff_d in i_df)
                    {
                        columnData.Add(ff_d.nom_comp + " | " + ff_d.CodigoUsuario);
                    }
                }
            }

            return columnData;
        }

        #endregion funciones

        protected void lkbConfiguracion_Click(object sender, EventArgs e)
        {
            SConfiguracion();
            upConfiguracion.Visible = true;
            cardUsuario.Visible = false;
            upConfiguracion.Update();
        }

        #region RegistroInicial

        private void SConfiguracion()
        {
            sTipoRFCEmpresa.Items.Clear();
            sColoniaEmpresa.Items.Clear();
            sColoniaCorporativo.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dConfiguracion = (from c in mConfiguracion.CatTipoRFC
                                      select c).ToList();

                sTipoRFCEmpresa.DataSource = dConfiguracion;
                sTipoRFCEmpresa.DataTextField = "Descripcion";
                sTipoRFCEmpresa.DataValueField = "TipoRFCID";
                sTipoRFCEmpresa.DataBind();

                sTipoRFCEmpresa.Items.Insert(0, new ListItem("Tipo RFC", string.Empty));
            }

            sColoniaEmpresa.Items.Insert(0, new ListItem("Colonia", string.Empty));
            sColoniaCorporativo.Items.Insert(0, new ListItem("Colonia", string.Empty));
        }

        protected void btnGuarda_Click(object sender, EventArgs e)
        {
            string strNombreDirector = null, strApaternoDirector = null, strAmaternoDirector = null, strNombreEmpresa = null, strNombreCorporativo = null, strCalleNumeroEmpresa = null, strCalleNumeroCorporativo = null;

            string striNombreDirector = Request.Form["iNombreDirector"];
            string striApaternoDirector = Request.Form["iApaternoDirector"];
            string striAmaternoDirector = Request.Form["iAmaternoDirector"];
            string striNombreEmpresa = Request.Form["iNombreEmpresa"];
            int sTipoRFCEmpresa = int.Parse(Request.Form["sTipoRFCEmpresa"]);
            string striRFCEmpresa = Request.Form["iRFCEmpresa"];
            string striEmailEmpresa = Request.Form["iEmailEmpresa"];
            string striTelefonoEmpresa = Request.Form["iTelefonoEmpresa"];
            string striCalleNumeroEmpresa = Request.Form["iCalleNumeroEmpresa"];
            string striCodigoPostalEmpresa = Request.Form["iCodigoPostalEmpresa"];
            int sColoniaEmpresa = int.Parse(Request.Form["sColoniaEmpresa"]);
            string striNombreCorporativo = Request.Form["iNombreCorporativo"];
            string striEmailCorporativo = Request.Form["iEmailCorporativo"];
            string striTelefonoCorporativo = Request.Form["iTelefonoCorporativo"];
            string striCalleNumeroCorporativo = Request.Form["iCalleNumeroCorporativo"];
            string striCodigoPostalCorporativo = Request.Form["iCodigoPostalCorporativo"];
            int sColoniaCorporativo = int.Parse(Request.Form["sColoniaCorporativo"]);

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompania = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompaniaNombre = new CultureInfo("es-MX", false).TextInfo;

            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            strNombreDirector = CINombre.ToTitleCase(striNombreDirector.ToLower());
            strApaternoDirector = CIApaterno.ToTitleCase(striApaternoDirector.ToLower());
            strAmaternoDirector = CIAmaterno.ToTitleCase(striAmaternoDirector.ToLower());

            strNombreEmpresa = CICompania.ToTitleCase(striNombreEmpresa.ToLower());
            strNombreCorporativo = CICompaniaNombre.ToTitleCase(striNombreCorporativo.ToLower());
            strCalleNumeroEmpresa = CICalleNum.ToTitleCase(striCalleNumeroEmpresa.ToLower());
            strCalleNumeroCorporativo = CICalleNum.ToTitleCase(striCalleNumeroCorporativo.ToLower());

            ControlEmpresa.AltaEmpresa(strNombreEmpresa, sTipoRFCEmpresa, striRFCEmpresa, striEmailEmpresa, striTelefonoEmpresa, striCalleNumeroEmpresa, striCodigoPostalEmpresa, sColoniaEmpresa);
            ControlUsuarios.AltaUsuario(2, 2, strNombreDirector, strApaternoDirector, strAmaternoDirector);

            if (ControlCorporativo.AltaCorporativo(strNombreCorporativo, striEmailCorporativo, striTelefonoCorporativo, striCalleNumeroCorporativo, striCodigoPostalCorporativo, sColoniaCorporativo))

            {
                limpiaRegistroInicial();
                Mensaje("Datos guardados con éxito, favor de revisar su correo donde se le enviaran las credenciales de acceso, revisar su bandeja de spam");
            }
            else
            {
                Mensaje("Error.");
            }
        }

        private void limpiaRegistroInicial()
        {
            SConfiguracion();
            iNombreDirector.Value = string.Empty;
            iApaternoDirector.Value = string.Empty;
            iAmaternoDirector.Value = string.Empty;
            iNombreEmpresa.Value = string.Empty;

            iRFCEmpresa.Value = string.Empty;
            iEmailEmpresa.Value = string.Empty;
            iTelefonoEmpresa.Value = string.Empty;
            iCalleNumeroEmpresa.Value = string.Empty;
            iCodigoPostalEmpresa.Value = string.Empty;
            iMunicipioEmpresa.Value = string.Empty;
            iEstadoEmpresa.Value = string.Empty;
            iNombreCorporativo.Value = string.Empty;
            iEmailCorporativo.Value = string.Empty;
            iTelefonoCorporativo.Value = string.Empty;
            iCalleNumeroCorporativo.Value = string.Empty;
            iCodigopostalCorporativo.Value = string.Empty;
            iMunicipioCorporativo.Value = string.Empty;
            iEstadoCorporativo.Value = string.Empty;
        }

        #endregion RegistroInicial

        protected void btnCodigoPostalEmpresa_Click(object sender, EventArgs e)
        {
            string str_cp = iCodigoPostalEmpresa.Value;

            DataSet ListCP = CodigoPostal.FiltroCP(str_cp);

            if (ListCP.Tables[0].Rows.Count == 0)
            {
                sColoniaEmpresa.Items.Clear();

                sColoniaEmpresa.Items.Insert(0, new ListItem("Colonia", string.Empty));

                iMunicipioEmpresa.Value = string.Empty;
                iEstadoEmpresa.Value = string.Empty;
                sColoniaEmpresa.Attributes.Add("required", "required");
            }
            else
            {
                sColoniaEmpresa.DataSource = ListCP;
                sColoniaEmpresa.DataTextField = "Colonia";
                sColoniaEmpresa.DataValueField = "ColoniaID";
                sColoniaEmpresa.DataBind();

                iMunicipioEmpresa.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                iEstadoEmpresa.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                sColoniaEmpresa.Attributes.Add("required", string.Empty);
                sColoniaEmpresa.Items.Insert(0, new ListItem("Colonia", string.Empty));
            }

            upConfiguracion.Update();
        }

        protected void btnCodigopostalCorporativo_Click(object sender, EventArgs e)
        {
            string str_cp = iCodigopostalCorporativo.Value;

            DataSet ListCP = CodigoPostal.FiltroCP(str_cp);

            if (ListCP.Tables[0].Rows.Count == 0)
            {
                sColoniaCorporativo.Items.Clear();

                sColoniaCorporativo.Items.Insert(0, new ListItem("Colonia", string.Empty));

                iMunicipioCorporativo.Value = string.Empty;
                iEstadoCorporativo.Value = string.Empty;
                sColoniaCorporativo.Attributes.Add("required", "required");
            }
            else
            {
                sColoniaCorporativo.DataSource = ListCP;
                sColoniaCorporativo.DataTextField = "Colonia";
                sColoniaCorporativo.DataValueField = "ColoniaID";
                sColoniaCorporativo.DataBind();

                iMunicipioCorporativo.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                iEstadoCorporativo.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                sColoniaCorporativo.Attributes.Add("required", string.Empty);
                sColoniaCorporativo.Items.Insert(0, new ListItem("Colonia", string.Empty));
            }

            upConfiguracion.Update();
        }

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }

        protected void btnLimpiaRegistro_Click(object sender, EventArgs e)
        {
            limpiaRegistroInicial();
        }

        protected void lkbRegistroInicial_Click(object sender, EventArgs e)
        {
            using (IntelimundoERPEntities mRegistroInicial = new IntelimundoERPEntities())
            {
                var iRegistroInicial = (from c in mRegistroInicial.tblNotificacion
                                        select c).ToList();

                if (iRegistroInicial.Count == 0)
                {
                    Mensaje("Sin correo para notificaciones, favor de verificar.");
                }
                else
                {
                    upRegistroInicial.Visible = true;
                    upNotificaciones.Visible = false;
                    upRegistroInicial.Update();
                    upNotificaciones.Update();
                }
            }
        }

        protected void lkbNotificaciones_Click(object sender, EventArgs e)
        {
            upRegistroInicial.Visible = false;
            upNotificaciones.Visible = true;
            upRegistroInicial.Update();
            upNotificaciones.Update();
        }

        protected void lkbCatalogos_Click(object sender, EventArgs e)
        {
            upRegistroInicial.Visible = false;

            upNotificaciones.Visible = false;
            upRegistroInicial.Update();
            upNotificaciones.Update();
        }

        protected void lkbRegIniEdit_Click(object sender, EventArgs e)
        {
            using (IntelimundoERPEntities mRegistroInicial = new IntelimundoERPEntities())
            {
                var iRegistroInicial = (from c in mRegistroInicial.tblEmpresa
                                        select c).ToList();

                var iDirector = (from c in mRegistroInicial.tblUsuarios
                                 where c.TipoUsuarioID == 2
                                 select c).ToList();

                var iCorporativo = (from c in mRegistroInicial.tblCorporativo
                                    select c).ToList();

                if (iRegistroInicial.Count == 0)
                {
                }
                else
                {
                    iNombreDirector.Value = iDirector[0].nombres;
                    iApaternoDirector.Value = iDirector[0].apaterno;
                    iAmaternoDirector.Value = iDirector[0].amaterno;
                    iNombreEmpresa.Value = iRegistroInicial[0].Nombre;
                    sTipoRFCEmpresa.Value = iRegistroInicial[0].TipoRFCID.ToString();
                    iRFCEmpresa.Value = iRegistroInicial[0].RFC;
                    iEmailEmpresa.Value = iRegistroInicial[0].email;
                    iTelefonoEmpresa.Value = iRegistroInicial[0].Telefono;
                    iCalleNumeroEmpresa.Value = iRegistroInicial[0].CalleNumero;
                    iCodigoPostalEmpresa.Value = iRegistroInicial[0].CodigoPostal;

                    string str_cp = iRegistroInicial[0].CodigoPostal;

                    DataSet ListCP = CodigoPostal.FiltroCP(str_cp);

                    if (ListCP.Tables[0].Rows.Count == 0)
                    {
                        sColoniaEmpresa.Items.Clear();

                        sColoniaEmpresa.Items.Insert(0, new ListItem("Colonia", string.Empty));

                        iMunicipioEmpresa.Value = string.Empty;
                        iEstadoEmpresa.Value = string.Empty;
                        sColoniaEmpresa.Attributes.Add("required", "required");
                    }
                    else
                    {
                        sColoniaEmpresa.Items.Clear();
                        sColoniaEmpresa.DataSource = ListCP;
                        sColoniaEmpresa.DataTextField = "Colonia";
                        sColoniaEmpresa.DataValueField = "ColoniaID";
                        sColoniaEmpresa.DataBind();

                        sColoniaEmpresa.Value = iRegistroInicial[0].ColoniaID.ToString();

                        iMunicipioEmpresa.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                        iEstadoEmpresa.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                        sColoniaEmpresa.Attributes.Add("required", string.Empty);
                        sColoniaEmpresa.Items.Insert(0, new ListItem("Colonia", string.Empty));
                    }

                    iNombreCorporativo.Value = iCorporativo[0].Nombre;
                    iEmailCorporativo.Value = iCorporativo[0].email;
                    iTelefonoCorporativo.Value = iCorporativo[0].Telefono;
                    iCalleNumeroCorporativo.Value = iCorporativo[0].CalleNumero;
                    iCodigopostalCorporativo.Value = iCorporativo[0].CodigoPostal;

                    string str_cpCorp = iCorporativo[0].CodigoPostal;
                    DataSet ListCPCorp = CodigoPostal.FiltroCP(str_cpCorp);

                    if (ListCP.Tables[0].Rows.Count == 0)
                    {
                        sColoniaCorporativo.Items.Clear();

                        sColoniaCorporativo.Items.Insert(0, new ListItem("Colonia", string.Empty));

                        iMunicipioCorporativo.Value = string.Empty;
                        iEstadoCorporativo.Value = string.Empty;
                        sColoniaCorporativo.Attributes.Add("required", "required");
                    }
                    else
                    {
                        sColoniaCorporativo.DataSource = ListCP;
                        sColoniaCorporativo.DataTextField = "Colonia";
                        sColoniaCorporativo.DataValueField = "ColoniaID";
                        sColoniaCorporativo.DataBind();

                        sColoniaCorporativo.Value = iCorporativo[0].ColoniaID.ToString();

                        iMunicipioCorporativo.Value = ListCP.Tables[0].Rows[0]["Municipio"].ToString();
                        iEstadoCorporativo.Value = ListCP.Tables[0].Rows[0]["Estado"].ToString();
                        sColoniaCorporativo.Attributes.Add("required", string.Empty);
                        sColoniaCorporativo.Items.Insert(0, new ListItem("Colonia", string.Empty));
                    }
                }
            }
        }

        protected void lkbNoti_Click(object sender, EventArgs e)
        {
            using (IntelimundoERPEntities m_comp = new IntelimundoERPEntities())
            {
                var i_comp = (from i_i in m_comp.tblNotificacion
                              select i_i).ToList();

                i_email.Value = i_comp[0].email;
                i_email_usr.Value = i_comp[0].Usuario;
                i_email_clave.Value = i_comp[0].Clave;
                i_asunto.Value = i_comp[0].Asunto;
                i_smtp.Value = i_comp[0].SMTP;
                i_puerto.Value = i_comp[0].Puerto.ToString();
            }
        }

        protected void btnNotificacion_Click(object sender, EventArgs e)
        {
            string iEmail = Request.Form["i_email"];
            string iUsuario = Request.Form["i_email_usr"];
            string iClave = Request.Form["i_email_clave"];
            string iAsunto = Request.Form["i_asunto"];
            string iSMTP = Request.Form["i_smtp"];
            int iPuerto = int.Parse(Request.Form["i_puerto"]);

            TextInfo t_asunto = new CultureInfo("es-MX", false).TextInfo;
            string strAsunto = t_asunto.ToTitleCase(iAsunto);

            if (EnviarCorreo.AltaNotificacion(iEmail, iUsuario, iClave, strAsunto, iSMTP, iPuerto))
            {
                LimpiaNotificacion();
                Mensaje("Datos guardados con éxito");
            }
            else
            {
                Mensaje("Err.");
            }
        }

        private void LimpiaNotificacion()
        {
            i_email.Value = string.Empty;
            i_email_usr.Value = string.Empty;
            i_email_clave.Value = string.Empty;
            i_asunto.Value = string.Empty;
            i_smtp.Value = string.Empty;
            i_puerto.Value = string.Empty;
        }

        protected void btnLimpiaNotificacion_Click(object sender, EventArgs e)
        {
            LimpiaNotificacion();
        }

        protected void lkbControlUsuarios_Click(object sender, EventArgs e)
        {
            str_pnlID = "pnl_usr";
            upConfiguracion.Visible = false;
            upUsuario.Visible = true;
            cardUsuario.Visible = true;
            upUsuario.Update();
        }

        protected void lkbAgregarUsuario_Click(object sender, EventArgs e)
        {
            sComposUsuario();
            divDatosUsuario.Visible = true;
        }

        private void sComposUsuario()
        {
            sAreaUsuario.Items.Clear();
            sPerfilUsuario.Items.Clear();
            SGeneroUsuario.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dConfiguracion = (from c in mConfiguracion.catAreas
                                      select c).ToList();

                sAreaUsuario.DataSource = dConfiguracion;
                sAreaUsuario.DataTextField = "Descripcion";
                sAreaUsuario.DataValueField = "AreaID";
                sAreaUsuario.DataBind();

                sAreaUsuario.Items.Insert(0, new ListItem("Área", string.Empty));

                var dGenero = (from c in mConfiguracion.catGenero
                               select c).ToList();

                SGeneroUsuario.DataSource = dGenero;
                SGeneroUsuario.DataTextField = "Descripcion";
                SGeneroUsuario.DataValueField = "GeneroID";
                SGeneroUsuario.DataBind();

                SGeneroUsuario.Items.Insert(0, new ListItem("Género", string.Empty));
            }

            sPerfilUsuario.Items.Insert(0, new ListItem("Perfil", string.Empty));
        }

        protected void lkbBuscaUsuario_Click(object sender, EventArgs e)
        {
            divDatosUsuario.Visible = false;
            string f_busqueda = string.Empty;
            Guid guid_usrid;

            if (string.IsNullOrEmpty(iBuscaUsuario.Text))
            {
            }
            else
            {
                f_busqueda = Request.Form["iBuscaUsuario"].ToString().ToUpper().Trim();
                if (f_busqueda == "TODO")
                {
                    f_busqueda = Request.Form["iBuscaUsuario"].ToString().ToUpper().Trim();

                    using (IntelimundoERPEntities md_fb = new IntelimundoERPEntities())
                    {
                        using (IntelimundoERPEntities m_usrf = new IntelimundoERPEntities())
                        {
                            var i_f_bff = (from i_u in m_usrf.tblUsuarios

                                           select new
                                           {
                                               i_u.UsuarioID,
                                               i_u.Usuario,
                                               nom_comp = i_u.nombres + " " + i_u.apaterno + " " + i_u.amaterno,
                                               i_u.FechaRegistro
                                           }).OrderBy(x => x.Usuario).ToList();

                            if (i_f_bff.Count == 0)
                            {
                                gvUsuarios.DataSource = i_f_bff;
                                gvUsuarios.DataBind();
                                gvUsuarios.Visible = true;
                         

                                Mensaje("Usuario no encontrado.");
                            }
                            else
                            {
                                gvUsuarios.DataSource = i_f_bff;
                                gvUsuarios.DataBind();
                                gvUsuarios.Visible = true;
                         
                            }
                        }
                    }
                }
                else
                {
                    try
                    {
                        f_busqueda = Request.Form["iBuscaUsuario"].ToString().ToUpper().Trim();
                        string n_fv;

                        Char char_s = '|';
                        string d_rub = f_busqueda;
                        String[] de_rub = d_rub.Trim().Split(char_s);

                        n_fv = de_rub[1].Trim();

                        using (IntelimundoERPEntities m_usrf = new IntelimundoERPEntities())
                        {
                            var i_f_bf = (from c in m_usrf.tblUsuarios
                                          where c.Usuario == n_fv
                                          select c).FirstOrDefault();

                            guid_usrid = i_f_bf.UsuarioID;

                            var i_f_bff = (from i_u in m_usrf.tblUsuarios

                                           where i_u.UsuarioID == guid_usrid
                                           select new
                                           {
                                               i_u.UsuarioID,
                                               i_u.Usuario,
                                               nom_comp = i_u.nombres + " " + i_u.apaterno + " " + i_u.amaterno,
                                               i_u.FechaRegistro
                                           }).OrderBy(x => x.Usuario).ToList();

                            if (i_f_bff.Count == 0)
                            {
                                gvUsuarios.DataSource = i_f_bff;
                                gvUsuarios.DataBind();
                                gvUsuarios.Visible = true;
                                gvUsuarios.Visible = true;

                                Mensaje("Usuario no encontrado.");
                            }
                            else
                            {
                                gvUsuarios.DataSource = i_f_bff;
                                gvUsuarios.DataBind();
                                gvUsuarios.Visible = true;
                                gvUsuarios.Visible = true;
                            }
                        }
                    }
                    catch
                    {
                        //limp_usr_ctrl();
                        //div_prospecto.Visible = false;
                        Mensaje("Usuario no encontrado.");
                    }
                }
            }
        }

        protected void sAreaUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            int iAreaUusarios = int.Parse(sAreaUsuario.SelectedValue);

            sPerfilUsuario.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dConfiguracion = (from a in mConfiguracion.catPerfil
                                      join b in mConfiguracion.tblAreasPerfil on a.PerfilID equals b.PerfilID
                                      where b.AreaID == iAreaUusarios
                                      select a).ToList();

                sPerfilUsuario.DataSource = dConfiguracion;
                sPerfilUsuario.DataTextField = "Descripcion";
                sPerfilUsuario.DataValueField = "PerfilID";
                sPerfilUsuario.DataBind();

                sPerfilUsuario.Items.Insert(0, new ListItem("Perfil", string.Empty));
            }
        }

        protected void btnControlUsuario_Click(object sender, EventArgs e)
        {
            Guid guid_usr = Guid.NewGuid();

            string i_nombres = string.Empty, i_aparterno = string.Empty, i_amaterno = string.Empty, strUsuario = string.Empty, str_clave = string.Empty;
            string i_nombres_o = Request.Form["iNombresUsuario"];
            string i_aparterno_o = Request.Form["iApaternoUsuario"];
            string i_amaterno_o = Request.Form["iAmaternoUsuario"];

            try
            {
                strUsuario = ControlUsuarios.GeneraUsuario(i_nombres_o, i_aparterno_o, i_amaterno_o);
                iUsuario.Value = strUsuario;

                iEmailCorporativoUsuario.Value = strUsuario + "@intelimundo.com.mx";
                btnGuardaUsuario.Enabled = true;
            }
            catch
            {
                Mensaje("Se requiere mínimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.");
            }
        }

        protected void btnGuardaUsuario_Click(object sender, EventArgs e)
        {
            string strNombreUsuario = null, strApaternoUsuario = null, strAmaternoUsuario = null;

            string striNombreUsuario = Request.Form["iNombresUsuario"];
            string striApaternoUsuario = Request.Form["iApaternoUsuario"];
            string striAmaternoUsuario = Request.Form["iAmaternoUsuario"];

            TextInfo CINombre = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIApaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CIAmaterno = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompania = new CultureInfo("es-MX", false).TextInfo;
            TextInfo CICompaniaNombre = new CultureInfo("es-MX", false).TextInfo;

            TextInfo CICalleNum = new CultureInfo("es-MX", false).TextInfo;

            strNombreUsuario = CINombre.ToTitleCase(striNombreUsuario.ToLower());
            strApaternoUsuario = CIApaterno.ToTitleCase(striApaternoUsuario.ToLower());
            strAmaternoUsuario = CIAmaterno.ToTitleCase(striAmaternoUsuario.ToLower());

            int sPerfilUsuario = int.Parse(Request.Form["sPerfilUsuario"]);

            if (ControlUsuarios.AltaUsuario(3, sPerfilUsuario, strNombreUsuario, strApaternoUsuario, strAmaternoUsuario))

            {
                limpiaRegistroUsuario();
                Mensaje("Datos guardados con éxito, favor de revisar su correo donde se le enviaran las credenciales de acceso, revisar su bandeja de spam");
            }
            else
            {
                Mensaje("Error.");
            }
        }

        protected void lkbControlCentros_Click(object sender, EventArgs e)
        {

            cardUsuario.Visible = false;
            upUsuario.Visible = false;
   
            
        }

        private void limpiaRegistroUsuario()
        {
        }

        protected void lkb_salir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }
    }
}