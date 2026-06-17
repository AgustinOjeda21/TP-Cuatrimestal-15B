<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.Carrito" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mi Carrito</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
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
            Text="Eliminar" CssClass="btn btn-default" />
    </div>

</div>
    </form>
</body>
</html>
