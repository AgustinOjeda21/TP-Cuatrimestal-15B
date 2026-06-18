<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarDireccion.aspx.cs" Async ="true" Inherits="TP_Cuatrimestral_15B.Admin.Direccion.ModificarDireccion" %>

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
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick ="btnBuscar_Click" CssClass="btn btn-default"/>
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Calle:</label>
            <asp:TextBox ID="txtCalle" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarCalle" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarCalle_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Numero:</label>
            <asp:TextBox ID="txtNumero" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNumero" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarNumero_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Localidad:</label>
            <asp:TextBox ID="txtLocalidad" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnLocalidad" runat="server" Text="Modificar" Enabled="false" OnClick ="btnLocalidad_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Codigo Postal:</label>
            <asp:TextBox ID="txtCodigoPostal" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnCodigoPostal" runat="server" Text="Modificar"  Enabled="false" OnClick ="btnCodigoPostal_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Observaciones:</label>
            <asp:TextBox ID="txtObservaciones" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnObservaciones" runat="server" Text="Modificar"  Enabled="false" OnClick ="btnObservaciones_Click" CssClass="btn btn-default"/>
        </div>

        <div>
            <asp:Button
                ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/Admin/Direccion/Direcciones.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>

