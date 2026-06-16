<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MiPerfil.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm5" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mi Perfil</title>
    <style>
        .perfil {
    width: 450px;
    margin: 30px auto;
    padding: 25px;
    border: 1px solid #ccc;
    border-radius: 10px;
    background-color: #f8f8f8;
    text-align: center;
    }

    .perfil h2 {
        margin-bottom: 20px;
    }

    .perfil p {
        margin: 10px 0;
    }

    .perfil input[type="submit"] {
        width: 220px;
        height: 40px;
        border-radius: 5px;
    }
    .navbar {
            background-color: brown;
            color: white;
            padding: 30px;
            align-items: center;
            display: flex;
            }
    </style>
</head>
<body>
    <form id="form5" runat="server">
        <%--<div class ="navbar"> Mi perfil--%>
        </div>
        <h1>Mi Perfil</h1>

<div class="perfil">

    <h2>Agustín Ojeda</h2>

    <p><strong>Email:</strong> agustin@email.com</p>

    <p><strong>Teléfono:</strong> 11 1234-5678</p>

    <br />

    <asp:Button
        ID="btnEditarPerfil"
        runat="server"
        Text="Editar Perfil" />

    <br /><br />

    <asp:Button
        ID="btnMisCompras"
        runat="server"
        Text="Mis Compras" />

    <br /><br />

    <asp:Button
        ID="btnMisDirecciones"
        runat="server"
        Text="Mis Direcciones" />

    <br /><br />

    <asp:Button
        ID="btnCambiarPassword"
        runat="server"
        Text="Cambiar Contraseña" />

    <br /><br />

    <asp:Button
        ID="btnCerrarSesion"
        runat="server"
        Text="Cerrar Sesión" />

</div>
    </form>
</body>
</html>
