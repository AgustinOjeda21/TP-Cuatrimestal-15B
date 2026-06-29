<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm5" async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mi Perfil</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form5" runat="server">
        <div class="navbar">Mi Perfil</div>
        <h1>Mi Perfil</h1>

<div class="perfil">

    <h2><asp:Label ID="lblNombre" runat="server" /></h2>

    <p><strong>Email:</strong> <asp:Label ID="lblMail" runat="server" /></p>

    <p><strong>Telefono:</strong> <asp:Label ID="lblTelefono" runat="server" /></p>

    <br />

    <asp:Button
        ID="btnEditarPerfil"
        runat="server"
        Text="Editar Perfil" CssClass="btn btn-default" PostBackUrl="~/Usuario/ModificarPerfil.aspx"/>

    <br /><br />

    <asp:Button
        ID="btnMisCompras"
        runat="server"
        Text="Mis Compras" CssClass="btn btn-default" PostBackUrl="~/Usuario/MisCompras.aspx" />

    <br /><br />

    <asp:Button
        ID="btnMisDirecciones"
        runat="server"
        Text="Mis Direcciones" CssClass="btn btn-default" PostBackUrl="~/Usuario/MisDirecciones.aspx"/>

    <br /><br />

    <asp:Button
        ID="btnCambiarPassword"
        runat="server"
        Text="Cambiar Contraseña" CssClass="btn btn-default" />

</div>
        <div class="text-center mt-4">
        <asp:Button ID="btnVolver"
        runat="server"
        Text="Volver"
        PostBackUrl="~/Inicio.aspx"
        CssClass="btn btn-secondary mx-2" />
        </div>
    </form>
</body>
</html>
