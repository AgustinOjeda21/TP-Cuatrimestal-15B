<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Detalle Pedido</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class="navbar"> Detalle Pedido
        </div>
        <h1>Detalle del Pedido</h1>

        <p><strong>Número de pedido:</strong> #1001</p>
        <p><strong>Fecha:</strong> 15/06/2026</p>
        <p><strong>Estado:</strong> Entregado</p>

        <h2>Dirección de entrega</h2>
        <p>Av. Siempre Viva 742</p>

        <h2>Forma de entrega</h2>
        <p>Envío a domicilio</p>

        <h2>Forma de pago</h2>
        <p>Tarjeta de crédito</p>

        <h2>Productos</h2>

        <div class="productoPedido">
            <div class="imagenProducto">IMAGEN</div>
            <div class="infoProducto">
                <h3>Notebook HP 15"</h3>
                <p>Cantidad: 1</p>
                <p>Precio unitario: $850.000</p>
                <p>Subtotal: $850.000</p>
            </div>
        </div>

        <div class="productoPedido">
            <div class="imagenProducto">IMAGEN</div>
            <div class="infoProducto">
                <h3>Mouse Gamer</h3>
                <p>Cantidad: 2</p>
                <p>Precio unitario: $25.000</p>
                <p>Subtotal: $50.000</p>
            </div>
        </div>

        <h2>Total: $900.000</h2>

        <asp:Button
            ID="btnVolver"
            runat="server"
            Text="Volver a Mis Compras" CssClass="btn btn-default" />
    </form>
</body>
</html>
