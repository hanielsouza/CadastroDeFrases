﻿<%@ Page Title="" Language="C#" MasterPageFile="~/PaginaMestre.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebFrases.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Label ID="label1" runat="server" Text="Nome"></asp:Label>
    <asp:Label ID="lbNome" runat="server" Text="Nome do usuário"></asp:Label>
    <br />
      <asp:Label ID="label2" runat="server" Text="Email"></asp:Label>
    <asp:Label ID="lbEmail" runat="server" Text="email do usuário"></asp:Label>
    <br />

</asp:Content>
