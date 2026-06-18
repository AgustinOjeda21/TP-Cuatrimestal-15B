<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarProducto.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Producto.ModificarProducto" Async="true" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Producto</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Producto
        </div>
        <div class="contenido">

    <h2>Modificar Producto</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" OnClick="btnBuscar_Click" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="fila">
            <label>Precio:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="fila">
            <label>Stock:</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
        </div>

        <div class="fila">
            <label>Marca:</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control campo"> </asp:DropDownList>
        </div>

        
       <div class="fila">
            <label>Categoría:</label>

            <div style="flex:1;">
                <div class="selector">
                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control campo" />
                    <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar" CssClass="btn btn-default" />
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
                CssClass="form-control campo" />
                </div>
            <div class="fila">
            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcionImagen"
                runat="server"
                CssClass="form-control campo" />
                </div>
            <div class="fila">
            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen"
                runat="server"
                CssClass="form-control campo"
                placeholder="https://..."/>
                </div>

            <asp:Button
                ID="btnAgregarImagen"
                runat="server"
                Text="Agregar Imagen" CssClass="btn btn-default" />

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
            <asp:DropDownList ID="DropDownList1" runat="server" CssClass="form-control campo"> </asp:DropDownList>
            <asp:Button ID="Button3" runat="server" Text="Agregar" CssClass="btn btn-default" />
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
            <asp:Button ID="btnGuardar" runat="server" Text="Guardar" CssClass="btn btn-default" OnClick="btnGuardar_Click" />
            <asp:Button ID="btnCancelar" runat="server" Text="Volver" PostBackUrl="~/Admin/Producto/Productos.aspx" CssClass="btn btn-default" />
        </div>
        </div>

    </div>

</div>
    </form>
</body>
</html>
