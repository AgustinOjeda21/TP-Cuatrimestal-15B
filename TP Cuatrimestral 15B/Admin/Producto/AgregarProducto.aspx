<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Producto.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Producto</title>
    <style>
        .formulario-admin {
        max-width: 600px;
        margin: 30px auto;
        background-color: white;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .formulario-admin label {
        display: block;
        margin-top: 15px;
        margin-bottom: 5px;
        font-weight: bold;
    }

    .campo {
        width: 100%;
        padding: 10px;
        box-sizing: border-box;
    }

    .botones {
        margin-top: 20px;
        display: flex;
        gap: 10px;
    }
    .navbar {
            background-color: brown;
            color: white;
            padding: 30px;
            align-items: center;
            display: flex;
            }
        .selector {
        display: flex;
        gap: 10px;
        margin-bottom: 15px;
    }

    .selector select {
        flex: 1;
    }

    .tablaSeleccion {
        width: 100%;
        border-collapse: collapse;
        margin-bottom: 20px;
    }

    .tablaSeleccion th {
        background-color: brown;
        color: white;
        padding: 8px;
        text-align: left;
    }

    .tablaSeleccion td {
        border: 1px solid #ddd;
        padding: 8px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Producto
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Producto</h2>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />

        <label>Precio</label>
        <asp:TextBox ID="txtPrecio" runat="server" CssClass="campo" />

        <label>Stock</label>
        <asp:TextBox ID="txtStock" runat="server" CssClass="campo" />

        <label>Marca</label>
        <asp:DropDownList ID="ddlMarca" runat="server" CssClass="campo"> </asp:DropDownList>

        <label>Categoria</label>
        <div class="selector">
            <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="campo"> </asp:DropDownList>
            <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar" />
        </div>

        <asp:GridView
            ID="gvCategoriasSeleccionadas"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Categoría" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>

        <label>Imagen</label>
                    <label>Nombre de la imagen</label>
            <asp:TextBox ID="txtNombreImagen"
                runat="server"
                CssClass="campo" />

            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcionImagen"
                runat="server"
                CssClass="campo" />

            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen"
                runat="server"
                CssClass="campo"
                placeholder="https://..."/>

            <asp:Button
                ID="btnAgregarImagen"
                runat="server"
                Text="Agregar Imagen" />

            <br /><br />

            <asp:GridView
                ID="gvImagenes"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="tablaSeleccion">

                <Columns>

                    <asp:ImageField
                        DataImageUrlField="Url"
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
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="campo"> </asp:DropDownList>

            <asp:Button ID="Button1" runat="server" Text="Agregar" />
        </div>

        <asp:GridView
            ID="GridView1"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>

        <label>Descripción</label>
        <asp:TextBox ID="txtDescripcion"
            runat="server"
            CssClass="campo"
            TextMode="MultiLine"
            Rows="4" />

        <div class="botones">
            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar" />

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Producto/Productos.aspx" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
