<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Log_in.aspx.cs" Inherits="TP_Cuatrimestral_15B.Log_in" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        <title>Inicio</title>
        <style>
            .registro {
            width: 500px;
            margin: 30px auto;
            padding: 30px;
            border: 1px solid #ccc;
            border-radius: 10px;
            background-color: #f5f5f5;
            }

            .campo {
                width: 100%;
                height: 35px;
                margin-bottom: 10px;
                padding-left: 10px;
                border-radius: 5px;
                border: 1px solid #ccc;
            }
            .botones {
                text-align: center;
                margin-top: 20px;
            }
            .registro h2{
                text-align: center;
            }
        </style>

    </head>

<body>
    <form id="form1" runat="server">
        <div class = "registro">
            <h2>Iniciar sesion</h2>

            <nav>
            <asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="campo" placeholder="Nombre usuario"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtContraseña" runat="server" CssClass="campo" placeholder="Contraseña"></asp:TextBox>
            </nav>
        </div>
        <div class =" botones">
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false" Text="Usuario o contraseña incorrectos"></asp:Label>
            <asp:Button
            ID="btnRegistrarse"
            runat="server"
            Text="Log in"
            OnClick="btnRegistrarse_Click" />

            <asp:HyperLink
            ID="lnkLogin"
            runat="server"
            NavigateUrl="~/Sign_in.aspx">
            No tengo cuenta
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>