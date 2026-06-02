<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetalleProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.DetalleProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        <title>Detalle Producto</title>
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
             .productosDestacados {
                margin: 20px;
            }

            .contenedorProductos {
                display: flex;
                gap: 20px;
                justify-content: center;
                overflow-x: auto;
            }

            .detalleProducto {
                display:flex;
                gap: 40px;
                margin: 30px;
            }

            .productoimg {
                width: 400px;
                height: 400px;
                align-items: center;
                display: flex;
                justify-content: center;
                background-color:lightgray;
            }
            .infoProducto{
                max-width: 600px;
            }

            .producto {
            width: 250px;
            border: 1px solid #ccc;
            border-radius: 10px;
            padding: 15px;
            text-align: center;
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
        <div id ="Producto" class = "detalleProducto">
            <div class = "productoimg">
                IMAGEN
            </div>
            <div class = "infoProducto">
                <h1>Notebook HP 15"</h1>

                <p><b>Categoría:</b> Electrónica</p>

                <p><b>Precio:</b> $850.000</p>

                <p><b>Stock:</b> 12 unidades</p>

                <h3>Descripción</h3>

                <p>
                    Notebook HP con procesador Intel i5,
                    16GB RAM y SSD de 512GB.
                </p>

                <asp:TextBox
                    ID="txtCantidad"
                    runat="server"
                    Text="1">
                </asp:TextBox>

                <asp:Button
                    ID="btnAgregarCarrito"
                    runat="server"
                    Text="Agregar al carrito" />
            </div>
        </div>
        <div class="productosDestacados">
    
    <h2>PRODUCTOS RELACIONADOS</h2>

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
