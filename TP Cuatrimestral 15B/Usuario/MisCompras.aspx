<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisCompras.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm2" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mis Compras</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form3" runat="server">
        <div class ="navbar"></div>
        <h1>Mis Compras</h1>
        <asp:Repeater ID="rptPedidos" runat="server" OnItemCommand="rptPedidos_ItemCommand">
            <ItemTemplate>

                <div class="compra">

                    <div class="row">

                        <div class="col-md-9">
                            <h3>Pedido #<%# Eval("IdPedido") %></h3>

                            <p>
                                <strong>Fecha:</strong>
                                <%# Convert.ToDateTime(Eval("DetallePedido.FechaPedido")).ToString("dd/MM/yyyy") %>
                            </p>

                            <p>
                                <strong>Estado:</strong>
                                <%# Eval("EstadoPedido.Nombre") %>
                            </p>

                            <p>
                                <strong>Total:</strong>
                                $ <%# Eval("Carrito.Total") %>
                            </p>
                        </div>

                        <div class="col-md-3 text-right">
                            <asp:Button
                                runat="server"
                                CommandName="Detalle"
                                Text ="Ver Detalle"
                                CssClass="btn btn-primary"
                                CommandArgument='<%# Eval("IdPedido") %>' />
                        </div>

                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>

        <div class="text-center mt-4">
        <asp:Button ID="btnVolver"
        runat="server"
        Text="Volver"
        PostBackUrl="~/Usuario/MiPerfil.aspx"
        CssClass="btn btn-secondary mx-2" />
        </div>

    </form>
</body>
</html>
