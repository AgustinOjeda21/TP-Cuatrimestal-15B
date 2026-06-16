<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarDireccion.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Direccion.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Direccion</title>
    <style>
        .formulario-admin {
        max-width: 600px;
        margin: 30px auto;
        background-color: white;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .formulario-admin label {
        display: block;
        margin-top: 15px;
        margin-bottom: 5px;
        font-weight: bold;
    }

    .campo {
        width: 100%;
        padding: 10px;
        box-sizing: border-box;
    }

    .botones {
        margin-top: 20px;
        display: flex;
        gap: 10px;
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
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Direccion
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Direccion</h2>

        <label>Calle</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />

        <label>Numero</label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="campo" />

        <label>Localidad</label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="campo" />

        <label>Codigo Postal</label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="campo" />

        <label>Observaciones</label>
        <asp:TextBox ID="txtDescripcion"
            runat="server"
            CssClass="campo"
            TextMode="MultiLine"
            Rows="4" />

        <div class="botones">
            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar" />

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Direccion/Direcciones.aspx" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
