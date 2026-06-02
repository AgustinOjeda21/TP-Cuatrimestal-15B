<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP_Cuatrimestral_15B.Inicio" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        <title>Inicio</title>
        <style>
            .navbar {
            background-color: brown;
            color: white;
            padding: 30px;
            align-items: center;
            display: flex;
            }
            #txtBuscar {
                width: 500px;
                height: 35px;
                border-radius: 5px;
                margin-left: auto;
                padding-left: 15px;
                border: 1px solid #ccc;
            }
            #btnBuscar {
                margin-left: 10px;
            }
            .Titulo {
                color: white;
                font-size: 24px;
                font-weight: bold;
            }
            .LinkLabel{
                color: white;
                display: flex;
                margin-left: auto;
                gap : 20px;
            }
             .carouselSlide {
            height: 300px;
            background-color: #f2f2f2;
            margin: 20px;
            border-radius: 10px;
            display: flex;
            justify-content: center;
            align-items: center;
            font-size: 32px;
            font-weight: bold;
            }
             .productosDestacados {
                margin: 20px;
            }

            .contenedorProductos {
                display: flex;
                gap: 20px;
                justify-content: center;
            }

            .producto {
                width: 250px;
                border: 1px solid #ccc;
                border-radius: 10px;
                padding: 15px;
                text-align: center;
            }

            .producto img {
                width: 100%;
                height: 180px;
                object-fit: cover;
            }
        </style>

    </head>

<body>
    <form id="form1" runat="server">
        <div class =" navbar">
            <asp:HyperLink ID="linkHome" runat="server" NavigateUrl="~/Inicio.aspx" CssClass="Titulo">Mi Tienda</asp:HyperLink>
            <asp:TextBox ID="txtBuscar" runat="server" placeholder ="Buscar producto..."></asp:TextBox>
            <asp:Button ID ="btnBuscar" runat="server" Text="Buscar"></asp:Button>
            <nav class =" LinkLabel">
                   <asp:HyperLink ID="linkLogin" runat="server" NavigateUrl="~/Log_in.aspx">Log in</asp:HyperLink>
                   <asp:HyperLink ID="linkSignin" runat="server" NavigateUrl="~/Sign_in.aspx">Sign in</asp:HyperLink>
                   <asp:Button ID ="btnCarrito" runat="server" Text="Mi carrito"></asp:Button>
            </nav>
        </div>
        <a href="ListaProducto.aspx"><div id ="Ofertas" class = "carouselSlide">OFERTAS DEL MES</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria1" class = "carouselSlide">CATEGORIA 1</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria2" class = "carouselSlide">CATEGORIA 2</div></a>
        <a href="ListaProducto.aspx"><div id ="Categoria3" class = "carouselSlide">CATEGORIA 3</div></a>
        <a href="ListaProducto.aspx"><div id ="TodasCategorias" class = "carouselSlide">TODAS LAS CATEGORIAS</div></a>
        <div class="productosDestacados">
    
    <h2>Productos Destacados</h2>

    <div class="contenedorProductos">

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Notebook HP</h3>
            <p>$850.000</p>
            <asp:Button ID="btnVer1" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" />
        </div>

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Mouse Gamer</h3>
            <p>$25.000</p>
            <asp:Button ID="btnVer2" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" />
        </div>

        <div class="producto">
            <img src="https://via.placeholder.com/250x180" />
            <h3>Teclado Mecánico</h3>
            <p>$70.000</p>
            <asp:Button ID="btnVer3" runat="server" Text="Ver Detalle" PostBackUrl="~/DetalleProducto.aspx" />
        </div>

    </div>

</div>
    </form>
</body>
</html>



