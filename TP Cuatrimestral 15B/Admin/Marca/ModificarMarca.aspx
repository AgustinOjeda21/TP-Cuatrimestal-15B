<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarMarca.aspx.cs" Async ="true" Inherits="TP_Cuatrimestral_15B.Admin.Marca.ModificarMarca" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Marca</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Marca
        </div>
        <div class="contenido">

    <h2>Modificar Marca</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" OnClick ="btnBuscar_Click" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled="false" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre" runat="server" Text="Modificar" Enabled="false" CssClass="btn btn-default" OnClick ="btnModificarNombre_Click" />
        </div>

        <div class="fila">
            <label>Agregar Imagen:</label>
            <label>Nombre de la imagen</label>
            <asp:TextBox ID="txtNombreImagen" runat="server" Enabled="false" CssClass="form-control campo" />
        </div>

        <div class="fila"> 
        <label>Descripción</label> 
        <asp:TextBox ID="txtDescripcionImagen" runat="server" Enabled="false" CssClass="form-control campo" />
        </div>

        <div class="fila">
            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen" runat="server" Enabled="false" CssClass="form-control campo" placeholder="https://..."/>

        <div class="fila">
            <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" Enabled="false" CssClass="btn btn-default" OnClick ="btnAgregarImagen_Click" />
        </div>

            <br /><br />

            <asp:GridView
                ID="gvImagenes"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="tablaSeleccion"
                OnRowCommand = "gvImagenes_RowCommand">

                <Columns>

                    <asp:ImageField
                        DataImageUrlField="URL"
                        HeaderText="Vista"
                        ControlStyle-Width="80"
                        ControlStyle-Height="80" />

                    <asp:BoundField
                        DataField="Nombre"
                        HeaderText="Nombre" />

                    <asp:BoundField
                        DataField="Descripcion"
                        HeaderText="Descripción" />

                    <asp:BoundField
                        DataField="Url"
                        HeaderText="URL" />

                    <asp:ButtonField Text="Quitar" CommandName="Quitar" />

                </Columns>

            </asp:GridView>
        </div>

        <div class ="fila">
            <asp:Button ID="Button1" runat="server" Text="Cancelar" PostBackUrl="~/Admin/Marca/Marcas.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
