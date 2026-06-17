<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Checkout</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class =" navbar">Checkout</div>
        <div class="checkoutContainer">

    <div class="checkoutIzquierda">
        <h2>Datos de entrega</h2>
    </div>

    <div class="checkoutDerecha">
        <h2>Resumen del pedido</h2>

        <p>Notebook HP - $850.000</p>
        <p>Mouse Gamer - $25.000</p>

        <div class="total">
            Total: $875.000
        </div>

        <asp:Button
            ID="btnConfirmarCompra"
            runat="server"
            Text="Confirmar compra" CssClass="btn btn-default" />
    </div>

</div>
    </form>
</body>
</html>
