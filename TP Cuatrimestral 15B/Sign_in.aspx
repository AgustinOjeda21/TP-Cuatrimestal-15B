<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign_in.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Sign_in" %>
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
        </style>

    </head>

<body>
    <form id="form1" runat="server">
        <div class = "registro">
            <h1>Crear Cuenta</h1>

            <nav>
            <asp:TextBox ID="txtNombre" runat="server" CssClass="campo" placeholder="Nombre"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtApellido" runat="server" CssClass="campo" placeholder="Apellido"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="campo" placeholder="Email"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="campo" placeholder="Teléfono"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtPassword" runat="server" CssClass="campo" TextMode="Password" placeholder="Contraseña"> </asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="campo" TextMode="Password" placeholder="Confirmar Contraseña"> </asp:TextBox>
            </nav>

            <h2>Dirección</h2>
            <nav>
            <asp:TextBox ID="txtCalle" runat="server" CssClass="campo" placeholder="Calle"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtNumero" runat="server" CssClass="campo" placeholder="Número"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="campo" placeholder="Localidad"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="campo" placeholder="Código Postal"></asp:TextBox>
            </nav>
            <nav>
            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="campo" TextMode="MultiLine" Rows="3" placeholder="Observaciones"> </asp:TextBox>
            </nav>
        </div>
        <div class =" botones">
            <asp:Button
            ID="btnRegistrarse"
            runat="server"
            Text="Registrarse"
            OnClick="btnRegistrarse_Click" />

            <asp:HyperLink
            ID="lnkLogin"
            runat="server"
            NavigateUrl="~/Log_in.aspx">
            Ya tengo cuenta
            </asp:HyperLink>
        </div>
    </form>
</body>
</html>
