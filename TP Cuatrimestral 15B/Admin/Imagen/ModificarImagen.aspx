<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarImagen.aspx.cs" Async = "true" Inherits="TP_Cuatrimestral_15B.Admin.Imagen.ModificarImagen" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Imagen</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Imagen
        </div>
        <div class="contenido">

    <h2>Modificar Imagen</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass ="form-control" ></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick ="btnBuscar_Click" CssClass="btn btn-default"/>
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass ="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre" runat="server" Text="Modificar"  Enabled="false" OnClick ="btnModificarNombre_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" Enabled="false" CssClass ="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarDescripcion_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>URL:</label>
            <asp:TextBox ID="txtUrl" runat="server" Enabled="false" CssClass ="form-control"></asp:TextBox>
            <asp:Button ID="ModificarUrl" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarUrl_Click" CssClass="btn btn-default"/>
        </div>

        <div class="vistaPrevia">
            <label>Vista previa:</label>
            <asp:Image
                ID="imgVistaPrevia"
                runat="server"
                Width="300px"
                Height="300px"/>
        </div>

        <div>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/Admin/Imagen/Imagenes.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
