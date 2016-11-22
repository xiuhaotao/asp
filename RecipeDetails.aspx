<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecipeDetails.aspx.cs" Inherits="RecipeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DetailsView ID="DetailsViewDetail" runat="server" Height="50px" Width="180px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Dashed" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Horizontal">
        <AlternatingRowStyle BackColor="#F7F7F7" />
        <CommandRowStyle Font-Size="Medium" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <FieldHeaderStyle Font-Names="Arial" Font-Size="Small" />
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
    </asp:DetailsView>
<asp:Label ID="exception" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
    <asp:Label ID="test" runat="server" Text=""></asp:Label>
</asp:Content>

