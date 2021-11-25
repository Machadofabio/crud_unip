    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Tela.aspx.cs" Inherits="View.Tela" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <link rel="stylesheet" type="text/css" href="styleSheet.css" />
    <title>Crudnow | Cadastre-se agora</title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h1>Crudnow</h1>
            <div class="divHeader">
                <asp:Label runat="server" CssClass="label">Buscar pelo CPF</asp:Label>
                <br />
                <asp:TextBox ID="txtBuscarPeloCPF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                    BorderColor="Gray"></asp:TextBox>
                <asp:ImageButton ID="ImageButtonConsulte" runat="server" OnClick="btnConsulte_Click" Height="24px"
                    ImageUrl="./images/search-icon.png" Width="24px" />
                <asp:ImageButton ID="ImageButtonAltere" runat="server" OnClick="btnAltere_Click" Height="24px"
                    ImageUrl="./images/edit-icon.png" Width="24px" />
                <asp:ImageButton ID="ImageButtonExclua" runat="server" OnClick="btnExclua_Click" Height="24px"
                    ImageUrl="./images/trash-icon.png" Width="24px" />
            </div>
            <asp:Table runat="server" Width="178px">
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Nome</asp:Label>
                        <br />
                        <asp:TextBox ID="txtNome" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                            BorderColor="Gray"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">CPF</asp:Label>
                        <br />
                        <asp:TextBox ID="txtCPF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                            BorderColor="Gray"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Telefone</asp:Label>
                        <br />
                        <asp:TextBox ID="txtTelefone" CssClass="txtBox" runat="server" Width="180px" Height="24px" 
                            BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label" Text="Cel.">Tipo Tel.</asp:Label>
                        <br />
                        <asp:TextBox ID="txtTipoTelefone" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                            BorderWidth="1px" BorderColor="Gray" Text="Cel."></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Logradouro</asp:Label>
                        <br />
                        <asp:TextBox ID="txtLogradouro" CssClass="txtBox" runat="server" Width="180px" Height="24px" 
                            BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Nº</asp:Label>
                        <br />
                        <asp:TextBox ID="txtNumeroLogradouro" CssClass="txtBox" runat="server" Width="180px" Height="24px"
                            BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Bairro</asp:Label>
                        <br />
                        <asp:TextBox ID="txtBairro" CssClass="txtBox" runat="server" Width="180px" Height="24px" 
                            BorderWidth="1px" BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">CEP</asp:Label>
                        <br />
                        <asp:TextBox ID="txtCEP" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                            BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow runat="server">
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">Cidade</asp:Label>
                        <br />
                        <asp:TextBox ID="txtCidade" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                            BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label runat="server" CssClass="label">UF</asp:Label>
                        <br />
                        <asp:TextBox ID="txtUF" CssClass="txtBox" runat="server" Width="180px" Height="24px" BorderWidth="1px"
                            BorderColor="Gray"></asp:TextBox>
                        <br />
                    </asp:TableCell>
                </asp:TableRow> 
            </asp:Table>
            <asp:Button ID="btnInsira" runat="server" Text="Cadastrar" BackColor="#0066CC" Width="385px" 
                OnClick="btnInsira_Click" Height="36px" ForeColor="White" BorderWidth="0px" />
        </div>
    </form>
</body>
</html>
