<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEndereco.aspx.cs" Inherits="ExemploBD.vwEndereco" EnableEventValidation="false" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:HiddenField ID="HiddenCod" runat="server" />  
            <asp:Label ID="LblCliente" runat="server" Text=""></asp:Label>
            <br />
            <br />
            <asp:Label ID="Label1" runat="server" Text="Rua "></asp:Label>
            <asp:TextBox ID="TxtRua" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Bairro "></asp:Label>
            <asp:TextBox ID="TxtBairro" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label3" runat="server" Text="CEP "></asp:Label>
            <asp:TextBox ID="TxtCep" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label4" runat="server" Text="Complemento "></asp:Label>
            <asp:TextBox ID="TxtComp" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="Label5" runat="server" Text="Número "></asp:Label>
            <asp:TextBox ID="TxtNumero" runat="server"></asp:TextBox>
            <br />
            <asp:Button ID="BtnSalvar" runat="server" Text="Salvar Novo" OnClick="BtnSalvar_Click" />
            <asp:Button ID="BtnAlterar" runat="server" Text="Alterar" OnClick="BtnAlterar_Click" />
            <asp:Button ID="BtnExcluir" runat="server" Text="Excluir" OnClientClick="return confirm('Deseja realmente excluir?');" OnClick="BtnExcluir_Click" />
            <br />
            
        </div>
        <div>
            <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
        </div>
        <br />
        <br />
        <div>
        <asp:GridView ID="gdvEndereco" runat="server"
            AutoGenerateColumns="False" 
            DataKeyNames="cod" OnRowCommand="gdvEndereco_RowCommand" 
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
            <Columns>
                
                <asp:TemplateField HeaderText="Rua">
                        
                    <ItemTemplate>
                        <asp:Label ID="LblRua" runat="server" Text='<%# Bind("rua") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Número">
                    <ItemTemplate>
                        <asp:Label ID="LblNumero" runat="server" Text='<%# Bind("numero") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Complemento">
                    <ItemTemplate>
                        <asp:Label ID="LblComp" runat="server" Text='<%# Bind("complemento") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Bairro">
                    <ItemTemplate>
                        <asp:Label ID="lblBairro" runat="server" Text='<%# Bind("bairro") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="CEP">
                    <ItemTemplate>
                        <asp:Label ID="LblCep" runat="server" Text='<%# Bind("cep") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:LinkButton ID="lkbEditar" runat="server" Text="Editar" CommandArgument='<%# Bind("cod") %>' CommandName="Editar"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
            <FooterStyle BackColor="#CCCC99" ForeColor="Black" />
            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="White" ForeColor="Black" HorizontalAlign="Right" />
            <SelectedRowStyle BackColor="#CC3333" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F7F7F7" />
            <SortedAscendingHeaderStyle BackColor="#4B4B4B" />
            <SortedDescendingCellStyle BackColor="#E5E5E5" />
            <SortedDescendingHeaderStyle BackColor="#242121" />
        </asp:GridView>
            </div>
        <br />
        <br />
        <asp:Button ID="BtnVoltar" runat="server" Text="Voltar" OnClick="BtnVoltar_Click" />
    </form>

</body>
</html>
