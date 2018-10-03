<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwOrdemServico.aspx.cs" Inherits="ExercicioBD.vwOrdemServico" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
   
    <title></title>

</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table>
                <tr>
                    <td>
                        <asp:Label ID="Label1" runat="server" Text="Data de Solicitação"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDataSolicitacao" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label2" runat="server" Text="Prazo de Entrega"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtPrazoEntrega" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label3" runat="server" Text="Total"></asp:Label>
                    </td>
                    <td>
                        <asp:TextBox ID="txtTotal" runat="server"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Label ID="Label4" runat="server" Text="Status"></asp:Label>
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownStatus" runat="server">
                            <asp:ListItem></asp:ListItem>
                            <asp:ListItem>Aberto</asp:ListItem>
                            <asp:ListItem>Andamento</asp:ListItem>
                            <asp:ListItem>Finalizado</asp:ListItem>
                        </asp:DropDownList>
                    </td>
                </tr>
            </table>
        </div>
        <div>
            <asp:Button ID="BtnSalvar" runat="server" Text="Salvar" OnClick="BtnSalvar_Click" />
            <asp:Button ID="BtnAlterar" runat="server" Text="Alterar" />
        </div>
        <p>
            <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
        </p>
    
    <div>
        <asp:GridView ID="gdvOrdemServico" runat="server"
            AutoGenerateColumns="False" 
            DataKeyNames="numero"
            BackColor="White" BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="4" ForeColor="Black" GridLines="Horizontal" >
            <Columns>
                <asp:TemplateField HeaderText="Número">   
                    <ItemTemplate>
                        <asp:Label ID="LblRua" runat="server" Text='<%# Bind("numero") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data de Solicitação">
                    <ItemTemplate>
                        <asp:Label ID="LblNumero" runat="server" Text='<%# Bind("data_solicitacao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prazo de Entrega">
                    <ItemTemplate>
                        <asp:Label ID="LblComp" runat="server" Text='<%# Bind("prazo_entrega") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <ItemTemplate>
                        <asp:Label ID="lblBairro" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <ItemTemplate>
                        <asp:Label ID="LblCep" runat="server" Text='<%# Bind("status") %>'></asp:Label>
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
        </form>
</body>
</html>
