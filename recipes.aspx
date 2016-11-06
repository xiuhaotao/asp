<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="recipes.aspx.cs" Inherits="recipes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div class="content"><h2>Recipes</h2></div>
    <div>
        <asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
            <AlternatingItemTemplate>
                <tr style="background-color: #FAFAD2;color: #284775;">
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OwnerLabel" runat="server" Text='<%# Eval("Owner") %>' />
                    </td>
                    
                    <td>
                        <asp:Label ID="CookingTimeLabel" runat="server" Text='<%# Eval("CookingTime") %>' />
                    </td>
                    
                </tr>
            </AlternatingItemTemplate>
            <EditItemTemplate>
                <tr style="background-color: #FFCC66;color: #000080;">
                    <td>
                        <asp:Button ID="UpdateButton" runat="server" CommandName="Update" Text="Update" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Cancel" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="OwnerTextBox" runat="server" Text='<%# Bind("Owner") %>' />
                    </td>
                   
                    <td>
                        <asp:TextBox ID="CookingTimeTextBox" runat="server" Text='<%# Bind("CookingTime") %>' />
                    </td>
                   
                </tr>
            </EditItemTemplate>
            <EmptyDataTemplate>
                <table runat="server" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;">
                    <tr>
                        <td>No data was returned.</td>
                    </tr>
                </table>
            </EmptyDataTemplate>
            <InsertItemTemplate>
                <tr style="">
                    <td>
                        <asp:Button ID="InsertButton" runat="server" CommandName="Insert" Text="Insert" />
                        <asp:Button ID="CancelButton" runat="server" CommandName="Cancel" Text="Clear" />
                    </td>
                    <td>
                        <asp:TextBox ID="NameTextBox" runat="server" Text='<%# Bind("Name") %>' />
                    </td>
                    <td>
                        <asp:TextBox ID="OwnerTextBox" runat="server" Text='<%# Bind("Owner") %>' />
                    </td>
                    
                    <td>
                        <asp:TextBox ID="CookingTimeTextBox" runat="server" Text='<%# Bind("CookingTime") %>' />
                    </td>
                    
                </tr>
            </InsertItemTemplate>
            <ItemTemplate>
                <tr style="background-color: #FFFBD6;color: #333333;">
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OwnerLabel" runat="server" Text='<%# Eval("Owner") %>' />
                    </td>
                    
                    <td>
                        <asp:Label ID="CookingTimeLabel" runat="server" Text='<%# Eval("CookingTime") %>' />
                    </td>
                   
                </tr>
            </ItemTemplate>
            <LayoutTemplate>
                <table runat="server">
                    <tr runat="server">
                        <td runat="server">
                            <table id="itemPlaceholderContainer" runat="server" border="1" style="background-color: #FFFFFF;border-collapse: collapse;border-color: #999999;border-style:none;border-width:1px;font-family: Verdana, Arial, Helvetica, sans-serif;">
                                <tr runat="server" style="background-color: #FFFBD6;color: #333333;">
                                    <th runat="server">Name</th>
                                    <th runat="server">Submitted by</th>
                                   
                                    <th runat="server">CookingTime</th>
                                   
                                </tr>
                                <tr id="itemPlaceholder" runat="server">
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr runat="server">
                        <td runat="server" style="text-align: center;background-color: #FFCC66;font-family: Verdana, Arial, Helvetica, sans-serif;color: #333333;"></td>
                    </tr>
                </table>
            </LayoutTemplate>
            <SelectedItemTemplate>
                <tr style="background-color: #FFCC66;font-weight: bold;color: #000080;">
                    <td>
                        <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
                    </td>
                    <td>
                        <asp:Label ID="OwnerLabel" runat="server" Text='<%# Eval("Owner") %>' />
                    </td>
                   
                    <td>
                        <asp:Label ID="CookingTimeLabel" runat="server" Text='<%# Eval("CookingTime") %>' />
                    </td>
                   
                </tr>
            </SelectedItemTemplate>
        </asp:ListView>
        <asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Get" TypeName="RecipeRepo"></asp:ObjectDataSource>
        <asp:Button Font-Bold="True" ID="addBtn" runat="server"
    Text="Add Recipe" OnClick="addBtnClick" />
    </div>
</asp:Content>

