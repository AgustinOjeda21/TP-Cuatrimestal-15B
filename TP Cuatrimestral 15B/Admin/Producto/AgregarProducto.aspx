<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Producto.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Agregar Producto</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Producto
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Producto</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false"></asp:Label>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" />

        <label>Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control campo" />

        <label>Stock</label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="form-control campo" />

        <label>Marca</label>
        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control campo"> </asp:DropDownList>

        <label>Categoría</label>
        <div class="selector">
            <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control campo"> </asp:DropDownList>
            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar" OnClick="btnAgregarCategoria_Click" CssClass="btn btn-default" />
        </div>

        <asp:GridView
            ID="gvCategorias"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion"
            OnRowCommand="gvCategorias_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Categoría" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>

        <label>Imagen</label>
                    <label>Nombre de la imagen</label>
            <asp:TextBox ID="txtNombreImagen"
                runat="server"
                CssClass="form-control campo" />

            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcionImagen"
                runat="server"
                CssClass="form-control campo" />

            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen"
                runat="server"
                CssClass="form-control campo"
                placeholder="https://..."/>

            <asp:Button
                ID="btnAgregarImagen"
                runat="server"
                Text="Agregar Imagen" 
                OnClick="btnAgregarImagen_Click" CssClass="btn btn-default" />

            <br /><br />

            <asp:GridView
                ID="gvImagenes"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="tablaSeleccion"
                OnRowCommand="gvImagenes_RowCommand">

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

        <label>Proveedor</label>
        <div class="selector">
            <asp:DropDownList ID="ddlProveedores" runat="server" CssClass="form-control campo"> </asp:DropDownList>

            <asp:Button ID="btnAgregarProveedor" runat="server" Text="Agregar" OnClick="btnAgregarProveedor_Click" CssClass="btn btn-default" />
        </div>

        <asp:GridView
            ID="gvProveedores"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion"
            OnRowCommand="gvProveedores_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>

        <label>Descripción</label>
        <asp:TextBox ID="txtDescripcion"
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
                PostBackUrl="~/Admin/Producto/Productos.aspx" CssClass="btn btn-default" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
