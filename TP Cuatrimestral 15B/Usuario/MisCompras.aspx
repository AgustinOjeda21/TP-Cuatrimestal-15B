<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mis Compras</title>
    <style>
        .compra {
    border: 1px solid #ccc;
    border-radius: 10px;
    background-color: #f9f9f9;
    padding: 20px;
    margin: 20px;
    }

    .compra h3 {
        margin-top: 0;
    }

    .compra p {
        margin: 8px 0;
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
    <form id="form3" runat="server">
        <div class ="navbar"></div>
        <h1>Mis Compras</h1>

        <div class="compra">

            <h3>Pedido #1001</h3>

            <p>Fecha: 15/06/2026</p>

            <p>Estado: Entregado</p>

            <p>Total: $875.000</p>

            <asp:Button
                ID="btnDetalle1"
                runat="server"
                Text="Ver detalle" />

        </div>

        <div class="compra">

            <h3>Pedido #1002</h3>

            <p>Fecha: 20/06/2026</p>

            <p>Estado: En preparación</p>

            <p>Total: $120.000</p>

            <asp:Button
                ID="btnDetalle2"
                runat="server"
                Text="Ver detalle" />
        </div>
    </form>
</body>
</html>
