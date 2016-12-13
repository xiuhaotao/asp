<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="Login" %>
<%--XiurongDeng 300853165 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Login</h1>
    <p>Name:<br />
    <asp:textbox id="username" runat="server"></asp:textbox>
        </p>
    <p>Password:<br />
        <asp:textbox id="password" runat="server" TextMode="Password"></asp:textbox>
    </p>
    <p>
        <asp:button id="submitButton" runat="server" text="Login" OnClick="submitButton_Click" />
    </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>

