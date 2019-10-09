<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PanelDeControl.aspx.cs" Inherits="IntelimundoERP.PanelDeControl" %>

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
                            <img class="img-responsive img-circle" src="https://raw.githubusercontent.com/azouaoui-med/pro-sidebar-template/gh-pages/src/img/user.jpg" alt="User picture" />
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
                    <div class="sidebar-search">
                        <div>
                            <div class="input-group">
                                <input type="text" class="form-control search-menu" placeholder="Buscar..." />
                                <div class="input-group-append">
                                    <span class="input-group-text">
                                        <i class="fa fa-search" aria-hidden="true"></i>
                                    </span>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="sidebar-menu">
                        <ul>
                            <li class="header-menu">
                                <span>General</span>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="fa fa fa-tachometer-alt"></i>
                                    <span>Resumen</span>
                                </a>

                            </li>
                            <li class="header-menu">
                                <span>Control</span>
                            </li>
                            <li>
                                <asp:LinkButton CssClass="buttonClass" ID="LinkButton6" runat="server">
                                    <i class="fa fa-cog" runat="server" id="i3"></i>
                                    <span>Entradas
                                    </span>
                                </asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton CssClass="buttonClass" ID="LinkButton7" runat="server">
                                    <i class="fa fa-cog" runat="server" id="i7"></i>
                                    <span>Salidas
                                    </span>
                                </asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton CssClass="buttonClass" ID="LinkButton5" runat="server">
                                    <i class="fa fa-cog" runat="server" id="i5"></i>
                                    <span>Pendientes
                                    </span>
                                </asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton CssClass="buttonClass" ID="LinkButton4" runat="server">
                                    <i class="fa fa-cog" runat="server" id="i9"></i>
                                    <span>Servicios
                                    </span>
                                </asp:LinkButton>
                            </li>
                            <li>
                                <asp:LinkButton CssClass="buttonClass" ID="LinkButton3" runat="server">
                                    <i class="fa fa-cog" runat="server" id="i4"></i>
                                    <span>Proveedores
                                    </span>
                                </asp:LinkButton>
                            </li>
                            <asp:UpdatePanel ID="upControlCentros" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li>
                                        <asp:LinkButton CssClass="buttonClass" ID="lkbControlCentros" runat="server" OnClick="lkbControlCentros_Click">
                                            <i class="fa fa-cog" runat="server" id="iControlCentros"></i>
                                            <span>Centros
                                            </span>
                                        </asp:LinkButton>
                                    </li>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lkbControlCentros" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>

                            <asp:UpdatePanel ID="upControlUsuarios" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <li>

                                        <asp:LinkButton CssClass="buttonClass" ID="lkbControlUsuarios" runat="server" OnClick="lkbControlUsuarios_Click">
                                            <i class="fa fa-cog" runat="server" id="iControlUsuarios"></i>
                                            <span>Usuarios
                                            </span>
                                        </asp:LinkButton>


                                    </li>
                                </ContentTemplate>
                                <Triggers>
                                    <asp:AsyncPostBackTrigger ControlID="lkbControlUsuarios" EventName="Click" />
                                </Triggers>
                            </asp:UpdatePanel>
                            <li class="header-menu">
                                <span>Extra</span>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="fa fa-book"></i>
                                    <span>Material</span>
                                </a>
                            </li>
                            <li>
                                <a href="#">
                                    <i class="fa fa-calendar"></i>
                                    <span>Calendario</span>
                                    <i class="fa fa-circle bordeicono" runat="server" id="i6" style="color: #bf474e"></i>
                                </a>
                            </li>
                        </ul>
                    </div>
                </div>
                <div class="sidebar-footer">
                    <a href="#">
                        <i class="fa fa-bell"></i>
                        <span class="badge badge-pill badge-danger notification">0</span>
                    </a>
                    <a href="#">
                        <i class="fa fa-envelope"></i>
                        <span class="badge badge-pill badge-danger notification">0</span>
                    </a>
                    <a href="#">
                        <asp:LinkButton ID="LinkButton2" runat="server" OnClick="lkbConfiguracion_Click">
                        <i class="fa fa-cog"></i>
                        </asp:LinkButton>
                    </a>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <h6 class="text-right">
                                <asp:Timer ID="Timer1" runat="server" Interval="1000"></asp:Timer>
                                <asp:Label ID="lbl_reloj" runat="server" Text="" Font-Size="X-Small" Style="color: lightgray"></asp:Label>
                            </h6>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    <a href="#">
                        <asp:UpdatePanel ID="UpdatePanel2" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:LinkButton ID="lkb_salir" runat="server" OnClick="lkb_salir_Click">
                                <i class="fa fa-power-off"></i>
                                </asp:LinkButton>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </a>
                </div>
            </nav>
            <!-- sidebar-wrapper  -->
            <main class="page-content">
                <div class="container-fluid">
                    <div class="row">
                        <div class="form-group col-md-12">
                            <asp:UpdatePanel ID="upCentro" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="card border-primary" runat="server" id="cardCentro" visible="false">
                                        <div class="card-header bg-primary">
                                            <div class="text-right">
                                                <div class="input-group">
                                                    <asp:LinkButton ID="lkbCentroAgregar" CssClass="btn" runat="server" TabIndex="1">
                                                                    <i class="fas fa-plus  text-danger fa-lg"></i>
                                                    </asp:LinkButton>
                                                    <asp:TextBox CssClass="form-control" ID="iCentroBuscar" runat="server" placeholder="Buscar Centro" TextMode="Search" TabIndex="2"></asp:TextBox>

                                                    <ajaxToolkit:AutoCompleteExtender ID="aceCentroBuscar" runat="server" ServiceMethod="busca_pnl" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="iCentroBuscar" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lkbCentroBuscar" runat="server" CssClass="btn btn-danger form-control" TabIndex="3">
                                                                    <i class="fas fa-search"></i>
                                                        </asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>

                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <asp:GridView CssClass="table table-sm" ID="gvCentro" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" TabIndex="4" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
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
                                            <div class="col-md-12">
                                                <h5 class="text-right">

                                                    <asp:LinkButton CssClass="nav-item nav-link active" ID="lkbEditaCentro" runat="server">Editar <i class="fas fa-sync-alt" style="color: orangered" onmouseover="this.style.color='green'"></i></asp:LinkButton>
                                                </h5>
                                                <h5>Datos de Centro  </h5>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iNombreCentro" required="required" placeholder="*Nombre(s)" tabindex="1" onkeyup="this.value = this.value.toUpperCase();" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iApaternoCentro" required="required" placeholder="*Apellido Paterno" tabindex="2" onkeyup="this.value = this.value.toUpperCase();" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iAmaternoCentro" required="required" placeholder="*Apellido Materno" tabindex="3" onkeyup="this.value = this.value.toUpperCase();" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <hr />

                                                <h5>Datos de Centro</h5>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class=" form-group">
                                                            <input type="text" class="form-control" runat="server" id="Text1" required="required" placeholder="*Nombre Centro" tabindex="15" onkeyup="this.value = this.value.toUpperCase();" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <input type="email" class="form-control" runat="server" id="iEmailCentro" required="required" placeholder="*Email" tabindex="16" onkeyup="this.value = this.value.toLowerCase();" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-3">
                                                        <div class="form-group">
                                                            <input type="tel" class="form-control" runat="server" id="iTelefonoCentro" placeholder="Teléfono (Opcional)" tabindex="17" maxlength="10" onkeypress="return SoloNumeros(event);" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iCalleNumeroCentro" placeholder="*Calle y Número" required="required" tabindex="18" onkeyup="this.value = this.value.toUpperCase();" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="input-group">
                                                            <input type="text" class="form-control" runat="server" id="iCodigopostalCentro" placeholder="*Código Postal" required="required" tabindex="19" />
                                                            <span class="input-group-btn">
                                                                <asp:LinkButton CssClass="btn btn-danger form-control" ID="btnCodigopostalCentro" runat="server" TabIndex="20">
                                                                    <i class="fa fa-search"></i>
                                                                </asp:LinkButton>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <select class="form-control" runat="server" id="sColoniaCentro" tabindex="21">
                                                            </select>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iMunicipioCentro" placeholder="Municipio" disabled="disabled" tabindex="22" />
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class="form-group">
                                                            <input type="text" class="form-control" runat="server" id="iEstadoCentro" placeholder="Estado" disabled="disabled" tabindex="23" />
                                                        </div>
                                                    </div>
                                                </div>
                                                <asp:Button CssClass="btn btn-danger" aling="right" ID="btnCentroGuardar" runat="server" Text="Guardar" TabIndex="24" />
                                                <asp:LinkButton CssClass="btn btn-danger" aling="right" ID="lkbLimpiaDatosCentro" runat="server" TabIndex="25">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upUsuario" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <div class="card " runat="server" id="cardUsuario" visible="false">
                                        <div class="card-header ">
                                            <div class="text-right">

                                                <div class="input-group">

                                                    <asp:LinkButton ID="lkbAgregarUsuario" CssClass="btn" runat="server" TabIndex="1" OnClick="lkbAgregarUsuario_Click">
                                                                    <i class="fas fa-plus  text-danger fa-lg"></i>
                                                    </asp:LinkButton>
                                                    <asp:TextBox CssClass="form-control" ID="iBuscaUsuario" runat="server" placeholder="Buscar Usuario" TextMode="Search" TabIndex="3"></asp:TextBox>

                                                    <ajaxToolkit:AutoCompleteExtender ID="aceBuscaUsuario" runat="server" ServiceMethod="busca_pnl" MinimumPrefixLength="2" CompletionInterval="100" EnableCaching="true" CompletionSetCount="10" TargetControlID="iBuscaUsuario" FirstRowSelected="false"></ajaxToolkit:AutoCompleteExtender>
                                                    <span class="input-group-btn">
                                                        <asp:LinkButton ID="lkbBuscaUsuario" runat="server" CssClass="btn btn-danger form-control" TabIndex="4" OnClick="lkbBuscaUsuario_Click">
                                                                    <i class="fas fa-search"></i>
                                                        </asp:LinkButton>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="card-body">
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <asp:GridView CssClass="table table-sm" ID="gvUsuarios" runat="server" AutoGenerateColumns="False" AllowPaging="True" CellPadding="3" ForeColor="Black" GridLines="Vertical" TabIndex="5" PageSize="5" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px">
                                                        <AlternatingRowStyle BackColor="#CCCCCC" />
                                                        <Columns>
                                                            <asp:BoundField DataField="UsuarioID" HeaderText="ID" SortExpression="UsuarioID" Visible="true" HeaderStyle-CssClass="hideGridColumn" ItemStyle-CssClass="hideGridColumn">
                                                                <HeaderStyle CssClass="hideGridColumn"></HeaderStyle>

                                                                <ItemStyle CssClass="hideGridColumn"></ItemStyle>
                                                            </asp:BoundField>
                                                            <asp:BoundField DataField="Usuario" HeaderText="ID" SortExpression="Usuario" Visible="true" />
                                                            <asp:BoundField DataField="nom_comp" HeaderText="NOMBRE COMPLETO" SortExpression="nom_comp" />
                                                            <asp:BoundField DataField="FechaRegistro" HeaderText="REGISTRO" SortExpression="FechaRegistro" DataFormatString="{0:dd-MM-yyyy}" HtmlEncode="false" />
                                                            <asp:TemplateField HeaderText="ESTATUS">
                                                                <ItemTemplate>
                                                                    <asp:DropDownList ID="ddl_usr_estatus" runat="server" AutoPostBack="true">
                                                                    </asp:DropDownList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>

                                                            <asp:TemplateField HeaderText="" HeaderImageUrl="~/img/ico_ve.png">
                                                                <ItemTemplate>
                                                                    <asp:Button CssClass="btn btn-warning" ID="btn_infusr" runat="server" Text="Ir" CommandName="btn_usr_ve" />
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="PERFIL">
                                                                <ItemTemplate>
                                                                    <asp:Button CssClass="btn btn-warning" ID="btn_usrp" runat="server" Text="Ir" CommandName="btn_usrp" />
                                                                </ItemTemplate>
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
                                            <div runat="server" id="divDatosUsuario" visible="false">
                                                <div class="row">
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <asp:DropDownList CssClass="form-control input-box" ID="sAreaUsuario" runat="server" TabIndex="5" required="required" AutoPostBack="true" OnSelectedIndexChanged="sAreaUsuario_SelectedIndexChanged"></asp:DropDownList>
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
                                                            <select class="form-control" runat="server" id="SGeneroUsuario" tabindex="8" required="required">
                                                            </select>
                                                        </div>

                                                    </div>
                                                    <div class="form-group col-md-2">
                                                        <input type="date" class="form-control" runat="server" id="iNacimientoUsuario" required="required" placeholder="Fecha de Nacimiento" tabindex="12" value="null" />
                                                    </div>
                                                </div>

                                                <div class="row">
                                                    <div class="form-group col-md-4">
                                                        <input type="text" class="form-control" runat="server" id="iNombresUsuario" required="required" placeholder="Nombre(s)" tabindex="9" />
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <input type="text" class="form-control" runat="server" id="iApaternoUsuario" required="required" placeholder="Apellido Paterno" tabindex="10" />
                                                    </div>
                                                    <div class="form-group col-md-4">
                                                        <input type="text" class="form-control" runat="server" id="iAmaternoUsuario" required="required" placeholder="Apellido Materno" tabindex="11" />
                                                    </div>
                                                </div>
                                                <div class="row">


                                                    <div class="form-group col-md-3">
                                                        <input type="email" class="form-control" runat="server" id="iEmailPersonalUsuario" placeholder="Correo Personal" tabindex="13" />
                                                    </div>
                                                    <div class="form-group col-md-2">
                                                        <asp:Button CssClass="btn btn-danger form-control" ID="btnControlUsuario" runat="server" Text="Generar datos de control" TabIndex="14" OnClick="btnControlUsuario_Click" />
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
                                                <asp:Button CssClass="btn btn-danger" ID="btnGuardaUsuario" runat="server" Text="Guardar" TabIndex="18" Enabled="false" OnClick="btnGuardaUsuario_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </ContentTemplate>
                                <Triggers>
                                </Triggers>
                            </asp:UpdatePanel>
                            <asp:UpdatePanel ID="upConfiguracion" runat="server" UpdateMode="Conditional" Visible="false">
                                <ContentTemplate>
                                    <div class="card">
                                        <div class="card-header">
                                            <ul class="nav nav-tabs card-header-tabs">
                                                <li class="nav-item">
                                                    <asp:LinkButton CssClass="nav-item nav-link" ID="lkbNotificaciones" runat="server" OnClick="lkbNotificaciones_Click">Notificaciones <i class="fas fa-tasks" style="color: orangered"></i></asp:LinkButton>
                                                </li>
                                                <li class="nav-item">
                                                    <asp:LinkButton CssClass="nav-item nav-link" ID="lkbCatalogos" runat="server" OnClick="lkbCatalogos_Click">Catálogos <i class="fas fa-tasks" style="color: orangered"></i></asp:LinkButton>
                                                </li>
                                                <li class="nav-item">
                                                    <asp:LinkButton CssClass="nav-item nav-link" ID="lkbRegistroInicial" runat="server" OnClick="lkbRegistroInicial_Click">Registro Inicial <i class="fas fa-tasks" style="color: orangered"></i></asp:LinkButton>
                                                </li>
                                            </ul>
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
                                                                        <asp:LinkButton CssClass="btn btn-danger form-control" ID="btnCodigoPostalEmpresa" runat="server" TabIndex="11" OnClick="btnCodigoPostalEmpresa_Click">
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
                                                                        <asp:LinkButton CssClass="btn btn-danger form-control" ID="btnCodigopostalCorporativo" runat="server" TabIndex="20" OnClick="btnCodigopostalCorporativo_Click">
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
                                                        <asp:Button CssClass="btn btn-danger" aling="right" ID="btnGuardaRegistro" runat="server" Text="Guardar" TabIndex="24" OnClick="btnGuarda_Click" />
                                                        <asp:LinkButton CssClass="btn btn-danger" aling="right" ID="btnLimpiaRegistro" runat="server" TabIndex="25" OnClick="btnLimpiaRegistro_Click">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
                                                    </div>
                                                </ContentTemplate>
                                                <Triggers>
                                                </Triggers>
                                            </asp:UpdatePanel>
                                            <asp:UpdatePanel ID="upNotificaciones" runat="server" UpdateMode="Conditional" Visible="false">
                                                <ContentTemplate>
                                                    <div class="col-md-12">
                                                        <h5 class="text-right">

                                                            <asp:LinkButton CssClass="nav-item nav-link active" ID="lkbNotif" runat="server" OnClick="lkbNoti_Click">Editar <i class="fas fa-sync-alt" style="color: orangered" ></i></asp:LinkButton>
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
                                                        <asp:Button CssClass="btn btn-danger" aling="right" ID="btnNotificacion" runat="server" Text="Guardar" TabIndex="7" OnClick="btnNotificacion_Click" />
                                                        <asp:LinkButton CssClass="btn btn-danger" aling="right" ID="btnLimpiaNotificacion" runat="server" TabIndex="8" OnClick="btnLimpiaNotificacion_Click">Limpiar <i class="fas fa-recycle" style="color: white"></i></asp:LinkButton>
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
                </div>
            </main>
            <!-- page-content" -->
        </div>
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
    <!-- page-wrapper -->
    <script src="https://cdnjs.cloudflare.com/ajax/libs/jquery/3.3.1/jquery.min.js"></script>
    <script src="https://cdnjs.cloudflare.com/ajax/libs/popper.js/1.12.9/umd/popper.min.js" integrity="sha384-ApNbgh9B+Y1QKtv3Rn7W3mgPxhU9K/ScQsAP7hUibX39j7fakFPskvXusvfa0b4Q"
        crossorigin="anonymous"></script>
    <script src="https://maxcdn.bootstrapcdn.com/bootstrap/4.0.0/js/bootstrap.min.js" integrity="sha384-JZR6Spejh4U02d8jOt6vLEHfe/JQGiRRSQQxSfFWpi1MquVdAyjUar5+76PVCmYl"
        crossorigin="anonymous"></script>
</body>
</html>
