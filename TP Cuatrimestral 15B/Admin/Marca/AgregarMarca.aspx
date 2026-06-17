<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarMarca.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Marca.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Marca</title>
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
    .tablaSeleccion {
        width: 100%;
        border-collapse: collapse;
        margin-top: 20px;
    }

    .tablaSeleccion th {
        background-color: brown;
        color: white;
        padding: 10px;
    }

    .tablaSeleccion td {
        border: 1px solid #ddd;
        padding: 10px;
        vertical-align: middle;
    }

    .tablaSeleccion img {
        border-radius: 5px;
        object-fit: cover;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Marca
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Marca</h2>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />

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
                Text="Agregar Imagen"
                OnClick="btnAgregarImagen_Click"/>

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
                OnClick="btnGuardar_Click"/>

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Marca/Marcas.aspx" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
