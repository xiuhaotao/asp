<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <h1>Registration</h1>
    <p>
        <span class="widelabel">Name:</span>
        <asp:TextBox ID="name" runat="server"></asp:TextBox>
        <br />
        <span class="widelabel">Password:</span>
        <asp:TextBox ID="password" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <span class="widelabel">Repeat Password:</span>
        <asp:TextBox ID="repeatPassword" runat="server" TextMode="Password"></asp:TextBox>
        <br />
        <span class="widelabel">Email:</span>

        <asp:TextBox ID="email" runat="server"></asp:TextBox>
        <br />
        <span class="widelabel">Phone:</span>
        <asp:TextBox ID="phone" runat="server"></asp:TextBox>
        <br />
    </p>
    <p>
        <asp:button id="submitButton" runat="server" text="Register" OnClick="submitButton_Click" />
        </p>
    <p>
        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
    </p>
</asp:Content>

