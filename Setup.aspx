<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="Setup.aspx.cs" Inherits="Setup" %>
<%--XiurongDeng 300853165 --%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<p>Click Button to change Theme<br /></p>
<asp:Button ID="btnDark"  runat="server" Text="Dark" BackColor="Black" ForeColor="White" Font-Bold="true" onclick="btnBlue_Click"/>
<asp:Button ID="btnLight" runat="server" Text="Light" BackColor="#FFFFCC" Font-Bold="true" onclick="btnRed_Click"/>
</asp:Content>

