<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisDirecciones.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm4" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mis Direcciones</title>
    <style>
        .direccion {
    background-color: #f8f8f8;
    border: 1px solid #ccc;
    border-radius: 10px;
    padding: 20px;
    margin: 20px 0;
    }

    .direccion h3 {
        margin-top: 0;
    }

    .direccion p {
        margin: 5px 0;
    }

    .direccion input[type="submit"] {
        margin-right: 10px;
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
                Text="Editar" />

            <asp:Button
                ID="btnEliminar1"
                runat="server"
                Text="Eliminar" />
        </div>

        <div class="direccion">
            <h3>Trabajo</h3>
            <p>Calle Falsa 123</p>
            <p>Buenos Aires</p>
            <p>Código Postal: 5678</p>

            <asp:Button
                ID="btnEditar2"
                runat="server"
                Text="Editar" />

            <asp:Button
                ID="btnEliminar2"
                runat="server"
                Text="Eliminar" />
        </div>

        <br />

        <asp:Button
            ID="btnAgregarDireccion"
            runat="server"
            Text="Agregar dirección" />
    </form>
</body>
</html>
