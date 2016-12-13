<%@ Control Language="C#" AutoEventWireup="true" CodeFile="WebUserControl.ascx.cs" Inherits="WebUserControl" %>
<%--XiurongDeng 300853165 --%>
<p> Please add ingredient name, quantity, and messure of unit </p>
<asp:TextBox ID="nameText" runat="server" />
<asp:TextBox ID="quantityText" runat="server" />
<asp:TextBox ID="unitText" runat="server" />
<asp:Button Font-Bold="True" ID="addBtn" runat="server"
    Text="add" OnClick="addBtnClick" validationgroup="ingredientGroup" /><br />
<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="nameText"
validationgroup="ingredientGroup" ErrorMessage="name of the ingredient is required <br / >" ForeColor="#CC3300"></asp:RequiredFieldValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="quantityText"
validationgroup="ingredientGroup" ErrorMessage="number of unit (0-999)" ForeColor="#CC3300"></asp:RequiredFieldValidator>
<asp:RangeValidator ID="numberRequiredFieldValidator" MaximumValue="999" 
   MinimumValue="1" Type="Integer" runat="server" ControlToValidate="quantityText"
validationgroup="ingredientGroup" ErrorMessage="Number of unit is required <br / >" ForeColor="#CC3300"></asp:RangeValidator>
<asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="unitText"
validationgroup="ingredientGroup" ErrorMessage="name of unit is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
<asp:ListView ID="ListView1" runat="server" DataSourceID="ObjectDataSource1">
    <AlternatingItemTemplate>
        <tr style="background-color: #FAFAD2;color: #284775;">
           
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
            </td>
            <td>
                <asp:Label ID="UnitLabel" runat="server" Text='<%# Eval("Unit") %>' />
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
                <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
            </td>
            <td>
                <asp:TextBox ID="UnitTextBox" runat="server" Text='<%# Bind("Unit") %>' />
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
                <asp:TextBox ID="QuantityTextBox" runat="server" Text='<%# Bind("Quantity") %>' />
            </td>
            <td>
                <asp:TextBox ID="UnitTextBox" runat="server" Text='<%# Bind("Unit") %>' />
            </td>
        </tr>
    </InsertItemTemplate>
    <ItemTemplate>
        <tr style="background-color: #FFFBD6;color: #333333;">
           
            <td>
                <asp:Label ID="NameLabel" runat="server" Text='<%# Eval("Name") %>' />
            </td>
            <td>
                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
            </td>
            <td>
                <asp:Label ID="UnitLabel" runat="server" Text='<%# Eval("Unit") %>' />
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
                            <th runat="server">Quantity</th>
                            <th runat="server">Unit</th>
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
                <asp:Label ID="QuantityLabel" runat="server" Text='<%# Eval("Quantity") %>' />
            </td>
            <td>
                <asp:Label ID="UnitLabel" runat="server" Text='<%# Eval("Unit") %>' />
            </td>
        </tr>
    </SelectedItemTemplate>
</asp:ListView>

<asp:ObjectDataSource ID="ObjectDataSource1" runat="server" SelectMethod="Get" TypeName="IngredientRepo"></asp:ObjectDataSource>




