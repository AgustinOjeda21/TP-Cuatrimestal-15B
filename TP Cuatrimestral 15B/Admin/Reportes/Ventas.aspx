<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Ventas.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Reportes.Ventas" async="true"%>

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
            <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="~/Admin/Reportes/Inicio.aspx">Inicio</asp:HyperLink>
            <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Admin/Reportes/Productos.aspx">Productos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Admin/Reportes/Pedidos.aspx">Pedidos</asp:HyperLink>
            <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Admin/Reportes/Clientes.aspx">Clientes</asp:HyperLink>
        </div>
        <div class="nav-right">
            <asp:HyperLink ID="HyperLink17" runat="server" NavigateUrl="~/Inicio.aspx">Ver Tienda</asp:HyperLink>
        </div>
    </div>
    <h2>Reportes de ventas</h2>
        
    <div class="panel-filtros">
    <h4>Filtros</h4>
    <div class="row align-items-end">
    <div class="col-md-4">
    <label>Desde</label>
    <asp:TextBox
        ID="txtDesde"
        runat="server"
        CssClass="form-control"
        TextMode="Date" />
    </div>

    <div class="col-md-4">
    <label>Hasta</label>
        <asp:TextBox
        ID="txtHasta"
        runat="server"
        CssClass="form-control"
        TextMode="Date" />
    </div>

    <div class="col-md-4">
    <label>Agrupar por</label>
    <asp:DropDownList ID="ddlAgrupacion" runat="server" CssClass="form-control">
        <asp:ListItem Text="Por día" Value="Dia" />
        <asp:ListItem Text="Por mes" Value="Mes" />
        <asp:ListItem Text="Por año" Value="Anio" />
    </asp:DropDownList>
    </div>

     <div class="col-md-4">
    <label>Agrupar por</label>
    <asp:DropDownList ID="ddlOrdenar" runat="server" CssClass="form-control">
        <asp:ListItem Text="Mas Recientes" Value="Recientes" />
        <asp:ListItem Text="Mas Viejos" Value="Viejos" />
        <asp:ListItem Text="Mayor cantidad vendida" Value="MayorCantidad" />
        <asp:ListItem Text="Menor cantidad vendida" Value="MenorCantidad" />
        <asp:ListItem Text="Mayor facturacion" Value="MayorFacturacion" />
        <asp:ListItem Text="Menor facturacion" Value="MenorFacturacion" />
    </asp:DropDownList>
    </div>
    </div>

    <div class="col-md-4">
    <asp:Button ID="btnGenerarReporte"
        runat="server"
        Text="Generar Reporte"
        CssClass="btn btn-primary"
        OnClick ="btnGenerar_Click"/>
    </div>
</div>
    <div class="row mt-4">

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Total ingresado</h6>
                <h3>
                    <asp:Label ID="lblTotal" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Cantidad de pedidos</h6>
                <h3>
                    <asp:Label ID="lblPedidos" runat="server" />
                </h3>
            </div>
        </div>
    </div>

    <div class="col-md-4">
        <div class="card shadow-sm">
            <div class="card-body">
                <h6 class="text-muted">Ticket promedio</h6>
                <h3>
                    <asp:Label ID="lblPromedio" runat="server" />
                </h3>
            </div>
        </div>
    </div>

</div>


<table class="table table-striped table-hover tabla-admin">
    <thead>
        <tr>
            <th>Fecha</th>
            <th>Cantidad vendida</th>
            <th>Total ingresado</th>
        </tr>
    </thead>
    <tbody>
        <asp:Repeater ID="rptVentas" runat="server">
            <ItemTemplate>
                <tr>
                    <td><%# Eval("Fecha") %></td>
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

