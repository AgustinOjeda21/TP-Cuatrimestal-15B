<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Checkout</title>
    <style>
                body {
            font-family: Arial, sans-serif;
            background-color: #f5f5f5;
        }

        .checkoutContainer {
            display: flex;
            gap: 30px;
            margin: 30px;
        }

        .checkoutIzquierda,
        .checkoutDerecha {
            flex: 1;
            background-color: white;
            padding: 20px;
            border: 1px solid #ccc;
            border-radius: 10px;
        }

        .checkoutIzquierda h2,
        .checkoutDerecha h2 {
            margin-top: 0;
        }

        .checkoutIzquierda select,
        .checkoutIzquierda input {
            width: 100%;
            padding: 8px;
            margin-bottom: 15px;
        }

        .total {
            font-size: 22px;
            font-weight: bold;
            color: green;
            margin-top: 20px;
        }

        #btnConfirmarCompra {
            width: 100%;
            height: 45px;
            margin-top: 20px;
            font-size: 16px;
            font-weight: bold;
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
            Text="Confirmar compra" />
    </div>

</div>
    </form>
</body>
</html>
