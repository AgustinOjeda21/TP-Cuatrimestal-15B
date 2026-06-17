<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP_Cuatrimestral_15B.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        
    <meta charset="utf-8" />
<title>Inicio</title>
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
        <a href="ListaProducto.aspx"><div id ="Ofertas" class = "carouselSlide">OFERTAS DEL MES</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria1" class = "carouselSlide">CATEGORÍA 1</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria2" class = "carouselSlide">CATEGORÍA 2</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria3" class = "carouselSlide">CATEGORÍA 3</div></a>
        <a href="ListaProducto.aspx"><div id ="TodasCategorias" class = "carouselSlide">TODAS LAS CATEGORÍAS</div></a>
        <div class="productosDestacados">
    
    <h2>Productos Destacados</h2>

    <div class="contenedorProductos">

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Notebook HP</h3>
            <p>$850.000</p>
            <asp:Button ID="btnVer1" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" CssClass="btn btn-default" />
        </div>

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Mouse Gamer</h3>
            <p>$25.000</p>
            <asp:Button ID="btnVer2" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" CssClass="btn btn-default" />
        </div>

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Teclado Mecánico</h3>
            <p>$70.000</p>
            <asp:Button ID="btnVer3" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>



