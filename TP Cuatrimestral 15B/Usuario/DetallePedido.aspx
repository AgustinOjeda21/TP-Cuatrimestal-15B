<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm3" Async="true" %>

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
        </div >
        <div class ="compra">
        <h1>Detalle del Pedido</h1>

        <p><strong>Número de pedido:</strong> <asp:Label ID="lblNumero" runat="server" /></p>
        <p><strong>Fecha:</strong> <asp:Label ID="lblFecha" runat="server" /></p>
        <p><strong>Estado:</strong> <asp:Label ID="lblEstado" runat="server" /></p>
        <p><strong>Direccion de la entrega:</strong> <asp:Label ID="lblDireccion" runat="server" /></p>
        <p><strong>Forma de entrega:</strong> <asp:Label ID="lblEntrega" runat="server" /></p>
        <p><strong>Forma de pago:</strong> <asp:Label ID="lblPago" runat="server" /></p>
        <h2>Productos</h2>

           
    <div class =" navbar">Mi Carrito</div>
     <asp:Repeater ID="rptCarrito" runat="server" >
    <ItemTemplate>

        <div class="tarjetaCarrito card mb-3 p-3">

            <div class="row align-items-center">

                <div class="col-md-2">
                    <img src='<%# Eval("Producto.Imagenes[0].URL") %>'
                         class="img-fluid"
                         style="max-height:100px;" />
                </div>

               <div class="col-md-6">
                    <h5><%# Eval("Producto.Nombre") %></h5>
                    <p>Precio: $<%# Eval("Producto.Precio") %></p>
                    <p>Cantidad: <%# Eval("Cantidad") %></p>
                
                </div>

            </div>
        </div>

    </ItemTemplate>
    </asp:Repeater>
    <p><strong>Total:</strong> <asp:Label ID="lblTotal" runat="server" /></p>
    </div>

        <div class="text-center mt-4">

        <asp:Button ID="btnVolver"
            runat="server"
            Text="Volver"
            PostBackUrl="~/Usuario/MisCompras.aspx"
            CssClass="btn btn-secondary mx-2" />

        <asp:Button ID="btnPagar"
            runat="server"
            Text="Pagar Pedido"
            visible="false"
            CssClass="btn btn-success mx-2"
            OnClick="btnPagar_Click"/>

        <asp:Button ID="btnCancelar"
            runat="server"
            Text="Cancelar Pedido"
            visible="false"
            CssClass="btn btn-danger mx-2" 
            OnClick="btnCancelar_Click"/>

         <asp:Button ID="btnReestablecer"
            runat="server"
            Text="Reestablecer Pedido"
            visible="false"
            CssClass="btn btn-success mx-2"
            OnClick="btnReestablecer_Click"/>

        </div>
    </form>
</body>
</html>
