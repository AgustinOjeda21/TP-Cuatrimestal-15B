<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Productos.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Reportes.Productos" Async="true" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes - Productos</title>
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
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Reportes/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Reportes/Clientes.aspx">Clientes</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
    <h2>Reportes de productos</h2>
        
    <div class="panel-filtros">
    <h4>Filtros</h4>
    <div class="row g-4 align-items-end">

    <div class="col-md-4">
    <label>Ordenar por</label>
    <asp:DropDownList ID="ddlAgrupacion" runat="server" CssClass="form-control">
        <asp:ListItem Text="Mas vendidos" Value="MayorCantidadVendida" />
        <asp:ListItem Text="Menos vendidos" Value="MenorCantidadVendida" />
        <asp:ListItem Text="Mayor Facturacion" Value="MayorFacturacion" />
        <asp:ListItem Text="Menor Facturacion" Value="MenorFacturacion" />
        <asp:ListItem Text="Mayor Stock" Value="MayorStock" />
        <asp:ListItem Text="Menor Stock" Value="MenorStock" />
        <asp:ListItem Text="Nombre" Value="Nombre" />
    </asp:DropDownList>
    </div>

    <div class="col-md-4">
        <label>Marca</label>
        <asp:DropDownList ID="ddlMarca"
            runat="server"
            CssClass="form-control"/>
    </div>

    <div class="col-12 text-end">
        <asp:Button
            ID="btnGenerarReporte"
            runat="server"
            Text="Generar Reporte"
            CssClass="btn btn-primary"
            OnClick ="btnGenerar_Click"/>
    </div>
  </div>

</div>

  <div class="row mt-4">

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de productos vendidos</h6>
                <h3>
                    <asp:Label ID="lblTotal" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Facturacion total</h6>
                <h3>
                    <asp:Label ID="lblFacturacion" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Producto mas vendido</h6>
                <h3>
                    <asp:Label ID="lblProducto" runat="server" />
                </h3>
            </div>
        </div>
    </div>

</div>

<table class="table table-striped table-hover tabla-admin">
    <thead>
        <tr>
            <th>Producto</th>
            <th>Total Pedidos</th>
            <th>Total ingresado</th>
            <th>Stock</th>
            <th>Marca</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptProductos" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Producto") %></td>
                    <td><%# Eval("TotalVendido") %></td>
                    <td><%# Eval("TotalIngresado") %></td>
                    <td><%# Eval("Stock") %></td>
                    <td><%# Eval("Marca") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

</form>
</body>
</html>
