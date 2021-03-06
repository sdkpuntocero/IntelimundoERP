﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public partial class Panel : System.Web.UI.Page
    {
        public static Guid empf_ID = Guid.Empty, usr_ID = Guid.Empty;
        public static string FiltroUP = string.Empty, nombre_rpt = string.Empty;
        public static int BusquedaUsuarioID;

        protected void Page_Load(object sender, EventArgs e)
        {
            //try
            //{
            if (!IsPostBack)
            {
                //try
                //{
                UsuarioFiltrado();
                //}
                //catch
                //{
                //}
            }
            //}
            //catch
            //{
            //    Response.Redirect("acceso.aspx");
            //}
        }

        [WebMethod]
        public static List<string> busca_pnl(string prefixText, int count)
        {
            List<String> columnData = new List<String>();
            string d_f = prefixText.ToUpper();

            if (FiltroUP == "pnl_usr")
            {
                if (BusquedaUsuarioID == 1)
                {
                    using (IntelimundoERPEntities m_df = new IntelimundoERPEntities())
                    {
                        var i_df = (from a in m_df.tblUsuarios

                                    where a.Nombres.Contains(d_f)
                                    where a.UsuarioID != usr_ID

                                    select new
                                    {
                                        nom_comp = a.Nombres + " " + a.Apaterno + " " + a.Amaterno,
                                        a.CodigoUsuario,
                                    }).ToList();

                        foreach (var ff_d in i_df)
                        {
                            columnData.Add(ff_d.nom_comp + " | " + ff_d.CodigoUsuario);
                        }
                    }
                }
            }

            return columnData;
        }

        private void UsuarioFiltrado()
        {
            Guid usr_ID = (Guid)(Session["UsuarioFirmadoID"]);
            using (var mUsuario = new IntelimundoERPEntities())
            {
                var iUsuario = (from a in mUsuario.tblUsuarios
                                where a.UsuarioID == usr_ID
                                select a
                                ).FirstOrDefault();

                switch (iUsuario.TipoUsuarioID)
                {
                    case 1:

                        var iUsuarioDev = (from a in mUsuario.tblUsuarios

                                           where a.UsuarioID == usr_ID
                                           select new
                                           {
                                               a.PerfilID,
                                               a.Nombres,
                                               a.Apaterno,
                                               a.Amaterno,
                                           }
                                ).FirstOrDefault();

                        lblNombreUsuario.Text = iUsuarioDev.Nombres;
                        lblNombreApellidos.Text = iUsuarioDev.Apaterno + ' ' + iUsuarioDev.Amaterno;
                        lblCorporativo.Text = "Desarrollo";

                        break;

                    case 2:

                        var iUsuarioEmpresa = (from a in mUsuario.tblUsuarios
                                               join b in mUsuario.tblUsuariosCorporativo on a.UsuarioID equals b.UsuarioID
                                               join c in mUsuario.tblCorporativo on b.CorporativoID equals c.CorporativoID
                                               where a.UsuarioID == usr_ID
                                               select new
                                               {
                                                   a.PerfilID,
                                                   a.Nombres,
                                                   a.Apaterno,
                                                   a.Amaterno,
                                                   c.Nombre
                                               }
                                ).FirstOrDefault();

                        lblNombreUsuario.Text = iUsuarioEmpresa.Nombres;
                        lblNombreApellidos.Text = iUsuarioEmpresa.Apaterno + ' ' + iUsuarioEmpresa.Amaterno;
                        lblCorporativo.Text = "Corporativo: " + iUsuarioEmpresa.Nombre;

                        break;

                    case 3:

                        var iUsuarioCorp = (from a in mUsuario.tblUsuarios
                                            join b in mUsuario.tblUsuariosCorporativo on a.UsuarioID equals b.UsuarioID
                                            join c in mUsuario.tblCorporativo on b.CorporativoID equals c.CorporativoID
                                            where a.UsuarioID == usr_ID
                                            select new
                                            {
                                                a.PerfilID,
                                                a.Nombres,
                                                a.Apaterno,
                                                a.Amaterno,
                                                c.Nombre
                                            }).FirstOrDefault();

                        lblNombreUsuario.Text = iUsuarioCorp.Nombres;
                        lblNombreApellidos.Text = iUsuarioCorp.Apaterno + ' ' + iUsuarioCorp.Amaterno;
                        lblCorporativo.Text = "Corporativo: " + iUsuarioCorp.Nombre;

                        break;
                }
            }

            i_EstatusUsuario.Attributes["style"] = "color: green";
            lbl_EstatusUsuario.Text = "Conectado";
        }

        #region ControlCentros

        protected void lkbControlCentros_Click(object sender, EventArgs e)
        {
            breadcrumbN1.Text = "Control de Datos";
            breadcrumbN2.Text = "Centros";
            navbreadcrumb.Visible = true;
            upbreadcrumb.Update();

            cardConfiguracion.Visible = false;
            upConfiguracion.Update();
            cardUsuario.Visible = false;
            upUsuario.Update();

            cardCentro.Visible = true;
            upCentro.Update();
        }

        private void SControlCentro()
        {
            sBusquedaCentro.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dConfiguracion = (from c in mConfiguracion.catBusquedaCentro
                                      select c).ToList();

                sBusquedaCentro.DataSource = dConfiguracion;
                sBusquedaCentro.DataTextField = "Descripcion";
                sBusquedaCentro.DataValueField = "BusquedaCentroID";
                sBusquedaCentro.DataBind();

                sBusquedaCentro.Items.Insert(0, new ListItem("*Buscar Por:", string.Empty));
            }
        }

        protected void lkbCentroAgregar_Click(object sender, EventArgs e)
        {
            divBuscaCentro.Visible = false;
            divDatosCentro.Visible = true;
            SControlLicencia();
            upCentro.Update();
        }

        private void SControlLicencia()
        {
            sLicenciaCentro.Items.Clear();
            sTipoCentro.Items.Clear();
            sColoniaCentro.Items.Clear();
            sTipoRFCFiscalC.Items.Clear();
            sColoniaFiscalC.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dTipoRFC = (from c in mConfiguracion.CatTipoRFC
                                select c).ToList();

                sTipoRFCFiscalC.DataSource = dTipoRFC;
                sTipoRFCFiscalC.DataTextField = "Descripcion";
                sTipoRFCFiscalC.DataValueField = "TipoRFCID";
                sTipoRFCFiscalC.DataBind();

                sTipoRFCFiscalC.Items.Insert(0, new ListItem("*Tipo RFC", string.Empty));

                var dLicencia = (from c in mConfiguracion.catLicencia
                                 select c).ToList();

                sLicenciaCentro.DataSource = dLicencia;
                sLicenciaCentro.DataTextField = "Descripcion";
                sLicenciaCentro.DataValueField = "LicenciaID";
                sLicenciaCentro.DataBind();

                sLicenciaCentro.Items.Insert(0, new ListItem("*Licencia", string.Empty));

                var dTipoCentro = (from c in mConfiguracion.catTipoCentro
                                   select c).ToList();

                sTipoCentro.DataSource = dTipoCentro;
                sTipoCentro.DataTextField = "Descripcion";
                sTipoCentro.DataValueField = "TipoCentroID";
                sTipoCentro.DataBind();

                sTipoCentro.Items.Insert(0, new ListItem("*Tipo de Centro", string.Empty));
            }
            sColoniaCentro.Items.Insert(0, new ListItem("*Colonia", string.Empty));
            sColoniaFiscalC.Items.Insert(0, new ListItem("*Colonia", string.Empty));
        }

        protected void lkbCentroEdita_Click(object sender, EventArgs e)
        {
            divBuscaCentro.Visible = true;
            divDatosCentro.Visible = false;
            SControlCentro();
            upCentro.Update();
        }

        #endregion ControlCentros

        #region ControlUsuarios

        protected void lkbControlUsuarios_Click(object sender, EventArgs e)
        {
            breadcrumbN1.Text = "Control de Datos";
            breadcrumbN2.Text = "Usuarios";
            navbreadcrumb.Visible = true;
            upbreadcrumb.Update();
            cardConfiguracion.Visible = false;
            upConfiguracion.Update();
            cardUsuario.Visible = true;
            upUsuario.Update();
            cardCentro.Visible = false;
            upCentro.Update();
        }

        protected void btnUsuarioG_Click(object sender, EventArgs e)
        {
            string striNombreUsuario = Request.Form["iNombresUsuario"];
            string striApaternoUsuario = Request.Form["iApaternoUsuario"];
            string striAmaternoUsuario = Request.Form["iAmaternoUsuario"];
            int sGeneroUsuario = int.Parse(Request.Form["sGeneroUsuario"]);
            DateTime iNacimientoUsuario = DateTime.Parse(Request.Form["iNacimientoUsuario"]);
            int sPerfilUsuario = int.Parse(Request.Form["sPerfilUsuario"]);
            string striEmailPersonalUsuario = Request.Form["iEmailPersonalUsuario"];
            string striEmailCorporativoUsuario = Request.Form["iEmailCorporativoUsuario"];

            if (ControlUsuarios.AltaUsuario(3, sPerfilUsuario, sGeneroUsuario, iNacimientoUsuario, striNombreUsuario, striApaternoUsuario, striAmaternoUsuario, striEmailPersonalUsuario, striEmailCorporativoUsuario))

            {
                limpiaRegistroUsuario();
                Mensaje("Datos guardados con éxito, favor de revisar su correo donde se le enviaran las credenciales de acceso, revisar su bandeja de spam");
            }
            else
            {
                Mensaje("Error.");
            }
        }

        private void sComposUsuario()
        {
            sAreaUsuario.Items.Clear();
            sPerfilUsuario.Items.Clear();
            sGeneroUsuario.Items.Clear();

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

                sGeneroUsuario.DataSource = dGenero;
                sGeneroUsuario.DataTextField = "Descripcion";
                sGeneroUsuario.DataValueField = "GeneroID";
                sGeneroUsuario.DataBind();

                sGeneroUsuario.Items.Insert(0, new ListItem("Género", string.Empty));
            }

            sPerfilUsuario.Items.Insert(0, new ListItem("Perfil", string.Empty));
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

            string i_Nombres = string.Empty, i_aparterno = string.Empty, i_Amaterno = string.Empty, strUsuario = string.Empty, str_clave = string.Empty;
            string i_Nombres_o = Request.Form["iNombresUsuario"];
            string i_aparterno_o = Request.Form["iApaternoUsuario"];
            string i_Amaterno_o = Request.Form["iAmaternoUsuario"];

            try
            {
                strUsuario = ControlUsuarios.GeneraUsuario(i_Nombres_o, i_aparterno_o, i_Amaterno_o);
                iUsuario.Value = strUsuario;

                iEmailCorporativoUsuario.Value = strUsuario + "@intelimundo.com.mx";
                btnUsuarioG.Enabled = true;
            }
            catch
            {
                Mensaje("Se requiere mínimo 2 letras por cada campo(nombre,apellido paterno, apellido materno) para generar el usuario.");
            }
        }

        private void limpiaRegistroUsuario()
        {
            sComposUsuario();
            iNombresUsuario.Value = string.Empty;
            iApaternoUsuario.Value = string.Empty;
            iAmaternoUsuario.Value = string.Empty;
            iNacimientoUsuario.Value = string.Empty;
            iUsuario.Value = string.Empty;
            iClave.Value = string.Empty;
            iEmailCorporativoUsuario.Value = string.Empty;
            iEmailPersonalUsuario.Value = string.Empty;
            iEmailCorporativoUsuario.Value = string.Empty;
        }

        #region BusquedaDeUsuarios

        private void SControlUsurio()
        {
            sBusquedaUsuario.Items.Clear();

            using (IntelimundoERPEntities mConfiguracion = new IntelimundoERPEntities())
            {
                var dConfiguracion = (from c in mConfiguracion.catBusquedaUsuario
                                      select c).ToList();

                sBusquedaUsuario.DataSource = dConfiguracion;
                sBusquedaUsuario.DataTextField = "BusquedaUsuario";
                sBusquedaUsuario.DataValueField = "BusquedaUsuarioID";
                sBusquedaUsuario.DataBind();

                sBusquedaUsuario.Items.Insert(0, new ListItem("*Buscar Por:", string.Empty));
            }
        }

        protected void lkbUsuarioAgregar_Click(object sender, EventArgs e)
        {
            sComposUsuario();
            limpiaRegistroUsuario();
            gvUsuarios.Visible = false;
            btnControlUsuario.Enabled = true;
            divDatosUsuario.Visible = true;
            divBuscaUsuario.Visible = false;
            upUsuario.Update();
        }

        protected void lkbUsuarioEdita_Click(object sender, EventArgs e)
        {
            divDatosUsuario.Visible = false;
            divBuscaUsuario.Visible = true;
            iUsuarioBuscar.Text = string.Empty;
            SControlUsurio();
            FiltroUP = "pnl_usr";
        }

        protected void sBusquedaUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            BusquedaUsuarioID = int.Parse(sBusquedaUsuario.SelectedValue);
            iUsuarioBuscar.Text = string.Empty;
        }

        protected void lkbUsuarioBuscar_Click(object sender, EventArgs e)
        {
            divDatosUsuario.Visible = false;
            gvUsuarios.Visible = false;
            string strCodigoUsuario = iUsuarioBuscar.Text;
            usr_ID = (Guid)(Session["UsuarioFirmadoID"]);

            if (sBusquedaUsuario.SelectedIndex != 0)
            {
                DataSet ListUsuarios = ControlUsuarios.FiltroUsuarios(strCodigoUsuario, usr_ID);

                gvUsuarios.DataSource = ListUsuarios;
                gvUsuarios.DataBind();
                gvUsuarios.Visible = true;
            }
            else
            {
                Mensaje("Seleccionar tipo de búsqueda");
            }
        }

        #endregion BusquedaDeUsuarios

        #region TablaUsuarios

        protected void gvUsuarios_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Guid usr_ID = Guid.Parse(e.Row.Cells[0].Text);
                int intEstatusRegistroID;

                using (IntelimundoERPEntities mEstatusUsuario = new IntelimundoERPEntities())
                {
                    var iEstatusUsuario = (from md_usr in mEstatusUsuario.tblUsuarios
                                           where md_usr.UsuarioID == usr_ID
                                           select new
                                           {
                                               md_usr.EstatusRegistroID,
                                           }).FirstOrDefault();

                    intEstatusRegistroID = int.Parse(iEstatusUsuario.EstatusRegistroID.ToString());

                    DropDownList ddl_est = (e.Row.FindControl("ddlEstatusUsuarioID") as DropDownList);

                    var tbl_sepomex = (from c in mEstatusUsuario.catEstatusRegistro
                                       select c).ToList();

                    ddl_est.DataSource = tbl_sepomex;

                    ddl_est.DataTextField = "EstatusRegistro";
                    ddl_est.DataValueField = "EstatusRegistroID";
                    ddl_est.DataBind();
                    ddl_est.Items.Insert(0, new ListItem("Seleccionar", "0"));
                    ddl_est.SelectedValue = intEstatusRegistroID.ToString();
                }
            }
        }

        protected void gvUsuarios_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow gvr = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
            Guid UsuarioFilradoID;
            UsuarioFilradoID = Guid.Parse(gvr.Cells[0].Text.ToString().Trim());

            if (e.CommandName == "cnInformacionUsuario")
            {
                try
                {
                    DataSet ListUsuarios = ControlUsuarios.FiltroUsuario(UsuarioFilradoID);

                    gvUsuarios.DataSource = ListUsuarios;
                    gvUsuarios.DataBind();
                    gvUsuarios.Visible = true;

                    DataSet informacionUsuarios = ControlUsuarios.InformacionUsuario(UsuarioFilradoID);

                    sComposUsuario();

                    sAreaUsuario.SelectedValue = informacionUsuarios.Tables[0].Rows[0].ItemArray[0].ToString();

                    int iAreaUusarios = int.Parse(informacionUsuarios.Tables[0].Rows[0].ItemArray[0].ToString());

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

                        sPerfilUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[3].ToString();
                    }

                    sGeneroUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[4].ToString();
                    DateTime f_nac = DateTime.MinValue;

                    f_nac = Convert.ToDateTime(informacionUsuarios.Tables[0].Rows[0].ItemArray[2].ToString());
                    iNacimientoUsuario.Value = f_nac.ToString("yyyy-MM-dd");

                    DateTime f_ing = Convert.ToDateTime(informacionUsuarios.Tables[0].Rows[0].ItemArray[2].ToString());

                    iNombresUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[5].ToString();
                    iApaternoUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[6].ToString();
                    iAmaternoUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[7].ToString();

                    iUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[8].ToString();
                    iEmailPersonalUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[10].ToString();
                    iEmailCorporativoUsuario.Value = informacionUsuarios.Tables[0].Rows[0].ItemArray[11].ToString();
                    btnControlUsuario.Enabled = false;
                    btnUsuarioG.Visible = false;
                    iClave.Attributes.Remove("disabled");
                    divDatosUsuario.Visible = true;
                }
                catch
                {
                    limpiaRegistroUsuario();
                    divDatosUsuario.Visible = true;
                    Mensaje("Usuario no encontrado.");
                }
            }
            else if (e.CommandName == "cnInformacionUsuarioG")
            {
                if (divDatosUsuario.Visible == false)
                {
                    Mensaje("Favor de cargar datos.");
                }
                else
                {
                    string striNombreUsuario = Request.Form["iNombresUsuario"];
                    string striApaternoUsuario = Request.Form["iApaternoUsuario"];
                    string striAmaternoUsuario = Request.Form["iAmaternoUsuario"];
                    int sGeneroUsuario = int.Parse(Request.Form["sGeneroUsuario"]);
                    DateTime iNacimientoUsuario = DateTime.Parse(Request.Form["iNacimientoUsuario"]);
                    int sPerfilUsuario = int.Parse(Request.Form["sPerfilUsuario"]);
                    string striEmailPersonalUsuario = Request.Form["iEmailPersonalUsuario"];
                    string strClave = Request.Form["iClave"];
                    string striEmailCorporativoUsuario = Request.Form["iEmailCorporativoUsuario"];
                    int iEstatusUsuario = 0;

                    foreach (GridViewRow row in gvUsuarios.Rows)
                    {
                        if (row.RowType == DataControlRowType.DataRow)
                        {
                            DropDownList dl = (DropDownList)row.FindControl("ddlEstatusUsuarioID");

                            iEstatusUsuario = int.Parse(dl.SelectedValue);
                        }
                    }

                    Guid UsuarioID = (Guid)(Session["UsuarioFirmadoID"]);
                    if (ControlUsuarios.EditaUsuario(UsuarioFilradoID, sPerfilUsuario, sGeneroUsuario, iNacimientoUsuario, striNombreUsuario, striApaternoUsuario, striAmaternoUsuario, strClave, striEmailPersonalUsuario, striEmailCorporativoUsuario, iEstatusUsuario))

                    {
                        limpiaRegistroUsuario();
                        Mensaje("Datos actualizados con éxito, favor de revisar su correo donde se le enviaran las credenciales de acceso, revisar su bandeja de spam");
                    }
                    else
                    {
                        Mensaje("Error.");
                    }
                }
            }
        }

        #endregion TablaUsuarios

        #endregion ControlUsuarios

        #region Configuracion

        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }

        protected void lkbConfiguracion_Click(object sender, EventArgs e)
        {
            navbreadcrumb.Visible = true;
            breadcrumbN1.Text = "Configuración";
            breadcrumbN2.Text = string.Empty;
            breadcrumbN3.Text = string.Empty;

            upbreadcrumb.Update();

            cardUsuario.Visible = false;
            upUsuario.Update();
            cardCentro.Visible = false;
            upCentro.Update();

            cardConfiguracion.Visible = true;
            upConfiguracion.Update();
        }

        protected void btnCodigoPostalFiscalC_Click(object sender, EventArgs e)
        {
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
                    iNombreDirector.Value = iDirector[0].Nombres;
                    iApaternoDirector.Value = iDirector[0].Apaterno;
                    iAmaternoDirector.Value = iDirector[0].Amaterno;
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

        protected void lkbNotif_Click(object sender, EventArgs e)
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

        protected void lkbAgregarUsuario_Click(object sender, EventArgs e)
        {
        }

        protected void lkbNotificaciones_Click(object sender, EventArgs e)
        {
            navbreadcrumb.Visible = true;
            breadcrumbN1.Text = "Configuración";
            breadcrumbN2.Text = "Notificación";

            upbreadcrumb.Update();
            upRegistroInicial.Visible = false;
            upNotificaciones.Visible = true;
            upRegistroInicial.Update();
            upNotificaciones.Update();
        }

        protected void lkbCatalogos_Click(object sender, EventArgs e)
        {
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

        protected void lkbRegistroInicial_Click(object sender, EventArgs e)
        {
            limpiaRegistroInicial();
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
                    navbreadcrumb.Visible = true;
                    breadcrumbN1.Text = "Configuración";
                    breadcrumbN2.Text = "Registro Inicial";
                    upbreadcrumb.Update();
                    SConfiguracion();
                    upRegistroInicial.Visible = true;
                    upNotificaciones.Visible = false;
                    upRegistroInicial.Update();
                    upNotificaciones.Update();
                }
            }
        }

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

        protected void btnRegistroInicialG_Click(object sender, EventArgs e)
        {
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

            ControlEmpresa.AltaEmpresa(striNombreEmpresa, sTipoRFCEmpresa, striRFCEmpresa, striEmailEmpresa, striTelefonoEmpresa, striCalleNumeroEmpresa, striCodigoPostalEmpresa, sColoniaEmpresa);
            ControlUsuarios.AltaUsuario(2, 2, 1, DateTime.Now, striNombreDirector, striApaternoDirector, striAmaternoDirector, striEmailEmpresa, striEmailCorporativo);

            if (ControlCorporativo.AltaCorporativo(striNombreCorporativo, striEmailCorporativo, striTelefonoCorporativo, striCalleNumeroCorporativo, striCodigoPostalCorporativo, sColoniaCorporativo))

            {
                limpiaRegistroInicial();
                Mensaje("Datos guardados con éxito, favor de revisar su correo donde se le enviaran las credenciales de acceso, revisar su bandeja de spam");
            }
            else
            {
                Mensaje("Error.");
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

        protected void lkbRegistroInicialL_Click(object sender, EventArgs e)
        {
            limpiaRegistroInicial();
        }

        protected void btnNotificacionG_Click(object sender, EventArgs e)
        {
            string iEmail = Request.Form["i_email"];
            string iUsuario = Request.Form["i_email_usr"];
            string iClave = Request.Form["i_email_clave"];
            string iAsunto = Request.Form["i_asunto"];
            string iSMTP = Request.Form["i_smtp"];
            int iPuerto = int.Parse(Request.Form["i_puerto"]);

            if (EnviarCorreo.AltaNotificacion(iEmail, iUsuario, iClave, iAsunto, iSMTP, iPuerto))
            {
                LimpiaNotificacion();
                Mensaje("Datos guardados con éxito");
            }
            else
            {
                Mensaje("Err.");
            }
        }

        protected void lkbNotificacionL_Click(object sender, EventArgs e)
        {
            LimpiaNotificacion();
        }

        #endregion Configuracion

        private void Mensaje(string contenido)
        {
            lblModalTitle.Text = "Intelimundo";
            lblModalBody.Text = contenido;
            ScriptManager.RegisterStartupScript(Page, Page.GetType(), "myModal", "$('#myModal').modal();", true);
            upModal.Update();
        }
    }
}