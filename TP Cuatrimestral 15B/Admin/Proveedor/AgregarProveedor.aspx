<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProveedor.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Proveedor.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Agregar Proveedor</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Proveedor
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Proveedor</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false"></asp:Label>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" />

        <label>Teléfono</label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control campo" />

        <label>Mail</label>
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control campo" />

        <h2>Agregar Dirección</h2>

        <label>Calle</label>
        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control campo" />

        <label>Número</label>
        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control campo" />

        <label>Localidad</label>
        <asp:TextBox ID="txtLocalida" runat="server" CssClass="form-control campo" />

        <label>Código Postal</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control campo" />

        <label>Observaciones</label>
        <asp:TextBox ID="txtObservacion"
            runat="server"
            CssClass="form-control campo"
            TextMode="MultiLine"
            Rows="4" />

                <div class="botones">
            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar" 
                OnClick="btnGuardar_Click" CssClass="btn btn-default" />

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
