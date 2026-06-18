<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.AdminInicio" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin - Inicio</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
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
        <h2>Bienvenido al Panel de Administración</h2>
        <div class="cards">
            <a href="Producto/Productos.aspx" class="card"><h3>Productos</h3><p>Gestionar catálogo</p></a>
            <a href="Categoria/Categorias.aspx" class="card"><h3>Categorías</h3><p>Gestionar categorías</p></a>
            <a href="FormaPago/FormasPago.aspx" class="card"><h3>Formas de Pago</h3><p>Gestionar pagos</p></a>
            <a href="FormaEntrega/FormasEntrega.aspx" class="card"><h3>Formas de Entrega</h3><p>Gestionar entregas</p></a>
            <a href="Pedido/Pedidos.aspx" class="card"><h3>Pedidos</h3><p>Ver y gestionar pedidos</p></a>
            <a href="DetallePedido/DetallePedido.aspx" class="card"><h3>Detalle Pedido</h3><p>Gestionar el detalle de un pedido</p></a>
            <a href="Direccion/Direcciones.aspx" class="card"><h3>Direcciones</h3><p>Gestionar Direcciones</p></a>
            <a href="EstadoPedido/EstadosPedido.aspx" class="card"><h3>Estados Pedido</h3><p>Gestionar Los estados de pedido</p></a>
            <a href="EstadoCarrito/EstadosCarrito.aspx" class="card"><h3>Estados Carrito</h3><p>Gestionar los estados de carrito</p></a>
            <a href="Imagen/Imagenes.aspx" class="card"><h3>Imágenes</h3><p>Gestionar imágenes</p></a>
            <a href="Marca/Marcas.aspx" class="card"><h3>Marcas</h3><p>Gestionar Marcas</p></a>
            <a href="Persona/Personas.aspx" class="card"><h3>Personas</h3><p>Gestionar personas</p></a>
            <a href="Proveedor/Proveedores.aspx" class="card"><h3>Proveedores</h3><p>Gestionar proveedores</p></a>
            <a href="Usuario/Usuarios.aspx" class="card"><h3>Usuarios</h3><p>Gestionar usuarios</p></a>
            <a href="ProductoCarrito/ProductosCarrito.aspx" class="card"><h3>Productos Carrito</h3><p>Gestionar los productos de un carrito</p></a>
        </div>
    </div>
</form>
</body>
</html>

