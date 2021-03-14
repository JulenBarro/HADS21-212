<%@ Page Language="vb" AutoEventWireup="false" CodeBehind="PaginaUsuarioIniciado.aspx.vb" Inherits="Lab2Presentacion.PaginaUsuarioIniciado" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="height: 207px">
            <asp:Label ID="Label1" runat="server" Text="Inicio de sesión correcto!"></asp:Label>
            <br />
            <br />
            <asp:Button ID="Button1" runat="server" Text="Cambiar contraseña" />
            <br />
            <br />
            <asp:Button ID="Button2" runat="server" Text="LogOut" />
            <br />
            <br />
        </div>
    </form>
</body>
</html>
