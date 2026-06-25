<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPersona.aspx.cs" Async = "true" Inherits="TP_Cuatrimestral_15B.Admin.Persona.ModificarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Modificar Persona</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Persona
        </div>
        <div class="contenido">

    <h2>Modificar Persona</h2>

    <div class="buscar">
        <label>ID:</label>
        <asp:TextBox ID="txtIdBuscar" runat="server" CssClass="form-control"></asp:TextBox>
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" OnClick ="btnBuscar_Click" />
    </div>

    <div class="formulario">

        <div class="fila"> 
        <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" Enabled = "true"  CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre" runat="server" Text="Modificar" Enabled = "false"  CssClass="btn btn-default" OnClick ="btnModificarNombre_Click" />
        </div>

        <div class="fila"> 
        <label>Apellido:</label>
            <asp:TextBox ID="txtApellido" runat="server" Enabled = "true"  CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarApellido" runat="server" Text="Modificar" Enabled = "false"  CssClass="btn btn-default" OnClick ="btnModificarApellido_Click"/>
        </div>

        <div class="fila">
            <label>Mail:</label>
            <asp:TextBox ID="txtMail" runat="server" Enabled = "true"  CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarMail" runat="server" Text="Modificar" Enabled = "false"  CssClass="btn btn-default" OnClick ="btnModificarMail_Click"/>
        </div>

        <div class="fila">
            <label>Teléfono:</label>
            <asp:TextBox ID="txtTelefono" runat="server" Enabled = "true"  CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarTelefono" runat="server" Enabled = "false" Text="Modificar" CssClass="btn btn-default" OnClick ="btnModificarTelefono_Click"/>
        </div>

        <div class="fila">
        <h2>Agregar Dirección</h2>
        </div>
        
        <div class="fila">
        <label>Calle</label>
        <asp:TextBox ID="txtCalle" runat="server" Enabled = "false" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Número</label>
        <asp:TextBox ID="txtNumero" runat="server" Enabled = "false" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Localidad</label>
        <asp:TextBox ID="txtLocalidad" runat="server" Enabled = "false" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Código Postal</label>
        <asp:TextBox ID="txtCodigoPostal" runat="server" Enabled = "false" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Observaciones</label>
        <asp:TextBox ID="txtObservaciones" runat="server" Enabled = "false" CssClass="form-control campo" TextMode="MultiLine" Rows="4" />
        </div>

        <div class="fila">
        <asp:Button ID="btnAgregarDireccion" runat="server" Text="Agregar Dirección" Enabled = "false" CssClass="btn btn-default" OnClick ="btnAgregarDireccion_Click"/>
        </div>

        <div class="fila">
        <h2>Direcciones Agregadas</h2>
        </div>

        <div class="fila">
        <asp:GridView
            ID="gvDirecciones"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion"
            OnRowCommand = "gvImagenes_RowCommand">

            <Columns>
                <asp:BoundField DataField="Calle" HeaderText="Calle" />
                <asp:BoundField DataField="Numero" HeaderText="Número" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:BoundField DataField="CodigoPostal" HeaderText="Código Postal" />
                <asp:ButtonField Text="Quitar" CommandName="Quitar" />
            </Columns>
        </asp:GridView>
        </div>

        <div>
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Persona/Personas.aspx" CssClass="btn btn-default" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
