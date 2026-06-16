<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarPersona.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.Persona.ModificarPersona" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modificar Persona</title>
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class = "navbar"> Modificar Persona
        </div>
        <div class="contenido">

    <h2>Modificar Persona</h2>

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
            <label>Apellido:</label>
            <asp:TextBox ID="txtDescripcion" runat="server"></asp:TextBox>
            <asp:Button ID="btnModificarDescripcion"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Mail:</label>
            <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
            <asp:Button ID="Button1"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
            <label>Telefono:</label>
            <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
            <asp:Button ID="Button2"
                runat="server"
                Text="Modificar" />
        </div>

        <div class="fila">
        <h2>Agregar Direccion</h2>
        </div>
        
        <div class="fila">
        <label>Calle</label>
        <asp:TextBox ID="TextBox6" runat="server" CssClass="campo" />
        </div>

        <div class="fila">
        <label>Numero</label>
        <asp:TextBox ID="TextBox7" runat="server" CssClass="campo" />
        </div>

        <div class="fila">
        <label>Localidad</label>
        <asp:TextBox ID="TextBox8" runat="server" CssClass="campo" />
        </div>

        <div class="fila">
        <label>Codigo Postal</label>
        <asp:TextBox ID="TextBox9" runat="server" CssClass="campo" />
        </div>

        <div class="fila">
        <label>Observaciones</label>
        <asp:TextBox ID="TextBox10"
            runat="server"
            CssClass="campo"
            TextMode="MultiLine"
            Rows="4" />
        </div>

        <div class="fila">
        <asp:Button
                ID="btnAgregarDireccion"
                runat="server"
                Text="Agregar Direccion" />
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
                PostBackUrl="~/Admin/Persona/Personas.aspx" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
