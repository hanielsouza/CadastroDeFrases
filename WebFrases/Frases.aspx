﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Frases.aspx.cs" Inherits="WebFrases.Frases" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="Panel1" runat="server" GroupingText="Cadastro/Alteração de frases">
        <asp:Label ID="Label1" runat="server" Text="Id"></asp:Label>
            <br />
          <asp:TextBox ID="txtId" runat="server" Enabled="false"></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Frase"></asp:Label>
                <br />
          <asp:TextBox ID="txtFrase" runat="server"></asp:TextBox>
        <br />
        <asp:Label ID="Label3" runat="server" Text="Autor"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlAutor" runat="server"></asp:DropDownList>
        <br />
        <asp:Label ID="Label4" runat="server" Text="Categoria"></asp:Label>
        <br />
        <asp:DropDownList ID="ddlCategoria" runat="server"></asp:DropDownList>
        <br />
        <asp:Button ID="btnInserir" runat="server" Text="Inserir" OnClick="btnInserir_Click" />
        <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" OnClick="btnCancelar_Click"/>

        <br />
        <br />
        
        <br />

    </asp:Panel>
    <asp:Panel ID="Panel2" runat="server" GroupingText="Registro das Categorias">
    <asp:GridView ID="gvDados" runat="server" AutoGenerateColumns="False" CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="gvDados_RowDeleting" OnSelectedIndexChanged="gvDados_SelectedIndexChanged">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:CommandField ShowSelectButton="True" />
                <asp:CommandField ShowDeleteButton="True" />
                <asp:BoundField DataField="id" HeaderText="Id" />
                <asp:BoundField DataField="Frase" HeaderText="Frase" />
                <asp:BoundField DataField="autornome" HeaderText="Autor" />
                <asp:BoundField DataField="categorianome" HeaderText="Categoria" />
            </Columns>
            <EditRowStyle BackColor="#999999" />
            <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
            <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
            <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
            <SortedAscendingCellStyle BackColor="#E9E7E2" />
            <SortedAscendingHeaderStyle BackColor="#506C8C" />
            <SortedDescendingCellStyle BackColor="#FFFDF8" />
            <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
        </asp:GridView>
        </asp:Panel>
</asp:Content>
