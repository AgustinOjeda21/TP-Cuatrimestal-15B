<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Checkout.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm1" Async="true" %>

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
        <div class="navbar"> Detalle Pedido
        </div >
        <div class ="compra">
        <h1>Detalle del Pedido</h1>

        <p><strong>Fecha:</strong> <%= DateTime.Today.ToString("dd/MM/yyyy") %></p>

        <label>Dirección de entrega</label>
        <div class="selector">
            <asp:DropDownList ID="ddlDirecciones" runat="server" CssClass="form-control campo"> </asp:DropDownList>
        </div>

        <label>Forma de entrega</label>
        <div class="selector">
            <asp:DropDownList ID="ddlFormaEntrega" runat="server" CssClass="form-control campo"> </asp:DropDownList>
        </div>

        <label>Forma de pago</label>
        <div class="selector">
            <asp:DropDownList ID="ddlFormaPago" runat="server" CssClass="form-control campo"> </asp:DropDownList>
        </div>

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
            PostBackUrl="~/Carrito.aspx"
            CssClass="btn btn-secondary mx-2" />

        <asp:Button ID="btnConfirmar"
            runat="server"
            Text="Confirmar Pedido"
            CssClass="btn btn-success mx-2" 
            OnClick="btnConfirmar_Click"/>
    </div>
    </form>
</body>
</html>
