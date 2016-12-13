<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Registration.aspx.cs" Inherits="Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <h1>Registration</h1>
    <p>
    <span class="widelabel"> Name:</span>
    <asp:TextBox ID="nameTextBox" runat="server"></asp:TextBox>
    <br />
    <span class="widelabel"> Password:</span>
    <asp:TextBox ID="passwordTextBox" runat="server"></asp:TextBox>
    <br />
     <span class="widelabel"> Address:</span>
    <asp:TextBox ID="addressTextBox" runat="server"></asp:TextBox>
    <br />
    <span class="widelabel"> City:</span>
    <asp:TextBox ID="cityTextBox" runat="server"></asp:TextBox>
    <br />
    <span class="widelabel"> Province:</span>
    <asp:TextBox ID="provinceTextBox" runat="server"></asp:TextBox>
    <br />
    <span class="widelabel"> Email:</span>
    <asp:TextBox ID="emailTextBox" runat="server"></asp:TextBox>
    <br />

</p>
</asp:Content>

