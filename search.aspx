<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="search.aspx.cs" Inherits="search" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content"><h2>Search</h2></div>
    <asp:DropDownList ID="submitList" runat="server" DataTextField="Text" DataValueField="Value" AutoPostBack="True"></asp:DropDownList>
    <asp:DropDownList ID="categoryList" runat="server" DataTextField="Text" DataValueField="Value" AutoPostBack="True"></asp:DropDownList>
    <asp:DropDownList ID="ingredientList" runat="server" DataTextField="Text" DataValueField="Value" AutoPostBack="True"></asp:DropDownList>
    <asp:Label ID="exception" runat="server" Text=""></asp:Label>
    <asp:Button ID="searchBtn" runat="server" Text="Search" OnClick="searchBtn_Click" />
    <div>
        <asp:GridView ID="GridViewRecipe" runat="server" OnSelectedIndexChanged="GridViewRecipe_SelectedIndexChanged">
            <Columns>
                <asp:CommandField HeaderText="Detail" ShowHeader="True" ShowSelectButton="True" />
            </Columns>
        </asp:GridView>
        
        <br />
        <br />
   </div>
</asp:Content>

