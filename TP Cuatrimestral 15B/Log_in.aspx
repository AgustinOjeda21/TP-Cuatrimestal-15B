<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_in.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Log_in" %>
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
            <h2>Iniciar sesión</h2>

            <nav>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control campo" placeholder="Nombre usuario"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control campo" placeholder="Contraseña"></asp:TextBox>
            </nav>
        </div>
        <div class =" botones">
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" Text="Usuario o contraseña incorrectos"></asp:Label>
            <asp:Button
            ID="btnRegistrarse"
            runat="server"
            Text="Log in"
            OnClick="btnRegistrarse_Click" CssClass="btn btn-default" />

            <asp:HyperLink
            ID="lnkLogin"
            runat="server"
            NavigateUrl="~/Sign_in.aspx">
            No tengo cuenta
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
