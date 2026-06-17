<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarImagen.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Imagen.ModificarImagen" %>

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
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>URL:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button1"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="vistaPrevia">
            <label>Vista previa:</label>
            <asp:Image
                ID="imgVistaPrevia"
                runat="server"
                Width="300px"
                Height="300px"
                ImageUrl="https://via.placeholder.com/300x300?text=Sin+Imagen" />
        </div>

        <div>
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Imagen/Imagenes.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
