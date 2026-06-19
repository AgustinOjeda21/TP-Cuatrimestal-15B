<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Admin.Usuario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    
    <meta charset="utf-8" />
<title>Agregar Usuario</title>
    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../Content/Site.css" rel="stylesheet" />
    
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Usuario
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Usuario</h2>

        <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label ID="lblConfirmacion" runat="server" ForeColor="Green" Visible="false"></asp:Label>

        <asp:Label ID="lblNombreError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Nombre *</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" />

        <asp:Label ID="lblApellidoError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Apellido *</label>
        <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control campo" />
    
        <asp:Label ID="lblMailError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Mail *</label>
        <asp:TextBox ID="txtMail" runat="server" CssClass="form-control campo" />
     
        <asp:Label ID="lblTelefonoError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Teléfono *</label>
        <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control campo" />
    
        <asp:Label ID="lblContrasenaError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Contraseña *</label>
        <asp:TextBox ID="txtContrasena" runat="server" CssClass="form-control campo" />
    

      <h2>Agregar Dirección</h2>

        <asp:Label ID="lblCalleError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Calle *</label>
        <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control campo" />

        <asp:Label ID="lblNumeroError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Número *</label>
        <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control campo" />

        <asp:Label ID="lblLocalidadError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Localidad *</label>
        <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control campo" />

        <asp:Label ID="lblCodigoError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <label>Código Postal *</label>
        <asp:TextBox ID="txtCodigo" runat="server" CssClass="form-control campo" />

        <label>Observaciones</label>
        <asp:TextBox ID="txtObservaciones"
            runat="server"
            CssClass="form-control campo"
            TextMode="MultiLine"
            Rows="4" />

        <asp:Button
                ID="btnAgregarDireccion"
                runat="server"
                Text="Agregar Dirección"
                OnClick="btnAgregarDireccion_Click" CssClass="btn btn-default" />

        <asp:Label ID="lblDireccionesError" runat="server" ForeColor="Red" Visible="false"></asp:Label>
        <h2>Direcciones Agregadas *</h2>

        <asp:GridView
            ID="gvDirecciones"
            runat="server"
            AutoGenerateColumns="False"
            CssClass="tablaSeleccion"
            OnRowCommand="gvDirecciones_RowCommand">

            <Columns>
                <asp:BoundField DataField="Calle" HeaderText="Calle" />
                <asp:BoundField DataField="Numero" HeaderText="Número" />
                <asp:BoundField DataField="Localidad" HeaderText="Localidad" />
                <asp:BoundField DataField="CodigoPostal" HeaderText="Código Postal" />
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
                PostBackUrl="~/Admin/Usuario/Usuarios.aspx" CssClass="btn btn-default" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
