<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarProveedor.aspx.cs" Async = "true" Inherits="TP_Cuatrimestral_15B.Admin.Proveedor.ModificarProveedor" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Proveedor</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Proveedor
        </div>
        <div class="contenido">

    <h2>Modificar Proveedor</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" OnClick ="btnBuscar_Click" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled ="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnModificarNombre_Click"/>
        </div>

        <div class="fila">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" Enabled ="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarTelefono" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnModificarTelefono_Click"/>
        </div>

        <div class="fila">
            <label>Mail:</label>
            <asp:TextBox ID="txtMail" runat="server" Enabled ="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarMail" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnModificarMail_Click"/>
        </div>

        <div class="fila">
        <h2>Dirección</h2>
        </div>
        
        <div class="fila">
        <label>Calle</label>
        <asp:TextBox ID="txtCalle" runat="server" Enabled ="false" CssClass="form-control campo" />
        <asp:Button ID="btnModificarCalle" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnModificarCalle_Click" />
        </div>

        <div class="fila">
        <label>Número</label>
        <asp:TextBox ID="txtNumero" runat="server" Enabled ="false" CssClass="form-control campo" />
        <asp:Button ID="btnModificarNumero" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnModificarNumero_Click"/>
        </div>

        <div class="fila">
        <label>Localidad</label>
        <asp:TextBox ID="txtLocalidad" runat="server" Enabled ="false" CssClass="form-control campo" />
        <asp:Button ID="btnLocalidad" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnLocalidad_Click"/>
        </div>

        <div class="fila">
        <label>Código Postal</label>
        <asp:TextBox ID="txtCodigoPostal" runat="server" Enabled ="false" CssClass="form-control campo" />
        <asp:Button ID="btnCodigoPostal" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnCodigoPostal_Click" />
        </div>

        <div class="fila">
        <label>Observaciones</label> <asp:TextBox ID="txtObservaciones" Enabled ="false"  runat="server" CssClass="form-control campo" TextMode="MultiLine" Rows="4" />
        <asp:Button ID="btnObservaciones" runat="server" Text="Modificar" Enabled ="false" CssClass="btn btn-default" OnClick ="btnObservaciones_Click" />
        </div>

        <div>
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Proveedor/Proveedores.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
