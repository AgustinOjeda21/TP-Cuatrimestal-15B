<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Personas.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.WebForm6" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
   <title>Admin - Personas</title>
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
        <h2>Gestión de Personas</h2>
        <div class="acciones-top">
            <asp:TextBox ID="txtBuscar" runat="server" placeholder="Buscar categoría..." CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificar" runat="server" Text="+ Modificar Persona" PostBackUrl="~/Admin/Persona/ModificarPersona.aspx" CssClass="btn btn-default" />
            
        </div>
        <table class="table table-striped table-hover tabla-admin">
            <thead>
                <tr>
                    <th>ID</th>
                    <th>Nombre</th>
                    <th>Apellido</th>
                    <th>Mail</th>
                    <th>Teléfono</th>
                    <th>ID Usuario</th>
                </tr>
            </thead>
            <tbody>
                <asp:Repeater ID="rptPersona" runat="server">
                    <ItemTemplate>
                        <tr>
                            <td><%# Eval("IdPersona") %></td>
                            <td><%# Eval("Nombre") %></td>
                            <td><%# Eval("Apellido") %></td>
                            <td><%# Eval("Mail") %></td>
                            <td><%# Eval("Telefono") %></td>
                            <td><%# Eval("Usuario.IdUsuario") %></td>
                        </tr>
                    </ItemTemplate>
                </asp:Repeater>
            </tbody>
        </table>
    </div>
</form>
</body>
</html>
