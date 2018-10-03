<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwCliente.aspx.cs" Inherits="ExemploBD.vwCliente" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>   
            <asp:Label ID="LblId" runat="server" Text="Id: "></asp:Label>
             <asp:TextBox ID="TxtId" runat="server"></asp:TextBox>
        </div>
        <div>
            <asp:Label ID="LblNome" runat="server" Text="Nome: "></asp:Label>
            <asp:TextBox ID="TxtNome" runat="server"></asp:TextBox>
        </div>
        <div>   
            <asp:Label ID="LblCpf" runat="server" Text="CPF: "></asp:Label>
            <asp:TextBox ID="TxtCpf" runat="server"></asp:TextBox>
        </div>
        <div>   
            <asp:Label ID="LblRg" runat="server" Text="RG:"></asp:Label>
            <asp:TextBox ID="TxtRg" runat="server"></asp:TextBox>
        </div>

         <div>   
            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server"></asp:TextBox>
        </div>
         <div>   
            <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
        <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
        </div>
        <div>   
            <asp:Button ID="BtnAdd" runat="server" Text="Adicionar" OnClick="BtnAdd_Click" />
            <asp:Button ID="BtnAlterar" runat="server" Text="Alterar" OnClick="BtnAlterar_Click" />
            <asp:Button ID="BtnDel" runat="server" Text="Deletar" OnClick="BtnDel_Click" />
            <asp:Button ID="BtnBuscar" runat="server" Text="Buscar" OnClick="BtnBuscar_Click" />
            <asp:Button ID="BtnListar" runat="server" Text="Listar Todos" OnClick="BtnListar_Click" />
            <asp:Button ID="BtnAddEnd" runat="server" Text="Adicionar Endereco" OnClick="BtnAddEnd_Click" />
        </div>
        <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
    </form>
</body>
</html>
