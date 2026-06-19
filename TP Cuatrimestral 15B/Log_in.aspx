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
        <div class="authPage">
        <div class = "registro authBox">
            <h2>Iniciar sesión</h2>
            <p class="authSubtitulo">Entrá con tu cuenta para seguir comprando.</p>

            <div class="campoAuth">
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="form-control campo" placeholder="Email"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control campo" TextMode="Password" placeholder="Contraseña"></asp:TextBox>
            </div>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" Text="Usuario o contraseña incorrectos"></asp:Label>
            <div class ="botones authBotones">
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
        </div>
        </div>
    </form>
</body>
</html>
