<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Producto.ModificarProducto" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modificar Producto</title>
    <style>
        .contenido {
    margin: 30px;
    font-family: Arial, sans-serif;
    }

    .buscar {
        display: flex;
        align-items: center;
        gap: 10px;
        margin-bottom: 30px;
        max-width: 600px;
        margin: 30px auto;
        background-color: white;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .buscar input[type="text"] {
        width: 120px;
        padding: 8px;
    }

    .formulario {
        max-width: 600px;
        margin: 30px auto;
        background-color: white;
        padding: 25px;
        border-radius: 8px;
        box-shadow: 0 2px 8px rgba(0,0,0,0.1);
    }

    .fila {
        display: flex;
        align-items: center;
        gap: 15px;
        margin-bottom: 20px;
    }

    .fila label {
        width: 120px;
        font-weight: bold;
    }

    .fila input[type="text"] {
        flex: 1;
        padding: 8px;
    }

    .fila input[type="submit"] {
        width: 100px;
    }
    .navbar {
            background-color: brown;
            color: white;
            padding: 30px;
            align-items: center;
            display: flex;
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
        <div class = "navbar"> Modificar Producto
        </div>
        <div class="contenido">

    <h2>Modificar Producto</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server"></asp:TextBox>
            <asp:Button ID="btnModificarNombre"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Precio:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Stock:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Marca:</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="campo"> </asp:DropDownList>
            <asp:Button ID="Button4"
                runat="server"
                Text="Modificar" />
        </div>

        
       <div class="fila">
            <label>Categoría:</label>

            <div style="flex:1;">
                <div class="selector">
                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="campo" />
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
            </div>
        </div>
        

        <div class="fila">
            <label>Imagen</label>
        </div>
            <div class="fila">
             <label>Nombre de la imagen</label>
            <asp:TextBox ID="txtNombreImagen"
                runat="server"
                CssClass="campo" />
                </div>
            <div class="fila">
            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcionImagen"
                runat="server"
                CssClass="campo" />
                </div>
            <div class="fila">
            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen"
                runat="server"
                CssClass="campo"
                placeholder="https://..."/>
                </div>

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
             
        

        <div class="fila">
            <label>Proveedor:</label>
            <div class="selector">
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="campo"> </asp:DropDownList>
            <asp:Button ID="Button3" runat="server" Text="Agregar" />
        </div>
        
        <div class="fila">
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
        </div>
        

        <div class="fila">
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Producto/Productos.aspx" />
        </div>
        </div>

    </div>

</div>
    </form>
</body>
</html>
