<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Marca.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Agregar Marca</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Marca
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Marca</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false"></asp:Label>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" />

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

                    <asp:TemplateField HeaderText="Vista">
                        <ItemTemplate>
                            <img src='<%# Eval("URL") %>' width="80" height="80" />
                        </ItemTemplate>
                    </asp:TemplateField>


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
                PostBackUrl="~/Admin/Marca/Marcas.aspx" CssClass="btn btn-default" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
