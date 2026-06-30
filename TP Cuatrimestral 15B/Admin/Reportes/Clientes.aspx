<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Clientes.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Reportes.Clientes" async="true"%>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <meta charset="utf-8" />
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Reportes - Clientes</title>
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
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Reportes/Productos.aspx">Productos</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
        </div>
    </div>
    <div class="contenido">
    <h2>Reportes de clientes</h2>
        
    <div class="panel-filtros">
    <h4>Filtros</h4>
    <div class="row align-items-end">
    <div class="col-md-3">
    <label>Desde</label>
    <asp:TextBox
        ID="txtDesde"
        runat="server"
        TextMode="Date" 
        CssClass="form-control"/>
    </div>
    <div class="col-md-3">
    <label>Hasta</label>
        <asp:TextBox
        ID="txtHasta"
        runat="server"
        TextMode="Date" 
        CssClass="form-control"/>
    </div>

    <div class="col-md-3">
    <label>Ordenar por</label>
    <asp:DropDownList ID="ddlAgrupacion" runat="server" CssClass="form-control">
        <asp:ListItem Text="Mayor cantidad vendida" Value="MayorCantidadVendida" />
        <asp:ListItem Text="Menor cantidad vendida" Value="MenorCantidadVendida" />
        <asp:ListItem Text="Mayor Facturacion" Value="MayorFacturacion" />
        <asp:ListItem Text="Menor Facturacion" Value="MenorFacturacion" />
        <asp:ListItem Text="Nombre" Value="Nombre" />
    </asp:DropDownList>
    </div>

    <div class="col-md-3">
    <asp:Button ID="btnGenerarReporte"
        runat="server"
        Text="Generar Reporte"
        CssClass="btn btn-primary w-100"
        OnClick ="btnGenerar_Click"/>
    </div>
    </div>
        
  <div class="row mt-4">

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad total de clientes compradores</h6>
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
                <h6 class="text-muted">Cliente con mayor gasto</h6>
                <h3>
                    <asp:Label ID="lblCliente" runat="server" />
                </h3>
            </div>
        </div>
    </div>
      </div>
</div>

<table class="table table-striped table-hover tabla-admin">
    <thead>
        <tr>
            <th>Cliente</th>
            <th>Cantidad pedidos</th>
            <th>Total gastado</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptCliente" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Cliente") %></td>
                    <td><%# Eval("CantidadPedidos") %></td>
                    <td><%# Eval("TotalIngresado") %></td>
                </tr>
            </ItemTemplate>
        </asp:Repeater>
    </tbody>
</table>

</form>
</body>
</html>

