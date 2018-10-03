<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwLogin.aspx.cs" Inherits="ExercicioBD.vwLogin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" OnTextChanged="TxtEmail_TextChanged"></asp:TextBox>
        </div>

         <div>   
            <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
            <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
        </div>
        <br />
        <asp:Button ID="BtnLogar" runat="server" Text="Logar" OnClick="BtnLogar_Click" style="height: 26px" />
        <asp:HyperLink ID="HyperLink1" runat="server"  NavigateUrl ="~/vwCliente.aspx">Cadastre um cliente</asp:HyperLink>
        <asp:HyperLink ID="HyperLink2" runat="server"  NavigateUrl ="~/vwEmpresa.aspx">Cadastre uma empresa</asp:HyperLink>
    </form>
    <br />
    <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
</body>
</html>
