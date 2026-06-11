<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DetallePedido.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.AdminDetallePedido" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin - Detalle Pedido</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f9f9f9; }
        .navbar { background-color: brown; color: white; padding: 15px 30px; display: flex; align-items: center; gap: 20px; flex-wrap: wrap; }
        .navbar a { color: white; text-decoration: none; font-size: 14px; }
        .Titulo { font-size: 22px; font-weight: bold; }
        .nav-links { display: flex; gap: 20px; }
        .nav-right { margin-left: auto; display: flex; gap: 15px; align-items: center; }
        .contenido { margin: 30px; }
        h2 { color: #333; margin-bottom: 20px; }
        .volver { margin-bottom: 20px; display: inline-block; color: brown; text-decoration: none; font-size: 14px; }
        .seccion { background: white; border-radius: 8px; padding: 20px 25px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); margin-bottom: 20px; }
        .seccion h3 { margin: 0 0 15px 0; color: brown; font-size: 16px; border-bottom: 1px solid #eee; padding-bottom: 10px; }
        .fila { display: flex; gap: 10px; margin-bottom: 10px; font-size: 14px; }
        .fila label { font-weight: bold; min-width: 160px; color: #555; }
        .tabla-items { width: 100%; border-collapse: collapse; }
        .tabla-items th { background-color: #f2f2f2; padding: 10px 15px; text-align: left; font-size: 13px; color: #555; }
        .tabla-items td { padding: 10px 15px; border-bottom: 1px solid #eee; font-size: 14px; }
        .estado-section { display: flex; gap: 15px; align-items: center; flex-wrap: wrap; }
        .tabla-observaciones { width: 100%; border-collapse: collapse; margin-bottom: 15px; }
        .tabla-observaciones td { padding: 8px; border-bottom: 1px solid #eee; font-size: 13px; }
        .badge { padding: 4px 10px; border-radius: 12px; font-size: 12px; font-weight: bold; }
        .badge-pendiente { background-color: #fff3cd; color: #856404; }
        .badge-pagado { background-color: #d4edda; color: #155724; }
        .badge-enviado { background-color: #cce5ff; color: #004085; }
        .badge-cancelado { background-color: #f8d7da; color: #721c24; }
    </style>
</head>
<body>
<form id="form1" runat="server">
    <div class="navbar">
        <asp:HyperLink ID="linkAdminHome" runat="server" NavigateUrl="~/Admin/Inicio.aspx" CssClass="Titulo">Panel Admin</asp:HyperLink>
        <div class="nav-links">
            <asp:HyperLink ID="linkProductos" runat="server" NavigateUrl="~/Admin/Productos.aspx">Productos</asp:HyperLink>
            <asp:HyperLink ID="linkCategorias" runat="server" NavigateUrl="~/Admin/Categorias.aspx">Categorías</asp:HyperLink>
            <asp:HyperLink ID="linkFormasPago" runat="server" NavigateUrl="~/Admin/FormasPago.aspx">Formas de Pago</asp:HyperLink>
            <asp:HyperLink ID="linkFormasEntrega" runat="server" NavigateUrl="~/Admin/FormasEntrega.aspx">Formas de Entrega</asp:HyperLink>
            <asp:HyperLink ID="linkPedidos" runat="server" NavigateUrl="~/Admin/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="linkDetallePedido" runat="server" NavigateUrl="~/Admin/DetallePedido.aspx">Detalle Pedido</asp:HyperLink>
            <asp:HyperLink ID="linkDirecciones" runat="server" NavigateUrl="~/Admin/Direcciones.aspx">Direcciones</asp:HyperLink>
            <asp:HyperLink ID="linkEstadosPedido" runat="server" NavigateUrl="~/Admin/EstadosPedido.aspx">Estados Pedido</asp:HyperLink>
            <asp:HyperLink ID="linkEstadosCarrito" runat="server" NavigateUrl="~/Admin/EstadosCarrito.aspx">Estados Carrito</asp:HyperLink>
            <asp:HyperLink ID="linkImagenes" runat="server" NavigateUrl="~/Admin/Imagenes.aspx">Imagenes</asp:HyperLink>
            <asp:HyperLink ID="linkMarcas" runat="server" NavigateUrl="~/Admin/Marcas.aspx">Marcas</asp:HyperLink>
            <asp:HyperLink ID="linkPersonas" runat="server" NavigateUrl="~/Admin/Personas.aspx">Personas</asp:HyperLink>
            <asp:HyperLink ID="linkProveedores" runat="server" NavigateUrl="~/Admin/Proveedores.aspx">Proveedores</asp:HyperLink>
            <asp:HyperLink ID="linkUsuarios" runat="server" NavigateUrl="~/Admin/Usuarios.aspx">Usuarios</asp:HyperLink>
            <asp:HyperLink ID="linkProductosCarrito" runat="server" NavigateUrl="~/Admin/ProductosCarrito.aspx">Productos Carrito</asp:HyperLink>
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
            <table class="tabla-items">
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
                <asp:TextBox ID="txtNuevoEstado" runat="server" placeholder="Nuevo estado..."></asp:TextBox>
                <asp:Button ID="btnCambiarEstado" runat="server" Text="Cambiar estado" />
            </div>
        </div>

        <div class="seccion">
            <h3>Observaciones internas</h3>
            <table class="tabla-observaciones" id="tbodyObservaciones" runat="server">
                <tr><td style="color:#888;">Sin observaciones</td></tr>
            </table>
            <asp:TextBox ID="txtObservacion" runat="server" placeholder="Agregar observación..." Width="400px"></asp:TextBox>
            <asp:Button ID="btnAgregarObservacion" runat="server" Text="Agregar" />
        </div>
    </div>
</form>
</body>
</html>

