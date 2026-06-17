<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisDirecciones.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mis Direcciones</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form4" runat="server">
        <div class =" navbar">Mis Direcciones
        </div>
        <h1>Mis Direcciones</h1>

        <div class="direccion">
            <h3>Casa</h3>
            <p>Av. Siempre Viva 742</p>
            <p>Springfield</p>
            <p>Código Postal: 1234</p>

            <asp:Button
                ID="btnEditar1"
                runat="server"
                Text="Editar" CssClass="btn btn-default" />

            <asp:Button
                ID="btnEliminar1"
                runat="server"
                Text="Eliminar" CssClass="btn btn-default" />
        </div>

        <div class="direccion">
            <h3>Trabajo</h3>
            <p>Calle Falsa 123</p>
            <p>Buenos Aires</p>
            <p>Código Postal: 5678</p>

            <asp:Button
                ID="btnEditar2"
                runat="server"
                Text="Editar" CssClass="btn btn-default" />

            <asp:Button
                ID="btnEliminar2"
                runat="server"
                Text="Eliminar" CssClass="btn btn-default" />
        </div>

        <br />

        <asp:Button
            ID="btnAgregarDireccion"
            runat="server"
            Text="Agregar dirección" CssClass="btn btn-default" />
    </form>
</body>
</html>
