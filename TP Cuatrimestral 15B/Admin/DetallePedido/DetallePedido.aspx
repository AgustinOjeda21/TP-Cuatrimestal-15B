<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.AdminDetallePedido" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin - Detalle Pedido</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
<form id="form1" runat="server">
    <div class="navbar">
        <asp:HyperLink ID="linkAdminHome" runat="server" NavigateUrl="~/Admin/Inicio.aspx" CssClass="Titulo">Panel Admin</asp:HyperLink>
        <div class="nav-links">
            <asp:HyperLink ID="linkProductos" runat="server" NavigateUrl="~/Admin/Producto/Productos.aspx">Productos</asp:HyperLink>
            <asp:HyperLink ID="linkCategorias" runat="server" NavigateUrl="~/Admin/Categoria/Categorias.aspx">Categorías</asp:HyperLink>
            <asp:HyperLink ID="linkFormasPago" runat="server" NavigateUrl="~/Admin/FormaPago/FormasPago.aspx">Formas de Pago</asp:HyperLink>
            <asp:HyperLink ID="linkFormasEntrega" runat="server" NavigateUrl="~/Admin/FormaEntrega/FormasEntrega.aspx">Formas de Entrega</asp:HyperLink>
            <asp:HyperLink ID="linkPedidos" runat="server" NavigateUrl="~/Admin/Pedido/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="linkDetallePedido" runat="server" NavigateUrl="~/Admin/DetallePedido/DetallePedido.aspx">Detalle Pedido</asp:HyperLink>
            <asp:HyperLink ID="linkDirecciones" runat="server" NavigateUrl="~/Admin/Direccion/Direcciones.aspx">Direcciones</asp:HyperLink>
            <asp:HyperLink ID="linkEstadosPedido" runat="server" NavigateUrl="~/Admin/EstadoPedido/EstadosPedido.aspx">Estados Pedido</asp:HyperLink>
            <asp:HyperLink ID="linkEstadosCarrito" runat="server" NavigateUrl="~/Admin/EstadoCarrito/EstadosCarrito.aspx">Estados Carrito</asp:HyperLink>
            <asp:HyperLink ID="linkImagenes" runat="server" NavigateUrl="~/Admin/Imagen/Imagenes.aspx">Imágenes</asp:HyperLink>
            <asp:HyperLink ID="linkMarcas" runat="server" NavigateUrl="~/Admin/Marca/Marcas.aspx">Marcas</asp:HyperLink>
            <asp:HyperLink ID="linkPersonas" runat="server" NavigateUrl="~/Admin/Persona/Personas.aspx">Personas</asp:HyperLink>
            <asp:HyperLink ID="linkProveedores" runat="server" NavigateUrl="~/Admin/Proveedor/Proveedores.aspx">Proveedores</asp:HyperLink>
            <asp:HyperLink ID="linkUsuarios" runat="server" NavigateUrl="~/Admin/Usuario/Usuarios.aspx">Usuarios</asp:HyperLink>
            <asp:HyperLink ID="linkProductosCarrito" runat="server" NavigateUrl="~/Admin/ProductoCarrito/ProductosCarrito.aspx">Productos Carrito</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="linkTienda" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
            <asp:HyperLink ID="linkCerrarSesion" runat="server" NavigateUrl="~/Log_in.aspx">Cerrar sesión</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
        <asp:HyperLink ID="linkVolver" runat="server" NavigateUrl="~/Admin/Pedidos.aspx" CssClass="volver">← Volver a pedidos</asp:HyperLink>
        <h2>Detalle del Pedido <asp:Label ID="lblIdPedido" runat="server" Text="#-"></asp:Label></h2>

        <div class="seccion">
            <h3>Información del pedido</h3>
            <div class="fila"><label>Cliente:</label><asp:Label ID="lblCliente" runat="server" Text="-"></asp:Label></div>
            <div class="fila"><label>Fecha:</label><asp:Label ID="lblFecha" runat="server" Text="-"></asp:Label></div>
            <div class="fila"><label>Forma de pago:</label><asp:Label ID="lblFormaPago" runat="server" Text="-"></asp:Label></div>
            <div class="fila"><label>Forma de entrega:</label><asp:Label ID="lblFormaEntrega" runat="server" Text="-"></asp:Label></div>
            <div class="fila"><label>Dirección de entrega:</label><asp:Label ID="lblDireccion" runat="server" Text="-"></asp:Label></div>
            <div class="fila"><label>Total:</label><asp:Label ID="lblTotal" runat="server" Text="-"></asp:Label></div>
        </div>

        <div class="seccion">
            <h3>Productos del pedido</h3>
            <table class="table table-striped table-bordered tabla-items">
                <thead>
                    <tr>
                        <th>Producto</th>
                        <th>Cantidad</th>
                        <th>Precio unitario</th>
                        <th>Subtotal</th>
                    </tr>
                </thead>
                <tbody id="tbodyItems" runat="server">
                    <tr><td colspan="4" style="text-align:center; color:#888;">Sin datos</td></tr>
                </tbody>
            </table>
        </div>

        <div class="seccion">
            <h3>Estado del pedido</h3>
            <div class="estado-section">
                <asp:Label ID="lblEstadoActual" runat="server" Text="-"></asp:Label>
                <asp:TextBox ID="txtNuevoEstado" runat="server" placeholder="Nuevo estado..." CssClass="form-control"></asp:TextBox>
                <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar estado" CssClass="btn btn-default" />
            </div>
        </div>

        <div class="seccion">
            <h3>Observaciones internas</h3>
            <table class="table table-striped table-bordered tabla-observaciones" id="tbodyObservaciones" runat="server">
                <tr><td style="color:#888;">Sin observaciones</td></tr>
            </table>
            <asp:TextBox ID="txtObservacion" runat="server" placeholder="Agregar observación..." Width="400px" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnAgregarObservacion" runat="server" Text="Agregar" CssClass="btn btn-default" />
        </div>
    </div>
</form>
</body>
</html>

