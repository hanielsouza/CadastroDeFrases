<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebFrases.Login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <asp:Panel ID="Panel1" runat="server" GroupingText="Login de usuário" CssClass="login">
                <asp:Label ID="Label1" runat="server" Text="Login"></asp:Label>
                <br />
                <asp:TextBox ID="txbLogin" runat="server"></asp:TextBox>
                <br />
                 <asp:Label ID="Label2" runat="server" Text="Senha"></asp:Label>
                <br />
                <asp:TextBox ID="txbSenha" runat="server"></asp:TextBox>

                <asp:Button ID="btnLogar" runat="server" Text="Logar" OnClick="btnLogar_Click" />
            </asp:Panel>

        </div>
    </form>
</body>
</html>
