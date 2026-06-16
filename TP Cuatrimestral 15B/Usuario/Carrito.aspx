<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Mi Carrito</title>
    <style>
        .tarjetaCarrito {
    display: flex;
    align-items: center;
    justify-content: space-between;
    border: 1px solid #ccc;
    border-radius: 10px;
    padding: 20px;
    margin: 20px 0;
    background-color: #f9f9f9;
    }

    .imagenProducto {
        width: 120px;
        height: 120px;
        background-color: lightgray;
        display: flex;
        justify-content: center;
        align-items: center;
    }

    .infoProducto {
        flex: 1;
        margin-left: 20px;
    }

    .acciones {
        margin-left: 20px;
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
    <form id="form2" runat="server">
    <div class =" navbar">Mi Carrito</div>
        <div class="tarjetaCarrito">

    <div class="imagenProducto">
        IMAGEN
    </div>

    <div class="infoProducto">
        <h3>Notebook HP 15"</h3>
        <p>Precio: $850.000</p>
        <p>Cantidad: 1</p>
        <p>Subtotal: $850.000</p>
    </div>

    <div class="acciones">
        <asp:Button
            ID="btnEliminar1"
            runat="server"
            Text="Eliminar" />
    </div>

</div>
    </form>
</body>
</html>
