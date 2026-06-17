<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarCategoria.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Categoria.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Agregar Categoría</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Categoría
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Categoría</h2>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" />

        <label>Descripción</label>
        <asp:TextBox ID="txtDescripcion"
            runat="server"
            CssClass="form-control campo"
            TextMode="MultiLine"
            Rows="4" />

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false"></asp:Label>

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
                PostBackUrl="~/Admin/Categoria/Categorias.aspx" CssClass="btn btn-default" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
