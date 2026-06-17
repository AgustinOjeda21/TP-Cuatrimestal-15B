<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListaProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.ListaProducto" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">

    <meta charset="utf-8" />
<title>Lista Productos</title>
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
                   <asp:Button ID ="btnCarrito" runat="server" Text="Mi carrito" CssClass="btn btn-default"></asp:Button>
            </nav>
        </div>
        <div id ="TodasCategorias" class = "categorias">
            <h2>
                TODAS LAS CATEGORÍAS
            </h2>
            <div>
                <asp:Button ID="btnTodas" runat="server" Text="Todas" CssClass="btn btn-default" />
                <asp:Repeater ID="rptCategorias" runat="server">
                    <ItemTemplate>
                        <asp:Button ID="btnCategoria" runat="server" Text='<%# Eval("Nombre") %>' CssClass="btn btn-default" />
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="productosDestacados">

    <h2>CATALOGO DE PRODUCTOS</h2>

    <div class="contenedorProductos">

        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                <div class="producto">
                    <img src="https://via.placeholder.com/250x180" />
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
