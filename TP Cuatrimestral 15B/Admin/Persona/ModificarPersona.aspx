<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPersona.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Persona.ModificarPersona" %>

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
        <asp:Button ID="btnBuscar" runat="server" Text="Buscar" CssClass="btn btn-default" />
    </div>

    <div class="formulario">

        <div class="fila">
            <label>Nombre:</label>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarNombre"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Apellido:</label>
            <asp:TextBox ID="txtDescripcion" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Mail:</label>
            <asp:TextBox ID="TextBox1" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button1"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
            <label>Teléfono:</label>
            <asp:TextBox ID="TextBox2" runat="server" CssClass="form-control"></asp:TextBox>
            <asp:Button ID="Button2"
                runat="server"
                Text="Modificar" CssClass="btn btn-default" />
        </div>

        <div class="fila">
        <h2>Agregar Dirección</h2>
        </div>
        
        <div class="fila">
        <label>Calle</label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Número</label>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Localidad</label>
        <asp:TextBox ID="TextBox8" runat="server" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Código Postal</label>
        <asp:TextBox ID="TextBox9" runat="server" CssClass="form-control campo" />
        </div>

        <div class="fila">
        <label>Observaciones</label>
        <asp:TextBox ID="TextBox10"
            runat="server"
            CssClass="form-control campo"
            TextMode="MultiLine"
            Rows="4" />
        </div>

        <div class="fila">
        <asp:Button
                ID="btnAgregarDireccion"
                runat="server"
                Text="Agregar Dirección" CssClass="btn btn-default" />
        </div>

        <div class="fila">
        <h2>Direcciones Agregadas</h2>
        </div>

        <div class="fila">
        <asp:GridView
            ID="gvDirecciones"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion">

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
