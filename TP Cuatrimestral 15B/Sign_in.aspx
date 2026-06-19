<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Sign_in.aspx.cs" Async="true" Inherits="TP_Cuatrimestral_15B.Sign_in" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat ="server">
        
    <meta charset="utf-8" />
<title>Inicio</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <link href="Content/Site.css" rel="stylesheet" />
        

    </head>

<body>
    <form id="form1" runat="server">
        <div class="authPage">
        <div class = "registro authBox authBoxGrande">
            <h1>Crear Cuenta</h1>
            <p class="authSubtitulo">Completá tus datos para crear tu usuario.</p>
            <asp:Label ID="lblError" runat="server" ForeColor="Red" Visible="false"></asp:Label>

            <div class="authGrid">
            <div class="campoAuth">
            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control campo" placeholder="Nombre"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control campo" placeholder="Apellido"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control campo" placeholder="Email"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtTelefono" runat="server" CssClass="form-control campo" placeholder="Teléfono"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control campo" TextMode="Password" placeholder="Contraseña"> </asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtConfirmarPassword" runat="server" CssClass="form-control campo" TextMode="Password" placeholder="Confirmar Contraseña"> </asp:TextBox>
            </div>
            </div>

            <h2>Dirección</h2>
            <div class="authGrid">
            <div class="campoAuth">
            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control campo" placeholder="Calle"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control campo" placeholder="Número"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control campo" placeholder="Localidad"></asp:TextBox>
            </div>
            <div class="campoAuth">
            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control campo" placeholder="Código Postal"></asp:TextBox>
            </div>
            <div class="campoAuth campoAuthCompleto">
            <asp:TextBox ID="txtObservaciones" runat="server" CssClass="form-control campo" TextMode="MultiLine" Rows="3" placeholder="Observaciones"> </asp:TextBox>
            </div>
            </div>
            <div class ="botones authBotones">
            <asp:Button
            ID="btnRegistrarse"
            runat="server"
            Text="Registrarse"
            OnClick="btnRegistrarse_Click" CssClass="btn btn-default" />

            <asp:HyperLink
            ID="lnkLogin"
            runat="server"
            NavigateUrl="~/Log_in.aspx">
            Ya tengo cuenta
            </asp:HyperLink>

            <asp:HyperLink
            ID="lnkVolverTienda"
            runat="server"
            NavigateUrl="~/Inicio.aspx"
            CssClass="btn btn-default">
            Volver a tienda
            </asp:HyperLink>
            </div>
        </div>
        </div>
    </form>
</body>
</html>
