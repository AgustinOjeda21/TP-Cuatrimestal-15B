<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.DetalleProducto" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">

    <meta charset="utf-8" />
<title>Detalle Producto</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />


    </head>

<body>
    <form id="form1" runat="server">
        <div class =" navbar">
            <asp:HyperLink ID="linkHome" runat="server" NavigateUrl="~/Inicio.aspx" CssClass="Titulo">Mi Tienda</asp:HyperLink>
            <asp:TextBox ID="txtBuscar" runat="server" placeholder ="Buscar producto..." CssClass="form-control"></asp:TextBox>
            <asp:Button ID ="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default"></asp:Button>
            <nav class =" LinkLabel">
                   <asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="~/Log_in.aspx">Log in</asp:HyperLink>
                   <asp:HyperLink ID="linkSignin" runat="server" NavigateUrl="~/Sign_in.aspx">Sign in</asp:HyperLink>
                   <asp:Button ID ="btnCarrito" runat="server" Text="Mi carrito" CssClass="btn btn-default" PostBackUrl="~/Usuario/Carrito.aspx"></asp:Button>
            </nav>
        </div>
        <div id ="Producto" class = "detalleProducto">
            <div class = "productoimg">
                <img src="<%= imagenUrl %>" alt="Producto" />
            </div>
            <div class = "infoProducto">
                <h1><%= producto != null ? producto.Nombre : "" %></h1>

                <p><b>Precio:</b> $<%= producto != null ? producto.Precio.ToString() : "" %></p>

                <p><b>Stock:</b> <%= producto != null ? producto.Stock.ToString() : "" %> unidades</p>

                <h3>Descripción</h3>

                <p><%= producto != null ? producto.Descripcion : "" %></p>

                <asp:TextBox
                    ID="txtCantidad"
                    runat="server"
                    Text="1" CssClass="form-control">
                </asp:TextBox>

                <asp:Button
                    ID="btnAgregarCarrito"
                    runat="server"
                    Text="Agregar al carrito" CssClass="btn btn-default" OnClick ="btnAgregarCarrito_Click"/>
            </div>
        </div>
        <div class="productosDestacados">

    <h2>PRODUCTOS RELACIONADOS</h2>

    <div class="contenedorProductos">

        <asp:Repeater ID="rptRelacionados" runat="server">
            <ItemTemplate>
                <div class="producto">
                    <img src='<%# Eval("ImagenUrl") %>' alt='<%# Eval("Nombre") %>' />
                    <h3><%# Eval("Nombre") %></h3>
                    <p>$<%# Eval("Precio") %></p>
                    <asp:HyperLink ID="lnkVer" runat="server" NavigateUrl='<%# "~/DetalleProducto.aspx?id=" + Eval("IdProducto") %>' CssClass="btn btn-default">Ver Detalle</asp:HyperLink>
                </div>
            </ItemTemplate>
        </asp:Repeater>

    </div>

</div>
    </form>
</body>
</html>
