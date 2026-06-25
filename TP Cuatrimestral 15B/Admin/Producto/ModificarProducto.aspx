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
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" Enabled ="false"></asp:TextBox>
            <asp:Button ID="btnNombre" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnNombre_Click" Enabled ="false"/>
        </div>

        <div class="fila">
            <label>Descripción:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control" Enabled ="false"></asp:TextBox>
            <asp:Button ID="btnDescripcion" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnDescripcion_Click" Enabled ="false"/>
        </div>

        <div class="fila">
            <label>Precio:</label>
            <asp:TextBox ID="txtPrecio" runat="server" CssClass="form-control" Enabled ="false"></asp:TextBox>
            <asp:Button ID="btnPrecio" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnPrecio_Click" Enabled ="false"/>
        </div>

        <div class="fila">
            <label>Stock:</label>
            <asp:TextBox ID="txtStock" runat="server" CssClass="form-control" Enabled ="false"></asp:TextBox>
            <asp:Button ID="btnStock" runat="server" Text="Modificar" CssClass="btn btn-default" OnClick="btnStock_Click" Enabled ="false"/>
        </div>

        <div class="fila">
            <label>Marca:</label>
            <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-control campo" Enabled ="false"> </asp:DropDownList>
            <asp:Button ID="btnMarca" runat="server" Text="Modificar" CssClass="btn btn-default"  Enabled ="false" OnClick="btnMarca_Click"/>
        </div>

        
       <div class="fila">
            <label>Categoría:</label>

            <div style="flex:1;">
                <div class="selector">
                    <asp:DropDownList ID="ddlCategorias" runat="server" CssClass="form-control campo" Enabled ="false"/>
                    <asp:Button ID="btnAgregarCategoria" runat="server" Text="Agregar" CssClass="btn btn-default" OnClick="btnAgregarCategoria_Click" Enabled ="false" />
                </div>

                <asp:GridView
                    ID="gvCategoriasSeleccionadas"
                    runat="server"
                    AutoGenerateColumns="False"
                    CssClass="tablaSeleccion"
                    OnRowCommand = "gvCategoriasSeleccionadas_RowCommand">
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
             <asp:TextBox ID="txtNombreImagen" runat="server" CssClass="form-control campo"  Enabled ="false"/>
            </div>
            <div class="fila">
            <label>Descripción</label>
            <asp:TextBox ID="txtDescripcionImagen" runat="server" CssClass="form-control campo" Enabled ="false" />
            </div>
            <div class="fila">
            <label>URL</label>
            <asp:TextBox ID="txtUrlImagen" runat="server" CssClass="form-control campo" Enabled ="false" placeholder="https://..."/>
            </div>

            <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar Imagen" CssClass="btn btn-default" OnClick="btnAgregarImagen_Click" Enabled ="false"/>

            <br /><br />

            <asp:GridView
                ID="gvImagenes"
                runat="server"
                AutoGenerateColumns="False"
                CssClass="tablaSeleccion"
                OnRowCommand = "gvImagenes_RowCommand">

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
            <asp:DropDownList ID="ddlProveedor" runat="server" CssClass="form-control campo"> </asp:DropDownList>
            <asp:Button ID="btnAgregarProveedor" runat="server" Text="Agregar" CssClass="btn btn-default" OnClick="btnAgregarProveedor_Click" Enabled ="false"/>
        </div>
        
        <div class="fila">
        <asp:GridView
            ID="gvProveedores"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion"
            OnRowCommand = "gvProveedores_RowCommand">
            <Columns>
                <asp:BoundField DataField="Nombre" HeaderText="Proveedor" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>
        </div>
        

        <div class="fila">
            <asp:Button ID="btnCancelar" runat="server" Text="Volver" PostBackUrl="~/Admin/Producto/Productos.aspx" CssClass="btn btn-default" />
        </div>
        </div>

    </div>

</div>
    </form>
</body>
</html>
