<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.AdminInicio" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <title>Admin - Inicio</title>
    <style>
        body { font-family: Arial, sans-serif; margin: 0; padding: 0; background-color: #f9f9f9; }
        .navbar { background-color: brown; color: white; padding: 15px 30px; display: flex; align-items: center; gap: 20px; flex-wrap: wrap; }
        .navbar a { color: white; text-decoration: none; font-size: 14px; }
        .Titulo { font-size: 22px; font-weight: bold; }
        .nav-links { display: flex; gap: 20px; }
        .nav-right { margin-left: auto; display: flex; gap: 15px; align-items: center; }
        .contenido { margin: 30px; }
        h2 { color: #333; margin-bottom: 25px; }
        .cards { display: flex; gap: 20px; flex-wrap: wrap; }
        .card { background: white; border-radius: 10px; padding: 25px 30px; box-shadow: 0 2px 8px rgba(0,0,0,0.1); text-decoration: none; color: #333; min-width: 180px; text-align: center; transition: box-shadow 0.2s; }
        .card:hover { box-shadow: 0 4px 16px rgba(0,0,0,0.18); }
        .card h3 { margin: 0 0 8px 0; font-size: 18px; color: brown; }
        .card p { margin: 0; font-size: 13px; color: #888; }
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
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="linkTienda" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
            <asp:HyperLink ID="linkCerrarSesion" runat="server" NavigateUrl="~/Log_in.aspx">Cerrar sesión</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
        <h2>Bienvenido al Panel de Administración</h2>
        <div class="cards">
            <a href="Productos.aspx" class="card"><h3>Productos</h3><p>Gestionar catálogo</p></a>
            <a href="Categorias.aspx" class="card"><h3>Categorías</h3><p>Gestionar categorías</p></a>
            <a href="FormasPago.aspx" class="card"><h3>Formas de Pago</h3><p>Gestionar pagos</p></a>
            <a href="FormasEntrega.aspx" class="card"><h3>Formas de Entrega</h3><p>Gestionar entregas</p></a>
            <a href="Pedidos.aspx" class="card"><h3>Pedidos</h3><p>Ver y gestionar pedidos</p></a>
        </div>
    </div>
</form>
</body>
</html>

