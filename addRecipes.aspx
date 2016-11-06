<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="addRecipes.aspx.cs" Inherits="addRecipes" %>

<%@ Register Src="~/webUserControl.ascx" TagPrefix="uc1" TagName="webUserControl" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="content">
        <h2>Add Recipes</h2>
        <asp:Table ID="Table1" runat="server">
            <asp:TableRow>
                <asp:TableCell>Name of Recipe :</asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="nameOfRecipeTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="nameRequiredFieldValidator" runat="server" ControlToValidate="nameOfRecipeTextBox"
                        ValidationGroup="recipeGroup" ErrorMessage="<br / > Name is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>                    
                Submitted By: 
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="submittedByTextBox" runat="server" CssClass="textbox"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="submmittedRequiredFieldValidator" runat="server" ControlToValidate="submittedByTextBox"
                        ValidationGroup="recipeGroup" ErrorMessage="<br / > owner is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>    Category:
                </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="categoryTextBox" runat="server">
                    </asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>  Prepare/Cooking Time: </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="cookingTimeTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
            </asp:TableRow>
            <asp:TableRow>
                <asp:TableCell>
              Number of Servings: </asp:TableCell>
                <asp:TableCell>
                    <asp:TextBox ID="numOfServingsTextBox" runat="server"></asp:TextBox>
                </asp:TableCell>
                <asp:TableCell>
                    <asp:RequiredFieldValidator ID="numberRequiredFieldValidator" runat="server" ControlToValidate="numOfServingsTextBox"
                        ValidationGroup="recipeGroup" ErrorMessage="<br / > Number of servers is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" 
                        ControlToValidate="numOfServingsTextBox" ValidationExpression="^[1-9]\d$" ForeColor="#CC3300"
                        ErrorMessage="Must be a number" Display="Dynamic"></asp:RegularExpressionValidator>
                
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
        <p>
            Recipe Description:
    <asp:TextBox ID="recipteDescTextBox" runat="server" Columns="80"
        Rows="4" TextMode="MultiLine"></asp:TextBox>
            <asp:RequiredFieldValidator ID="descRequiredFieldValidator" runat="server" ControlToValidate="recipteDescTextBox"
                ValidationGroup="recipeGroup" ErrorMessage="<br / > Description is required" ForeColor="#CC3300"></asp:RequiredFieldValidator>
        </p>
        <uc1:webUserControl runat="server" ID="WebUserControl" />
        <br />
        <asp:Button Font-Bold="True" ID="addRecipeBtn" Text="Add Recipe" OnClick="addBtnClick" runat="server" ValidationGroup="recipeGroup" />
        <asp:Button Font-Bold="True" ID="cancelBtn" runat="server" Text="Cancel" OnClick="cancelBtnClick" />
    </div>

</asp:Content>
