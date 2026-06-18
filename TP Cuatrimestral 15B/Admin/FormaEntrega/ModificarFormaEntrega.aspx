<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarFormaEntrega.aspx.cs" Async ="true" Inherits="TP_Cuatrimestral_15B.Admin.FormaEntrega.ModificarFormaEntrega" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Forma Entrega</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Forma Entrega
        </div>
        <div class="contenido">

    <h2>Modificar Forma Entrega</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" OnClick ="btnBuscar_Click" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarNombre_Click" CssClass="btn btn-default"/>
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion" runat="server" Text="Modificar" Enabled="false" OnClick ="btnModificarDescripcion_Click" CssClass="btn btn-default"/>
        </div>

        <div>
            <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" PostBackUrl="~/Admin/FormaEntrega/FormasEntrega.aspx"  CssClass="btn btn-default"/>
        </div>

    </div>

</div>
    </form>
</body>
</html>
