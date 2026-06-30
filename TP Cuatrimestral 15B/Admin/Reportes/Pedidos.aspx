<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Pedidos.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Reportes.Pedidos" Async="true" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes - Pedidos</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
<form id="form2" runat="server">
    <div class="navbar">
        <asp:HyperLink ID="HyperLink1" runat="server" NavigateUrl="~/Admin/Inicio.aspx" CssClass="Titulo">Panel Admin</asp:HyperLink>
        <div class="nav-links">
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Reportes/Inicio.aspx">Dashboards</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Reportes/Ventas.aspx">Ventas</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Reportes/Clientes.aspx">Clientes</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Reportes/Productos.aspx">Productos</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
    <h2>Reportes de pedidos</h2>
        
    <div class="panel-filtros">
    <h4>Filtros</h4>
    <div class="row align-items-end">

    <div class="col-md-3">
        <label>Desde</label>
        <asp:TextBox
            ID="txtDesde"
            runat="server"
            TextMode="Date"
            CssClass="form-control" />
    </div>

    <div class="col-md-3">
        <label>Hasta</label>
        <asp:TextBox
            ID="txtHasta"
            runat="server"
            TextMode="Date"
            CssClass="form-control" />
    </div>

    <div class="col-md-3">
    <label>Estado</label>
    <asp:DropDownList ID="ddlEstado"
        runat="server"
        CssClass="form-control"/>
    </div>

    <div class="col-md-3">
    <label>Forma de pago</label>
    <asp:DropDownList ID="ddlFormaPago"
        runat="server"
        CssClass="form-control"/>
    </div>

    <div class="col-md-3">
    <label>Forma de entrega</label>
    <asp:DropDownList ID="ddlFormaEntrega"
        runat="server"
        CssClass="form-control"/>
    </div>

    <div class="col-md-3">
        <label>Ordenar por</label>
    <asp:DropDownList ID="ddlAgrupacion" runat="server" CssClass="form-control">
        <asp:ListItem Text="Fecha más reciente" Value="FechaReciente" />
        <asp:ListItem Text="Fecha más antigua" Value="FechaAntigua" />
        <asp:ListItem Text="Importe mayor" Value="ImporteMayor" />
        <asp:ListItem Text="Importe menor" Value="ImporteMenor" />
        <asp:ListItem Text="Nombre Cliente" Value="Cliente" />
    </asp:DropDownList>
    </div>

    <div class="col-md-3">
    <asp:Button ID="btnGenerarReporte"
        runat="server"
        Text="Generar Reporte"
        CssClass="btn btn-primary"
        OnClick ="btnGenerar_Click"/>
    </div>
    </div>
    </div>

        
  <div class="row mt-4">

    <div class="col-md-3">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de Pedidos Cancelados</h6>
                <h3>
                    <asp:Label ID="lblCancelados" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-3">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de Pedidos Pagados</h6>
                <h3>
                    <asp:Label ID="lblPagados" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-3">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de Pedidos Entregados</h6>
                <h3>
                    <asp:Label ID="lblEntregados" runat="server" />
                </h3>
            </div>
        </div>
    </div>
      <div class="col-md-3">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de Pedidos Confirmados</h6>
                <h3>
                    <asp:Label ID="lblConfirmados" runat="server" />
                </h3>
            </div>
        </div>
    </div>
</div>

<table class="table table-striped table-hover tabla-admin">
    <thead>
        <tr>
            <th>ID Pedido</th>
            <th>Cliente</th>
            <th>Estado</th>
            <th>Forma Pago</th>
            <th>Forma Entrega</th>
            <th>Importe Total</th>
            <th>Fecha Pedido</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptPedido" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("IdPedido") %></td>
                    <td><%# Eval("Cliente") %></td>
                    <td><%# Eval("Estado") %></td>
                    <td><%# Eval("FormaPago") %></td>
                    <td><%# Eval("FormaEntrega") %></td>
                    <td><%# Eval("Importe") %></td>
                    <td><%# Eval("FechaPedido") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

</form>
</body>
</html>

