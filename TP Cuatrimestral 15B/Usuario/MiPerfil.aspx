<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm5" %>

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

    <h2>Agustín Ojeda</h2>

    <p><strong>Email:</strong> agustin@email.com</p>

    <p><strong>Teléfono:</strong> 11 1234-5678</p>

    <br />

    <asp:Button
        ID="btnEditarPerfil"
        runat="server"
        Text="Editar Perfil" CssClass="btn btn-default" />

    <br /><br />

    <asp:Button
        ID="btnMisCompras"
        runat="server"
        Text="Mis Compras" CssClass="btn btn-default" />

    <br /><br />

    <asp:Button
        ID="btnMisDirecciones"
        runat="server"
        Text="Mis Direcciones" CssClass="btn btn-default" />

    <br /><br />

    <asp:Button
        ID="btnCambiarPassword"
        runat="server"
        Text="Cambiar Contraseña" CssClass="btn btn-default" />

    <br /><br />

    <asp:Button
        ID="btnCerrarSesion"
        runat="server"  
        Text="Cerrar Sesión" CssClass="btn btn-default" />

</div>
    </form>
</body>
</html>
