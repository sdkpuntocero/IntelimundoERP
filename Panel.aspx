<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Panel.aspx.cs" Inherits="IntelimundoERP.Panel" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml" lang="es-mx">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

    <link href="Content/fontawesome-free-5.9.0-web/css/all.css" rel="stylesheet" />
    <link href="Estilos/Panel.css" rel="stylesheet" />
    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

    <title>IM</title>
</head>

<body>
    <script>
        jQuery(function ($) {

            $(".sidebar-dropdown > a").click(function () {
                $(".sidebar-submenu").slideUp(200);
                if (
                    $(this)
                        .parent()
                        .hasClass("active")
                ) {
                    $(".sidebar-dropdown").removeClass("active");
                    $(this)
                        .parent()
                        .removeClass("active");
                } else {
                    $(".sidebar-dropdown").removeClass("active");
                    $(this)
                        .next(".sidebar-submenu")
                        .slideDown(200);
                    $(this)
                        .parent()
                        .addClass("active");
                }
            });

            $("#close-sidebar").click(function () {
                $(".page-wrapper").removeClass("toggled");
            });
            $("#show-sidebar").click(function () {
                $(".page-wrapper").addClass("toggled");
            });

        });

    </script>

    <form runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div class="page-wrapper chiller-theme toggled">
            <a id="show-sidebar" class="btn btn-sm btn-dark" href="#">
                <i class="fas fa-bars"></i>
            </a>
            <nav id="sidebar" class="sidebar-wrapper">
                <div class="sidebar-content">
                    <div class="sidebar-brand">
                        <a href="#">Intelimundo</a>
                        <div id="close-sidebar">
                            <i class="fas fa-times"></i>
                        </div>
                    </div>
                    <div class="sidebar-header">
                        <div class="user-pic">
                            <img class="img-responsive img-rounded" src="https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg"
                                alt="User picture" />
                        </div>
                        <div class="user-info">
                            <span class="user-name">
                                <asp:Label ID="lblNombreUsuario" runat="server" Text=""></asp:Label>
                                <strong>

                                    <asp:Label ID="lblNombreApellidos" runat="server" Text=""></asp:Label>
                                </strong>
                            </span>
                            <span class="user-role">
                                <asp:Label ID="lblCorporativo" runat="server" Text="" Font-Size="Smaller"></asp:Label></span>
                            <span class="user-role">
                                <asp:Label ID="lblOperadora" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                            </span>
                            <span class="user-status">

                                <i class="fa fa-circle" runat="server" id="i_EstatusUsuario" style="color: #bf474e"></i>
                                <span>
                                    <asp:Label ID="lbl_EstatusUsuario" runat="server" Text="" Font-Size="Smaller"></asp:Label>
                                </span>
                            </span>
                        </div>
                    </div>
                    <!-- sidebar-header  -->
                    <div class="sidebar-search">
                        <div>
                            <div class="input-group">
                                <input type="text" class="form-control search-menu" placeholder="Search..." />
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="fa fa-search" aria-hidden="true"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- sidebar-search  -->
                    <div class="sidebar-menu">
                        <ul>
                            <li class="header-menu">
                                <span>General</span>
                            </li>
                            <li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="fa fa-tachometer-alt"></i>
                                    <span>Dashboard</span>
                                    <span class="badge badge-pill badge-warning">0</span>
                                </a>
                                <div class="sidebar-submenu">
                                    <ul>
                                        <li>
                                            <a href="#">Dashboard 1

                                            <span class="badge badge-pill badge-success">Pro</span>
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">Dashboard 2</a>
                                        </li>
                                        <li>
                                            <a href="#">Dashboard 3</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="fa fa-shopping-cart"></i>
                                    <span>E-commerce</span>
                                    <span class="badge badge-pill badge-info">0</span>
                                </a>
                                <div class="sidebar-submenu">
                                    <ul>
                                        <li>
                                            <a href="#">Licencias
                                            </a>
                                        </li>
                                        <li>
                                            <a href="#">Productos</a>
                                        </li>
                                        <li>
                                            <a href="#">Servicios</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="far fa-gem"></i>
                                    <span>Gastos</span>
                                </a>
                                <div class="sidebar-submenu">
                                    <ul>
                                        <li>
                                            <a href="#">General</a>
                                        </li>
                                        <li>
                                            <a href="#">Panels</a>
                                        </li>
                                        <li>
                                            <a href="#">Tables</a>
                                        </li>
                                        <li>
                                            <a href="#">Icons</a>
                                        </li>
                                        <li>
                                            <a href="#">Forms</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="fa fa-chart-line"></i>
                                    <span>Charts</span>
                                </a>
                                <div class="sidebar-submenu">
                                    <ul>
                                        <li>
                                            <a href="#">Pie chart</a>
                                        </li>
                                        <li>
                                            <a href="#">Line chart</a>
                                        </li>
                                        <li>
                                            <a href="#">Bar chart</a>
                                        </li>
                                        <li>
                                            <a href="#">Histogram</a>
                                        </li>
                                    </ul>
                                </div>
                            </li>
                            <li class="sidebar-dropdown">
                                <a href="#">
                                    <i class="fa fa-globe"></i>
                                    <span>Control de Datos</span>
                                </a>
                                <div class="sidebar-submenu">
                                    <ul>
                                        <asp:UpdatePanel ID="upControlUsuarios" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <li>

                                                    <asp:LinkButton CssClass="buttonClass" ID="lkbControlUsuarios" runat="server" OnClick="lkbControlUsuarios_Click">

                                                        <span>Usuarios
                                                        </span>
                                                    </asp:LinkButton>
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="upControlCentros" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <li>
                                                    <asp:LinkButton CssClass="buttonClass" ID="lkbControlCentros" runat="server" OnClick="lkbControlCentros_Click">

                                                        <span>Centros
                                                        </span>
                                                    </asp:LinkButton>
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="upControlClientes" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <li>
                                                    <asp:LinkButton CssClass="buttonClass" ID="lkbControlClientes" runat="server">
                                                        <span>Clientes
                                                        </span>
                                                    </asp:LinkButton>
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="upControlProveedores" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <li>
                                                    <asp:LinkButton CssClass="buttonClass" ID="lkbControlProveedores" runat="server">
                                                        <span>Proveedores
                                                        </span>
                                                    </asp:LinkButton>
                                                </li>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </ul>
                                </div>
                            </li>
                            <li class="header-menu">
                                <span>Extras</span>
                            </li>

                            <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li>

                                        <asp:LinkButton CssClass="buttonClass" ID="LinkButton2" runat="server" >
                                            <i class="fas fa-book"></i>
                                            <span>Materiales
                                            </span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            <li>
                                <a href="#">
                                    <i class="fa fa-calendar"></i>
                                    <span>Calendar</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="fa fa-folder"></i>
                                    <span>Examples</span>
                                </a>
                            </li>
                        </ul>
                    </div>
                    <!-- sidebar-menu  -->
                </div>
                <!-- sidebar-content  -->
                <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="sidebar-footer">
                            <a href="#">
                                <i class="fa fa-bell"></i>
                                <span class="badge badge-pill badge-warning notification">0</span>
                            </a>
                            <a href="#">
                                <i class="fa fa-envelope"></i>
                                <span class="badge badge-pill badge-success notification">0</span>
                            </a>
                            <a href="#">
                                <asp:LinkButton ID="lkbConfiguracion" runat="server" OnClick="lkbConfiguracion_Click">
                        <i class="fa fa-cog"></i>
                                    <span class="badge-sonar"></span>
                                </asp:LinkButton>
                            </a>
                            <a href="#">
                                <asp:LinkButton ID="lkbSalir" runat="server" OnClick="lkbSalir_Click">
                        <i class="fa fa-power-off"></i>
                                </asp:LinkButton>
                            </a>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </nav>
            <!-- sidebar-wrapper  -->
            <main class="page-content">
                <div class="container-fluid">
                    <div class="col-md-12" runat="server">
                        <asp:UpdatePanel ID="upbreadcrumb" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <nav aria-label="breadcrumb" runat="server" id="navbreadcrumb" visible="false">
                                    <ol class="breadcrumb">
                                        <li class="breadcrumb-item">
                                            <asp:Label ID="breadcrumbN1" runat="server"></asp:Label></li>
                                        <li class="breadcrumb-item">
                                            <asp:Label ID="breadcrumbN2" runat="server"></asp:Label></li>
                                        <li class="breadcrumb-item">
                                            <asp:Label ID="breadcrumbN3" runat="server"></asp:Label></li>
                                    </ol>
                                </nav>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upCentro" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="card" runat="server" id="cardCentro" visible="false">
                                    <div class="card-header bg-secondary">

                                        <div class="input-group">
                                            <asp:LinkButton ID="lkbCentroAgregar" CssClass="btn btn-light" runat="server" TabIndex="1" OnClick="lkbCentroAgregar_Click">
                                                                    Agregar <i class="fas fa-plus text-secondary fa-lg"></i>
                                            </asp:LinkButton>
                                            &nbsp;
                                                <asp:LinkButton ID="lkbCentroEdita" CssClass="btn btn-light" runat="server" TabIndex="2" OnClick="lkbCentroEdita_Click">
                                                                    Editar <i class="fas fa-edit text-secondary fa-lg"></i>
                                                </asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="input-group" runat="server" id="divBuscaCentro" visible="false">

                                            <div class="form-group">
                                                <select class="form-control" runat="server" id="sBusquedaCentro" tabindex="3">
                                                </select>
                                            </div>

                                            <asp:TextBox CssClass="form-control" ID="iCentroBuscar" runat="server" placeholder="*Buscar" TextMode="Search" TabIndex="4"></asp:TextBox>

                                            <ajaxToolkit:AutoCompleteExtender ID="aceCentroBuscar" runat="server" ServiceMethod="busca_pnl" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="iCentroBuscar" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbCentroBuscar" runat="server" CssClass="btn btn-light  form-control" TabIndex="5">
                                                                    <i class="fas fa-search"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>

                                    <div class="card-body">
                                        <div class="row">
                                            <div class="table-responsive">
                                                <asp:GridView CssClass="table table-bordered table-condensed" ID="gvCentro" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" TabIndex="4" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                                    <Columns>
                                                        <asp:BoundField DataField="centro_ID" HeaderText="ID" SortExpression="centro_ID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                            <HeaderStyle CssClass="hideGridColumn"></HeaderStyle>

                                                            <ItemStyle CssClass="hideGridColumn"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="cod_centro" HeaderText="ID" SortExpression="cod_centro" />
                                                        <asp:BoundField DataField="licencia_desc" HeaderText="LICENCIA" SortExpression="licencia_desc" Visible="true" />
                                                        <asp:BoundField DataField="centro_nom" HeaderText="CENTRO" SortExpression="centro_nom" />

                                                        <asp:BoundField DataField="nom_gerente" HeaderText="NOMBRE GERENTE" SortExpression="nom_gerente" />

                                                        <asp:TemplateField HeaderText="ESTATUS">
                                                            <ItemTemplate>
                                                                <asp:DropDownList ID="ddl_cnt_estatus" runat="server" AutoPostBack="true">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                        <asp:BoundField DataField="registro" HeaderText="REGISTRO" SortExpression="registro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                        <asp:TemplateField HeaderText="" HeaderImageUrl="~/img/ico_ve.png" HeaderStyle-VerticalAlign="Middle" HeaderStyle-HorizontalAlign="Center">
                                                            <ItemTemplate>
                                                                <asp:Button CssClass="btn btn-warning" ID="btn_infcnt" runat="server" Text="Ir" CommandName="btn_cnt_ve" />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <HeaderStyle BackColor="#dc3545" ForeColor="White" />
                                                    <PagerSettings FirstPageText="Inicio" LastPageText="Final" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <div class="col-md-12" runat="server" id="divDatosCentro" visible="false">

                                            <h5>Datos del Director de Centro  </h5>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iNombresCentro" required="required" placeholder="*Nombre(s)" tabindex="6" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iApaternoCentro" required="required" placeholder="*Apellido Paterno" tabindex="7" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iAmaternoCentro" required="required" placeholder="*Apellido Materno" tabindex="8" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iRazonSocialFiscalC" required="required" placeholder="*Razón Social" tabindex="4" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sTipoRFCFiscalC" tabindex="5" required="required">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iRFCFiscalC" required="required" placeholder="*RFC" tabindex="6" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="email" class="form-control" runat="server" id="iEmailFiscalC" required="required" placeholder="*Email" tabindex="7" onkeyup="this.value = this.value.toLowerCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <input type="tel" class="form-control" runat="server" id="iTelefonoFiscalC" placeholder="Teléfono (Opcional)" tabindex="8" maxlength="10" onkeypress="return SoloNumeros(event);" />
                                                    </div>
                                                </div>

                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iCalleNumeroFiscalC" placeholder="*Calle y Número" required="required" tabindex="9" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control" runat="server" id="iCodigoPostalFiscalC" placeholder="*Código Postal" required="required" tabindex="10" />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton CssClass="btn btn-secondary form-control" ID="btnCodigoPostalFiscalC" runat="server" TabIndex="11" OnClick="btnCodigoPostalFiscalC_Click">
                                                                    <i class="fa fa-search"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sColoniaFiscalC" tabindex="12">
                                                        </select>
                                                    </div>
                                                </div>

                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iMunicipioFiscalC" placeholder="Municipio" disabled="disabled" tabindex="13" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iEstadoFiscalC" placeholder="Estado" disabled="disabled" tabindex="14" />
                                                    </div>
                                                </div>
                                            </div>
                                            <hr />

                                            <h5>Datos de Centro</h5>
                                            <div class="row">
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sLicenciaCentro" tabindex="9" required="required">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sTipoCentro" tabindex="10" required="required">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class=" form-group">
                                                        <input type="text" class="form-control" runat="server" id="iNombreCentro" required="required" placeholder="*Nombre Centro" tabindex="11" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="email" class="form-control" runat="server" id="iEmailCentro" required="required" placeholder="*Email" tabindex="12" onkeyup="this.value = this.value.toLowerCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <input type="tel" class="form-control" runat="server" id="iTelefonoCentro" placeholder="Teléfono (Opcional)" tabindex="13" maxlength="10" onkeypress="return SoloNumeros(event);" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iCalleNumeroCentro" placeholder="*Calle y Número" required="required" tabindex="14" onkeyup="this.value = this.value.toUpperCase();" />
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="input-group">
                                                        <input type="text" class="form-control" runat="server" id="iCodigopostalCentro" placeholder="*Código Postal" required="required" tabindex="15" />
                                                        <span class="input-group-btn">
                                                            <asp:LinkButton CssClass="btn btn-secondary form-control" ID="btnCodigopostalCentro" runat="server" TabIndex="16">
                                                                    <i class="fa fa-search"></i>
                                                            </asp:LinkButton>
                                                        </span>
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sColoniaCentro" tabindex="17">
                                                        </select>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iMunicipioCentro" placeholder="Municipio" disabled="disabled" />
                                                    </div>
                                                </div>
                                                <div class="col-md-3">
                                                    <div class="form-group">
                                                        <input type="text" class="form-control" runat="server" id="iEstadoCentro" placeholder="Estado" disabled="disabled" />
                                                    </div>
                                                </div>
                                            </div>
                                            <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnCentroGuardar" runat="server" Text="Guardar" TabIndex="18" />
                                            <asp:LinkButton CssClass="btn btn-secondary" aling="right" ID="lkbLimpiaDatosCentro" runat="server" TabIndex="19">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upUsuario" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="card" runat="server" id="cardUsuario" visible="false">
                                    <div class="card-header bg-secondary">

                                        <div class="input-group">
                                            <asp:LinkButton ID="lkbUsuarioAgregar" CssClass="btn btn-light" runat="server" TabIndex="1" OnClick="lkbUsuarioAgregar_Click">
                                                                    <i class="fas fa-user-plus text-secondary fa-lg"></i>
                                            </asp:LinkButton>
                                            &nbsp;
                                                <asp:LinkButton ID="lkbUsuarioEdita" CssClass="btn btn-light" runat="server" TabIndex="2" OnClick="lkbUsuarioEdita_Click">
                                                                    <i class="fas fa-user-edit text-secondary fa-lg"></i>
                                                </asp:LinkButton>
                                        </div>
                                        <br />
                                        <div class="input-group" runat="server" id="divBuscaUsuario" visible="false">

                                            <div class="form-group">
                                                <asp:DropDownList CssClass="form-control input-box" ID="sBusquedaUsuario" runat="server" TabIndex="3" required="required" AutoPostBack="true" OnSelectedIndexChanged="sBusquedaUsuario_SelectedIndexChanged"></asp:DropDownList>
                                            </div>

                                            <asp:TextBox CssClass="form-control" ID="iUsuarioBuscar" runat="server" placeholder="*Buscar" TextMode="Search" TabIndex="4" onkeyup="this.value = this.value.toUpperCase();" required="required"></asp:TextBox>

                                            <ajaxToolkit:AutoCompleteExtender ID="aceUsuarioBuscar" runat="server" ServiceMethod="busca_pnl" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="iUsuarioBuscar" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                            <span class="input-group-btn">
                                                <asp:LinkButton ID="lkbUsuarioBuscar" runat="server" CssClass="btn btn-light  form-control" TabIndex="5" OnClick="lkbUsuarioBuscar_Click">
                                                                    <i class="fas fa-search text-secondary fa-lg"></i>
                                                </asp:LinkButton>
                                            </span>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <div class="row">
                                            <div class="table-responsive">
                                                <asp:GridView CssClass="table table-bordered table-condensed" ID="gvUsuarios" runat="server" RowStyle-VerticalAlign="Middle" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" TabIndex="5" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" OnRowDataBound="gvUsuarios_RowDataBound" OnRowCommand="gvUsuarios_RowCommand" HeaderStyle-CssClass="GridHeader">
                                                    <AlternatingRowStyle BackColor="#CCCCCC" />
                                                    <Columns>
                                                        <asp:BoundField DataField="UsuarioID" HeaderText="ID" SortExpression="UsuarioID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                            <HeaderStyle CssClass="hideGridColumn"></HeaderStyle>

                                                            <ItemStyle CssClass="hideGridColumn"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="CodigoUsuario" HeaderText="ID" SortExpression="CodigoUsuario" Visible="true" HeaderStyle-CssClass="align-content-center">

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle" />
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="nom_comp" HeaderText="NOMBRE COMPLETO" SortExpression="nom_comp">

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:BoundField DataField="FechaRegistro" HeaderText="REGISTRO" SortExpression="FechaRegistro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false">

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:BoundField>
                                                        <asp:TemplateField HeaderText="ESTATUS">
                                                            <ItemTemplate>
                                                                <asp:DropDownList class="form-control" ID="ddlEstatusUsuarioID" runat="server">
                                                                </asp:DropDownList>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CssClass="" ID="LinkButton1" runat="server" CommandName="cnInformacionUsuario" ToolTip="Información de Usuario">
                                            <i class="fas fa-info text-secondary fa-lg"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:TemplateField>
                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CssClass="" ID="LinkButton2" runat="server" CausesValidation="false" CommandName="cnInformacionUsuarioG" ToolTip="Guarda cambios de Información de Usuario" >
                                            <i class="fas fa-save text-secondary fa-lg"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:TemplateField>

                                                        <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:LinkButton CssClass="" ID="LinkButton3" runat="server">
                                            <i class="fas fa-user-shield text-secondary fa-lg"></i>
                                                                </asp:LinkButton>
                                                            </ItemTemplate>

                                                            <ItemStyle HorizontalAlign="Center" VerticalAlign="Middle"></ItemStyle>
                                                        </asp:TemplateField>
                                                    </Columns>
                                                    <FooterStyle BackColor="#CCCCCC" />
                                                    <HeaderStyle BackColor="#dc3545" ForeColor="White" Font-Bold="false" />
                                                    <PagerSettings FirstPageText="Inicio" LastPageText="Final" />
                                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                                    <SelectedRowStyle BackColor="#000099" ForeColor="White" />
                                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                                </asp:GridView>
                                            </div>
                                        </div>
                                        <br />
                                        <div runat="server" id="divDatosUsuario" visible="false">
                                            <div class="row">
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <asp:DropDownList CssClass="form-control input-box" ID="sAreaUsuario" runat="server" TabIndex="6" required="required" AutoPostBack="true" OnSelectedIndexChanged="sAreaUsuario_SelectedIndexChanged"></asp:DropDownList>
                                                    </div>
                                                </div>
                                                <div class="col-md-4">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sPerfilUsuario" tabindex="7" required="required">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="col-md-2">
                                                    <div class="form-group">
                                                        <select class="form-control" runat="server" id="sGeneroUsuario" tabindex="8" required="required">
                                                        </select>
                                                    </div>
                                                </div>
                                                <div class="form-group col-md-2">
                                                    <input type="date" class="form-control" runat="server" id="iNacimientoUsuario" required="required" placeholder="Fecha de Nacimiento" tabindex="9" value="null" />
                                                </div>
                                            </div>

                                            <div class="row">
                                                <div class="form-group col-md-4">
                                                    <input type="text" class="form-control" runat="server" id="iNombresUsuario" required="required" placeholder="Nombre(s)" tabindex="10" onkeyup="this.value = this.value.toUpperCase();" />
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <input type="text" class="form-control" runat="server" id="iApaternoUsuario" required="required" placeholder="Apellido Paterno" tabindex="11" onkeyup="this.value = this.value.toUpperCase();" />
                                                </div>
                                                <div class="form-group col-md-4">
                                                    <input type="text" class="form-control" runat="server" id="iAmaternoUsuario" required="required" placeholder="Apellido Materno" tabindex="12" onkeyup="this.value = this.value.toUpperCase();" />
                                                </div>
                                            </div>
                                            <div class="row">

                                                <div class="form-group col-md-3">
                                                    <input type="email" class="form-control" runat="server" id="iEmailPersonalUsuario" placeholder="Correo Personal" tabindex="13" required="required" />
                                                </div>
                                                <div class="form-group col-md-2">
                                                    <asp:Button CssClass="btn btn-secondary form-control" ID="btnControlUsuario" runat="server" Text="Generar datos de control" TabIndex="14" OnClick="btnControlUsuario_Click" />
                                                </div>
                                                <div class="form-group col-md-2">
                                                    <input type="text" class="form-control" runat="server" id="iUsuario" required="required" placeholder="Usuario" tabindex="15" disabled="disabled" />
                                                </div>

                                                <div class="form-group col-md-2">
                                                    <input type="password" class="form-control" runat="server" id="iClave" required="required" placeholder="Contraseña" tabindex="16" disabled="disabled" />
                                                </div>
                                                <div class="form-group col-md-3">
                                                    <input type="email" class="form-control" runat="server" id="iEmailCorporativoUsuario" required="required" placeholder="Correo Corporativo" tabindex="17" disabled="disabled" />
                                                </div>
                                            </div>

                                            <div class="row">
                                            </div>
                                            <asp:Button CssClass="btn btn-secondary" ID="btnUsuarioG" runat="server" Text="Guardar" TabIndex="18" Enabled="false" OnClick="btnUsuarioG_Click" />
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                        <asp:UpdatePanel ID="upConfiguracion" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <div class="card" runat="server" id="cardConfiguracion" visible="false">
                                    <div class="card-header bg-secondary">

                                        <div class="input-group">

                                            <asp:LinkButton CssClass="btn btn-light" ID="lkbNotificaciones" runat="server" OnClick="lkbNotificaciones_Click">Notificaciones <i class="far fa-envelope text-secondary fa-lg" ></i></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton CssClass="btn btn-light" ID="lkbCatalogos" runat="server" OnClick="lkbCatalogos_Click">Catálogos <i class="far fa-list-alt text-secondary fa-lg"></i></asp:LinkButton>
                                            &nbsp;
                                            <asp:LinkButton CssClass="btn btn-light" ID="lkbRegistroInicial" runat="server" OnClick="lkbRegistroInicial_Click">Registro Inicial <i class="fas fa-spell-check text-secondary fa-lg"></i></asp:LinkButton>
                                        </div>
                                    </div>
                                    <div class="card-body">
                                        <asp:UpdatePanel ID="upRegistroInicial" runat="server" UpdateMode="Conditional" Visible="false">
                                            <ContentTemplate>
                                                <div class="col-md-12">
                                                    <h5 class="text-right">

                                                        <asp:LinkButton CssClass="nav-item nav-link active" ID="lkbRegIniEdit" runat="server" OnClick="lkbRegIniEdit_Click">Editar <i class="fas fa-sync-alt" style="color: orangered" onmouseover="this.style.color='green'"></i></asp:LinkButton>
                                                    </h5>
                                                    <h5>Datos de Director  </h5>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iNombreDirector" required="required" placeholder="*Nombre(s)" tabindex="1" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iApaternoDirector" required="required" placeholder="*Apellido Paterno" tabindex="2" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iAmaternoDirector" required="required" placeholder="*Apellido Materno" tabindex="3" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <h5>Datos Empresa</h5>
                                                    <div class="row">

                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iNombreEmpresa" required="required" placeholder="*Compañia" tabindex="4" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <select class="form-control" runat="server" id="sTipoRFCEmpresa" tabindex="5" required="required">
                                                                </select>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iRFCEmpresa" required="required" placeholder="*RFC" tabindex="6" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="email" class="form-control" runat="server" id="iEmailEmpresa" required="required" placeholder="*Email" tabindex="7" onkeyup="this.value = this.value.toLowerCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="tel" class="form-control" runat="server" id="iTelefonoEmpresa" placeholder="Teléfono (Opcional)" tabindex="8" maxlength="10" onkeypress="return SoloNumeros(event);" />
                                                            </div>
                                                        </div>

                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iCalleNumeroEmpresa" placeholder="*Calle y Número" required="required" tabindex="9" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>

                                                        <div class="col-md-2">
                                                            <div class="input-group">
                                                                <input type="text" class="form-control" runat="server" id="iCodigoPostalEmpresa" placeholder="*Código Postal" required="required" tabindex="10" />
                                                                <span class="input-group-btn">
                                                                    <asp:LinkButton CssClass="btn btn-secondary form-control" ID="btnCodigoPostalEmpresa" runat="server" TabIndex="11" OnClick="btnCodigoPostalEmpresa_Click">
                                                                    <i class="fa fa-search"></i>
                                                                    </asp:LinkButton>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <select class="form-control" runat="server" id="sColoniaEmpresa" tabindex="12">
                                                                </select>
                                                            </div>
                                                        </div>

                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iMunicipioEmpresa" placeholder="Municipio" disabled="disabled" tabindex="13" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iEstadoEmpresa" placeholder="Estado" disabled="disabled" tabindex="14" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <hr />
                                                    <h5>Datos de Corporativo</h5>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class=" form-group">
                                                                <input type="text" class="form-control" runat="server" id="iNombreCorporativo" required="required" placeholder="*Nombre Corporativo" tabindex="15" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="email" class="form-control" runat="server" id="iEmailCorporativo" required="required" placeholder="*Email" tabindex="16" onkeyup="this.value = this.value.toLowerCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-3">
                                                            <div class="form-group">
                                                                <input type="tel" class="form-control" runat="server" id="iTelefonoCorporativo" placeholder="Teléfono (Opcional)" tabindex="17" maxlength="10" onkeypress="return SoloNumeros(event);" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iCalleNumeroCorporativo" placeholder="*Calle y Número" required="required" tabindex="18" onkeyup="this.value = this.value.toUpperCase();" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-2">
                                                            <div class="input-group">
                                                                <input type="text" class="form-control" runat="server" id="iCodigopostalCorporativo" placeholder="*Código Postal" required="required" tabindex="19" />
                                                                <span class="input-group-btn">
                                                                    <asp:LinkButton CssClass="btn btn-secondary form-control" ID="btnCodigopostalCorporativo" runat="server" TabIndex="20" OnClick="btnCodigopostalCorporativo_Click">
                                                                    <i class="fa fa-search"></i>
                                                                    </asp:LinkButton>
                                                                </span>
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <select class="form-control" runat="server" id="sColoniaCorporativo" tabindex="21">
                                                                </select>
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iMunicipioCorporativo" placeholder="Municipio" disabled="disabled" tabindex="22" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-6">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="iEstadoCorporativo" placeholder="Estado" disabled="disabled" tabindex="23" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnRegistroInicialG" runat="server" Text="Guardar" TabIndex="24" OnClick="btnRegistroInicialG_Click" />
                                                    <asp:LinkButton CssClass="btn btn-secondary" aling="right" ID="lkbRegistroInicialL" runat="server" TabIndex="25" OnClick="lkbRegistroInicialL_Click">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                        <asp:UpdatePanel ID="upNotificaciones" runat="server" UpdateMode="Conditional" Visible="false">
                                            <ContentTemplate>
                                                <div class="col-md-12">
                                                    <h5 class="text-right">

                                                        <asp:LinkButton CssClass="nav-item nav-link active" ID="lkbNotif" runat="server" OnClick="lkbNotif_Click">Editar <i class="fas fa-sync-alt" style="color: orangered" ></i></asp:LinkButton>
                                                    </h5>

                                                    <h5>Datos de correo electrónico para notificaciones</h5>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="email" class="form-control" runat="server" id="i_email" required="required" placeholder="e-mail" tabindex="1" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="i_email_usr" required="required" placeholder="Usuario" tabindex="2" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="password" class="form-control" runat="server" id="i_email_clave" required="required" placeholder="Contraseña" tabindex="3" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <div class="row">
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="i_asunto" required="required" placeholder="Asunto" tabindex="4" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="text" class="form-control" runat="server" id="i_smtp" required="required" placeholder="Servidor SMTP (Gmail)" tabindex="5" />
                                                            </div>
                                                        </div>
                                                        <div class="col-md-4">
                                                            <div class="form-group">
                                                                <input type="number" class="form-control" runat="server" id="i_puerto" required="required" placeholder="Puerto SMTP" tabindex="6" />
                                                            </div>
                                                        </div>
                                                    </div>
                                                    <asp:Button CssClass="btn btn-secondary" aling="right" ID="btnNotificacionG" runat="server" Text="Guardar" TabIndex="7" OnClick="btnNotificacionG_Click" />
                                                    <asp:LinkButton CssClass="btn btn-secondary" aling="right" ID="lkbNotificacionL" runat="server" TabIndex="8" OnClick="lkbNotificacionL_Click">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
                                                </div>
                                            </ContentTemplate>
                                            <Triggers>
                                            </Triggers>
                                        </asp:UpdatePanel>
                                    </div>
                                </div>
                            </ContentTemplate>
                            <Triggers>
                            </Triggers>
                        </asp:UpdatePanel>
                    </div>
                </div>
            </main>
            <!-- page-content" -->
        </div>
        <!-- page-wrapper -->
        <div class="modal" id="myModal">
            <div class="modal-dialog" role="document">
                <asp:UpdatePanel ID="upModal" runat="server" ChildrenAsTriggers="false" UpdateMode="Conditional">
                    <ContentTemplate>
                        <div class="modal-content">
                            <div class="modal-header">
                                <asp:Label ID="lblModalTitle" CssClass="modal-title" runat="server" Text=""></asp:Label>
                                <button type="button" class="close" data-dismiss="modal"><span>×</span> </button>
                            </div>
                            <div class="modal-body">
                                <asp:Label ID="lblModalBody" CssClass="login100-form-title" runat="server" Text=""></asp:Label>
                            </div>
                            <div class="modal-footer">

                                <button type="button" class="btn btn-danger" data-dismiss="modal">Aceptar</button>
                            </div>
                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </form>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>
</body>
</html>