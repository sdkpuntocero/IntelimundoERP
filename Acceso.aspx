<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Acceso.aspx.cs" Inherits="IntelimundoERP.Acceso" %>

<!DOCTYPE html>



<html lang="es-MX">
<head>
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1" />

    <link rel="shortcut icon" href="Img/img.svg" type="image/png" />
    <title>\ Acceso</title>

    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Estilos/acceso.css" rel="stylesheet" />

    <script src="Scripts/jquery-3.4.1.min.js"></script>
    <script src="Scripts/popper.min.js"></script>
    <script src="Scripts/bootstrap.min.js"></script>

</head>
<body>
    <div class="login-form">

        <form runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div class="text-center">

                <img class="img-responsive" src="Imagenes/nophoto.svg" width="128" />
            </div>
            <hr />
            <br />

            <div class="form-group">
                <input type="text" class="form-control" runat="server" id="i_usuario" required="required" autocomplete="on" placeholder="Ingrese a su cuenta" tabindex="1" />
            </div>
            <br />

            <div class="form-group">
                <input type="password" class="form-control" runat="server" id="i_clave" required="required" autocomplete="off" placeholder="Contraseña" tabindex="2" />
                <br />
            </div>

            <div class="form-group text-right">
                <asp:LinkButton ID="lkb_registro_inicial" runat="server" CssClass="text-info" TabIndex="4" Visible="false" Text="Registro Inicial">
                </asp:LinkButton>
            </div>
            <asp:Button CssClass="btn btn-primary btn-block btn-lg" ID="btn_acceso" runat="server" Text="Iniciar sesión" TabIndex="3" OnClick="btn_acceso_Click" />
            <div class="text-right small">
                <br />
                ¿No tienes una cuenta?
                <br />
                Contactar al Dpto. de Recursos Humanos
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
                                    <button type="button" class="btn btn-primary" data-dismiss="modal">Aceptar</button>
                                </div>
                            </div>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </div>
            </div>
        </form>
    </div>
</body>
</html>
