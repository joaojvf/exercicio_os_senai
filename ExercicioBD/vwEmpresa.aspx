<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="vwEmpresa.aspx.cs" Inherits="ExercicioBD.vwEmpresa" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
       <div>   
            <asp:Label ID="LblRazaoSocial" runat="server" Text="Razão Social: "></asp:Label>
            <asp:TextBox ID="TxtRazaoSocial" runat="server" OnTextChanged="TxtRazaoSocial_TextChanged"></asp:TextBox>
        </div>
        <div>   
            <asp:Label ID="LblCnpj" runat="server" Text="CNPJ:"></asp:Label>
            <asp:TextBox ID="TxtCnpj" runat="server" OnTextChanged="TxtCnpj_TextChanged"></asp:TextBox>
        </div>

         <div>   
            <asp:Label ID="LblEmail" runat="server" Text="Email:"></asp:Label>
            <asp:TextBox ID="TxtEmail" runat="server" OnTextChanged="TxtEmail_TextChanged"></asp:TextBox>
        </div>
         <div>   
            <asp:Label ID="LblSenha" runat="server" Text="Senha:"></asp:Label>
        <asp:TextBox ID="TxtSenha" runat="server" TextMode="Password" OnTextChanged="TxtSenha_TextChanged"></asp:TextBox>
        </div>
        
        <div> 
            <asp:Button ID="BtnAdd" runat="server" Text="Adicionar" OnClick="BtnAdd_Click" style="height: 26px" />
            <asp:Button ID="BtnPopGrid" runat="server" Text="Atualizar Grid" OnClick="BtnAtualizar" style="height: 26px" />
        </div>

        <asp:Label ID="LblResultado" runat="server" Text=""></asp:Label>
    <br />
        <asp:GridView ID="GdvEmpresa" runat="server" AutoGenerateColumns="False" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px" CellPadding="3" ForeColor="Black" GridLines="Vertical" OnSelectedIndexChanged="GridView1_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="#CCCCCC" />
            <Columns>
                <asp:TemplateField HeaderText="Número">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("numero") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("numero") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Data da Solicitacao">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("data_solicitacao") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("data_solicitacao") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Prazo da Entrega">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("prazo_entrega") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label3" runat="server" Text='<%# Bind("prazo_entrega") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Total">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("total") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label4" runat="server" Text='<%# Bind("total") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Status">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox5" runat="server" Text='<%# Bind("status") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label5" runat="server" Text='<%# Bind("status") %>'></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cliente_id" HeaderText="ID do Cliente" />
            </Columns>
            <FooterStyle BackColor="#CCCCCC" />
            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
            <SortedAscendingCellStyle BackColor="#F1F1F1" />
            <SortedAscendingHeaderStyle BackColor="#808080" />
            <SortedDescendingCellStyle BackColor="#CAC9C9" />
            <SortedDescendingHeaderStyle BackColor="#383838" />
        </asp:GridView>
    </form>
    <br />



</body>
</html>
