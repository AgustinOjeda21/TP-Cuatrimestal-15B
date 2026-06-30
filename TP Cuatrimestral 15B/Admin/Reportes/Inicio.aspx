<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Reportes.Inicio"  Async="true"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes - Dashboard</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
<form id="form2" runat="server">
    <div class="navbar">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Inicio.aspx" CssClass="Titulo">Panel Admin</asp:HyperLink>
        <div class="nav-links">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Reportes/Clientes.aspx">Clientes</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Reportes/Ventas.aspx">Ventas</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Reportes/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Reportes/Productos.aspx">Productos</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
        </div>
    </div>
        <div class="contenido">

    <h2>Dashboard</h2>

    <div class="cards">

        <div class="card">
            <h3>Ventas Totales</h3>
            <p><asp:Label ID="lblVentas" runat="server" /></p>
        </div>

        <div class="card">
            <h3>Pedidos</h3>
            <p><asp:Label ID="lblPedidos" runat="server" /></p>
        </div>

        <div class="card">
            <h3>Clientes</h3>
            <p><asp:Label ID="lblClientes" runat="server" /></p>
        </div>

        <div class="card">
            <h3>Ticket Promedio</h3>
            <p><asp:Label ID="lblTicket" runat="server" /></p>
        </div>

    </div>

    <div class="cards">

        <div class="card">
            <h3>Top 5 Productos</h3>

            <asp:Repeater ID="rptTopProductos" runat="server">
                <ItemTemplate>
                    <div class="filaDashboard">
                        <span><%# Container.ItemIndex + 1 %>. <%# Eval("Producto") %></span>
                        <strong><%# Eval("TotalVendido") %></strong>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="card">
            <h3>Top 5 Clientes</h3>

            <asp:Repeater ID="rptTopClientes" runat="server">
                <ItemTemplate>
                    <div class="filaDashboard">
                        <span><%# Container.ItemIndex + 1 %>. <%# Eval("Cliente") %></span>
                        <strong>$ <%# Eval("TotalIngresado") %></strong>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="card">
            <h3>Formas de pago</h3>

            <asp:Repeater ID="rptFormasPago" runat="server">
                <ItemTemplate>
                    <div class="filaDashboard">
                        <span><%# Eval("FormaPago") %></span>
                        <strong><%# Eval("CantidadPedidos") %></strong>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

        <div class="card">
            <h3>Formas de entrega</h3>

            <asp:Repeater ID="rptFormasEntrega" runat="server">
                <ItemTemplate>
                    <div class="filaDashboard">
                        <span><%# Eval("FormaEntrega") %></span>
                        <strong><%# Eval("CantidadPedidos") %></strong>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
        </div>

    </div>

    <div class="cards">

        <div class="card estadoCard pagado">
            <h3>Pagados</h3>
            <p><asp:Label ID="lblPagados" runat="server" /></p>
        </div>

        <div class="card estadoCard confirmado">
            <h3>Confirmados</h3>
            <p><asp:Label ID="lblConfirmados" runat="server" /></p>
        </div>

        <div class="card estadoCard entregado">
            <h3>Entregados</h3>
            <p><asp:Label ID="lblEntregados" runat="server" /></p>
        </div>

        <div class="card estadoCard cancelado">
            <h3>Cancelados</h3>
            <p><asp:Label ID="lblCancelados" runat="server" /></p>
        </div>

    </div>

</div>
    </form>
</body>
</html>
