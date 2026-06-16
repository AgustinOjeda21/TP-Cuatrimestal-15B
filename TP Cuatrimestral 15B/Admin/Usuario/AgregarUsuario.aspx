<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Usuario.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Agregar Usuario</title>
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
        margin-top: 15px;
    }

    .tablaSeleccion th {
        background-color: brown;
        color: white;
        padding: 10px;
    }

    .tablaSeleccion td {
        border: 1px solid #ddd;
        padding: 10px;
    }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class ="navbar">Agregar Usuario
        </div>
        <div class="contenido">
    <div class="formulario-admin">
        <h2>Agregar Usuario</h2>

        <label>Nombre</label>
        <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" />

        <label>Apellido</label>
        <asp:TextBox ID="TextBox2" runat="server" CssClass="campo" />
    
        <label>Mail</label>
        <asp:TextBox ID="TextBox3" runat="server" CssClass="campo" />
     
        <label>Telefono</label>
        <asp:TextBox ID="TextBox4" runat="server" CssClass="campo" />

        <label>Rol</label>
        <asp:DropDownList ID="ddlRoles" runat="server" CssClass="campo"> </asp:DropDownList>
    
        <label>Contraseña</label>
        <asp:TextBox ID="TextBox5" runat="server" CssClass="campo" />
    

      <h2>Agregar Direccion</h2>

        <label>Calle</label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="campo" />

        <label>Numero</label>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="campo" />

        <label>Localidad</label>
        <asp:TextBox ID="TextBox8" runat="server" CssClass="campo" />

        <label>Codigo Postal</label>
        <asp:TextBox ID="TextBox9" runat="server" CssClass="campo" />

        <label>Observaciones</label>
        <asp:TextBox ID="TextBox10"
            runat="server"
            CssClass="campo"
            TextMode="MultiLine"
            Rows="4" />

        <asp:Button
                ID="btnAgregarDireccion"
                runat="server"
                Text="Agregar Direccion" />

        <h2>Direcciones Agregadas</h2>

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



        <div class="botones">
            <asp:Button
                ID="btnGuardar"
                runat="server"
                Text="Guardar" />

            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/Usuario/Usuarios.aspx" />
        </div>
    </div>
</div>
    </form>
</body>
</html>
