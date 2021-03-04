<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Usuario.aspx.cs" Inherits="WebFrases.Usuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de usuários">
        <asp:Label ID="Label1" runat="server" Text="ID"></asp:Label>
        <br />
        <asp:TextBox ID="txtId" runat="server" Enabled="False"></asp:TextBox>
        <br />
        <asp:Label ID="Label2" runat="server" Text="Nome do usuário"></asp:Label>
        <br />
        <asp:TextBox ID="txtNome" runat="server" Width="570px"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="E-mail"></asp:Label>
        <br />
        <asp:TextBox ID="txtEmail" runat="server" Width="570px"></asp:TextBox>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Senha"></asp:Label>
        <br />
        <asp:TextBox ID="txtSenha" runat="server" Width="570px" TextMode="Password"></asp:TextBox>
        <br />
        <br />
        <asp:Button ID="btSalvar" runat="server" Text="Inserir" OnClick="btSalvar_Click" />
        <asp:Button ID="btCancelar" runat="server" CausesValidation="False" Text="Cancelar" OnClick="btCancelar_Click" />
        <br />
    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Registros dos usuários">
    <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" Width="580px" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvDados_RowDeleting" OnSelectedIndexChanged="gvDados_SelectedIndexChanged" >
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="Nome" HeaderText="Nome" />
                <asp:BoundField DataField="email" HeaderText="E-mail" />
            </Columns>
            <EditRowStyle BackColor="#2461BF" />
            <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#EFF3FB" />
            <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#F5F7FB" />
            <SortedAscendingHeaderStyle BackColor="#6D95E1" />
            <SortedDescendingCellStyle BackColor="#E9EBEF" />
            <SortedDescendingHeaderStyle BackColor="#4870BE" />
        </asp:GridView>
    </asp:Panel>
</asp:Content>
