<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Marcas.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.WebForm5" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Admin - Marcas</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
<form id="form2" runat="server">
    <div class="navbar">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Inicio.aspx" CssClass="Titulo">Panel Admin</asp:HyperLink>
        <div class="nav-links">
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Producto/Productos.aspx">Productos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Categoria/Categorias.aspx">Categorías</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/FormaPago/FormasPago.aspx">Formas de Pago</asp:HyperLink>
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/FormaEntrega/FormasEntrega.aspx">Formas de Entrega</asp:HyperLink>
            <asp:HyperLink ID="HyperLink6" runat="server" NavigateUrl="~/Admin/Pedido/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink7" runat="server" NavigateUrl="~/Admin/DetallePedido/DetallePedido.aspx">Detalle Pedido</asp:HyperLink>
            <asp:HyperLink ID="HyperLink8" runat="server" NavigateUrl="~/Admin/Direccion/Direcciones.aspx">Direcciones</asp:HyperLink>
            <asp:HyperLink ID="HyperLink9" runat="server" NavigateUrl="~/Admin/EstadoPedido/EstadosPedido.aspx">Estados Pedido</asp:HyperLink>
            <asp:HyperLink ID="HyperLink10" runat="server" NavigateUrl="~/Admin/EstadoCarrito/EstadosCarrito.aspx">Estados Carrito</asp:HyperLink>
            <asp:HyperLink ID="HyperLink11" runat="server" NavigateUrl="~/Admin/Imagen/Imagenes.aspx">Imágenes</asp:HyperLink>
            <asp:HyperLink ID="HyperLink12" runat="server" NavigateUrl="~/Admin/Marca/Marcas.aspx">Marcas</asp:HyperLink>
            <asp:HyperLink ID="HyperLink13" runat="server" NavigateUrl="~/Admin/Persona/Personas.aspx">Personas</asp:HyperLink>
            <asp:HyperLink ID="HyperLink14" runat="server" NavigateUrl="~/Admin/Proveedor/Proveedores.aspx">Proveedores</asp:HyperLink>
            <asp:HyperLink ID="HyperLink15" runat="server" NavigateUrl="~/Admin/Usuario/Usuarios.aspx">Usuarios</asp:HyperLink>
            <asp:HyperLink ID="HyperLink16" runat="server" NavigateUrl="~/Admin/ProductoCarrito/ProductosCarrito.aspx">Productos Carrito</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
            <asp:HyperLink ID="HyperLink18" runat="server" NavigateUrl="~/Log_in.aspx">Cerrar sesión</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
        <h2>Gestión de Marcas</h2>
        <div class="acciones-top">
            <asp:TextBox ID="TextBox1" runat="server" placeholder="Buscar categoría..." CssClass="form-control"></asp:TextBox>

            <asp:Button ID="Button1" runat="server" Text="+ Agregar Marca"  PostBackUrl="~/Admin/Marca/AgregarMarca.aspx" CssClass="btn btn-default" />
            <asp:Button ID="Button2" runat="server" Text="Modificar Marca"  PostBackUrl="~/Admin/Marca/ModificarMarca.aspx" CssClass="btn btn-default" />
        </div>

       
                <div class="panel-filtros">

    <h4>Filtros</h4>

    <label>Campo</label>
    <asp:DropDownList ID="ddlCampo" runat="server" CssClass="form-control" />

    <label>Operación</label>
    <asp:DropDownList ID="ddlOperacion" runat="server" CssClass="form-control" />

    <label>Valor</label>
    <asp:TextBox ID="txtValor" runat="server" CssClass="form-control" />

    <label>Valor hasta</label>
    <asp:TextBox ID="txtValorHasta" runat="server" CssClass="form-control" />

    <br />

    <asp:Button ID="btnAgregarFiltro"
        runat="server"
        Text="Agregar filtro"
        CssClass="btn btn-primary"
        OnClick="btnAgregarFiltro_Click" />

    <asp:Button ID="btnBuscar"
        runat="server"
        Text="Buscar"
        CssClass="btn btn-success"
        OnClick="btnBuscar_Click" />

</div>

<table class="table table-striped table-hover tabla-admin">
    <thead>
        <tr>
            <th>ID</th>
            <th>Nombre</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptMarca" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdMarca") %></td>
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

        