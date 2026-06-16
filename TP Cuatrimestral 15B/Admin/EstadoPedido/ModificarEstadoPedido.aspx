<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModificarEstadoPedido.aspx.cs" Inherits="TP_Cuatrimestral_15B.Admin.EstadoPedido.ModificarEstadoPedido" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Modificar Estado Pedido</title>
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
        <div class = "navbar"> Modificar Categoria
        </div>
        <div class="contenido">

    <h2>Modificar Estado Pedido</h2>

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

        <div>
            <asp:Button
                ID="btnCancelar"
                runat="server"
                Text="Cancelar"
                PostBackUrl="~/Admin/EstadoPedido/EstadosPedido.aspx" />
        </div>

    </div>

</div>
    </form>
</body>
</html>
