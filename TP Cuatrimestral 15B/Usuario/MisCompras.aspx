<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mis Compras</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
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
                Text="Ver detalle" CssClass="btn btn-default" />

        </div>

        <div class="compra">

            <h3>Pedido #1002</h3>

            <p>Fecha: 20/06/2026</p>

            <p>Estado: En preparación</p>

            <p>Total: $120.000</p>

            <asp:Button
                ID="btnDetalle2"
                runat="server"
                Text="Ver detalle" CssClass="btn btn-default" />
        </div>
    </form>
</body>
</html>
