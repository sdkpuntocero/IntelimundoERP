using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IntelimundoERP
{
    public partial class Panel : System.Web.UI.Page
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


        #region ControlCentros
        protected void lkbControlCentros_Click(object sender, EventArgs e)
        {
            breadcrumbN1.Text = "Control de Datos";
            breadcrumbN2.Text = "Centros";
            navbreadcrumb.Visible = true;
            upbreadcrumb.Update();
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
        #endregion

        protected void lkbAgregarUsuario_Click(object sender, EventArgs e)
        {
            divDatosUsuario.Visible = true;
            upUsuario.Update();
        }

        protected void lkbNotificaciones_Click(object sender, EventArgs e)
        {

        }

        protected void lkbCatalogos_Click(object sender, EventArgs e)
        {

        }

        protected void lkbRegistroInicial_Click(object sender, EventArgs e)
        {

        }

        protected void btnCodigoPostalEmpresa_Click(object sender, EventArgs e)
        {

        }

        protected void btnCodigopostalCorporativo_Click(object sender, EventArgs e)
        {

        }

        protected void btnRegistroInicialG_Click(object sender, EventArgs e)
        {

        }

        protected void lkbRegistroInicialL_Click(object sender, EventArgs e)
        {

        }

        protected void btnNotificacionG_Click(object sender, EventArgs e)
        {

        }

        protected void lkbNotificacionL_Click(object sender, EventArgs e)
        {

        }

        protected void lkbBuscaUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void sAreaUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnControlUsuario_Click(object sender, EventArgs e)
        {

        }

        protected void btnUsuarioG_Click(object sender, EventArgs e)
        {

        }

        protected void lkbRegIniEdit_Click(object sender, EventArgs e)
        {

        }

        protected void lkbNotif_Click(object sender, EventArgs e)
        {

        }

        protected void lkbControlUsuarios_Click(object sender, EventArgs e)
        {
            breadcrumbN1.Text = "Control de Datos";
            breadcrumbN2.Text = "Usuarios";
            navbreadcrumb.Visible = true;
            upbreadcrumb.Update();
            cardUsuario.Visible = true;
            upUsuario.Update();
            cardCentro.Visible = false;
            upCentro.Update();
        }


        protected void lkbSalir_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Redirect("acceso.aspx");
        }

        protected void lkbConfiguracion_Click(object sender, EventArgs e)
        {

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

        protected void lkbUsuarioEdita_Click(object sender, EventArgs e)
        {

        }

        protected void lkbUsuarioAgregar_Click(object sender, EventArgs e)
        {

        }
    }
}