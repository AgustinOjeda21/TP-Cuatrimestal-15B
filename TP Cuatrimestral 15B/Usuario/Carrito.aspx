<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.Carrito"  Async="true"%>

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
     <asp:Repeater ID="rptCarrito" runat="server" OnItemCommand="rptCarrito_ItemCommand">
    <ItemTemplate>

        <div class="tarjetaCarrito card mb-3 p-3">

            <div class="row align-items-center">

                <div class="col-md-2">
                    <img src='<%# ObtenerImagenProducto(Container.DataItem) %>'
                         class="img-fluid"
                         style="max-height:100px;" />
                </div>

                <div class="col-md-6">
                    <h5><%# Eval("Producto.Nombre") %></h5>
                    <p>Precio: $<%# Eval("Producto.Precio") %></p>
                    <p>Cantidad: <%# Eval("Cantidad") %></p>
                    <p>Subtotal: $<%# CalcularSubtotal(Container.DataItem) %></p>
                </div>

                <div class="col-md-4 text-end">
                    <asp:Button
                        CommandName="Eliminar"
                        CommandArgument='<%# Eval("Producto.IdProducto") %>'
                        runat="server"
                        Text="Eliminar"
                        CssClass="btn btn-danger" />
                </div>

            </div>
        </div>

    </ItemTemplate>
</asp:Repeater>
    <div class="text-center mt-4">

    <asp:Button ID="btnVolver"
        runat="server"
        Text="Volver"
        PostBackUrl="~/Inicio.aspx"
        CssClass="btn btn-secondary mx-2" />

    <asp:Button ID="btnCancelar"
        runat="server"
        Text="Cancelar Carrito"
        CssClass="btn btn-danger mx-2"
        OnClick="btnCancelar_Click" />

    <asp:Button ID="btnConfirmar"
        runat="server"
        Text="Confirmar Compra"
        CssClass="btn btn-success mx-2"
        PostBackUrl="~/Usuario/Checkout.aspx" />

</div>
        
    </form>
</body>
</html>
