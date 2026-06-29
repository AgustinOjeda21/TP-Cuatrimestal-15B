<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MisDirecciones.aspx.cs" Inherits="TP_Cuatrimestral_15B.Usuario.WebForm4" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Mis Direcciones</title>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form4" runat="server">
        <div class =" navbar">Mis Direcciones
        </div>
        <h1>Mis Direcciones</h1>

         <asp:Repeater ID="rptDirecciones" runat="server" OnItemCommand="rptDirecciones_ItemCommand">
            <ItemTemplate>

                <div class="compra">

                    <div class="row">

                        <div class="col-md-9">
                            <h3>#<%# Eval("Observaciones") %></h3>

                            <p>
                                <strong>Calle:</strong>
                                <%# Eval("Calle") %>
                            </p>

                            <p>
                                <strong>Numero:</strong>
                                <%# Eval("Numero") %>
                            </p>

                            <p>
                                <strong>Localidad:</strong>
                                <%# Eval("Localidad") %>
                            </p>
                            <p>
                                <strong>Codigo Postal:</strong>
                                <%# Eval("CodigoPostal") %>
                            </p>
                        </div>

                        <div class="col-md-3 text-right">
                            <asp:Button
                                runat="server"
                                CommandName="Modificar"
                                Text ="Modificar"
                                CssClass="btn btn-primary"
                                CommandArgument='<%# Eval("IdDireccion") %>' />
                        </div>

                        <div class="col-md-3 text-right">
                            <asp:Button
                                runat="server"
                                CommandName="Eliminar"
                                Text ="Eliminar"
                                CssClass="btn btn-primary"
                                CommandArgument='<%# Eval("IdDireccion") %>' />
                        </div>

                    </div>

                </div>

            </ItemTemplate>
        </asp:Repeater>
        <div class="text-center mt-4">
        <asp:Button ID="btnVolver"
            runat="server"
            Text="Volver"
            PostBackUrl="~/Usuario/MisCompras.aspx"
            CssClass="btn btn-secondary mx-2" />
        </div>
    </form>
</body>
</html>
