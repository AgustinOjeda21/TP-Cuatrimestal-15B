<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarDireccion.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Direccion.ModificarDireccion" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Dirección</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Categoría
        </div>
        <div class="contenido">

    <h2>Modificar Dirección</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Calle:</label>
            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarCalle"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Número:</label>
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNumero"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Localidad:</label>
            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnLocalidad"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Código Postal:</label>
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnCodigoPostal"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Observaciones:</label>
            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnObservaciones"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div>
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Direccion/Direcciones.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>

