<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EstadosCarrito.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.WebForm3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
  <title>Admin - Estados de carrito</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f9f9f9; }
        .navbar { background-color: brown; color: white; padding: 15px 30px; display: flex; align-items: center; gap: 20px; flex-wrap: wrap; }
        .navbar a { color: white; text-decoration: none; font-size: 14px; }
        .Titulo { font-size: 22px; font-weight: bold; }
        .nav-links { display: flex; gap: 20px; }
        .nav-right { margin-left: auto; display: flex; gap: 15px; align-items: center; }
        .contenido { margin: 30px; }
        h2 { color: #333; margin-bottom: 20px; }
        .acciones-top { display: flex; justify-content: space-between; align-items: center; margin-bottom: 20px; }
        .tabla-admin { width: 100%; border-collapse: collapse; background: white; border-radius: 8px; overflow: hidden; box-shadow: 0 2px 8px rgba(0,0,0,0.1); }
        .tabla-admin th { background-color: brown; color: white; padding: 12px 15px; text-align: left; font-size: 13px; }
        .tabla-admin td { padding: 12px 15px; border-bottom: 1px solid #eee; font-size: 14px; }
        .tabla-admin tr:last-child td { border-bottom: none; }
        .tabla-admin tr:hover td { background-color: #f5f5f5; }
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
        <h2>Gestión de Estados de carrito</h2>
        <div class="acciones-top">
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar categoría..."></asp:TextBox>
            <asp:Button ID="btnAgregar" runat="server" Text="+ Agregar categoría" />
        </div>
        <table class="tabla-admin">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptEstadoCarrito" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("IdEstadoCarrito") %></td>
                            <td><%# Eval("Nombre") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</form>
</body>
</html>
