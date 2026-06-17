<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign_in.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Sign_in" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        
    <meta charset="utf-8" />
<title>Inicio</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
        

    </head>

<body>
    <form id="form1" runat="server">
        <div class = "registro">
            <h1>Crear Cuenta</h1>

            <nav>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" placeholder="Nombre"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control campo" placeholder="Apellido"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control campo" placeholder="Email"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control campo" placeholder="Teléfono"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control campo" TextMode="Password" placeholder="Contraseña"> </asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control campo" TextMode="Password" placeholder="Confirmar Contraseña"> </asp:TextBox>
            </nav>

            <h2>Dirección</h2>
            <nav>
            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control campo" placeholder="Calle"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control campo" placeholder="Número"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control campo" placeholder="Localidad"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control campo" placeholder="Código Postal"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control campo" TextMode="MultiLine" Rows="3" placeholder="Observaciones"> </asp:TextBox>
            </nav>
        </div>
        <div class =" botones">
            <asp:Button
            ID="btnRegistrarse"
            runat="server"
            Text="Registrarse"
            OnClick="btnRegistrarse_Click" CssClass="btn btn-default" />

            <asp:HyperLink
            ID="lnkLogin"
            runat="server"
            NavigateUrl="~/Log_in.aspx">
            Ya tengo cuenta
            </asp:HyperLink>

            <asp:HyperLink
            ID="lnkVolverTienda"
            runat="server"
            NavigateUrl="~/Inicio.aspx"
            CssClass="btn btn-default">
            Volver a tienda
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>
