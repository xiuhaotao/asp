<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecipeDetails1.aspx.cs" Inherits="RecipeDetails1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:DetailsView ID="DetailsView1" runat="server" DataSourceID="SqlDataSourceRecipe" Height="50px" Width="219px" AutoGenerateRows="False" DataKeyNames="RECIPEID">
        <Fields>
            <asp:BoundField DataField="RECIPEID" HeaderText="RECIPEID" ReadOnly="True" SortExpression="RECIPEID" />
            <asp:BoundField DataField="RECIPENAME" HeaderText="RECIPENAME" SortExpression="RECIPENAME" />
            <asp:BoundField DataField="USERID" HeaderText="USERID" SortExpression="USERID" />
            <asp:BoundField DataField="DESCRIPTION" HeaderText="DESCRIPTION" SortExpression="DESCRIPTION" />
            <asp:BoundField DataField="SERVINGNUM" HeaderText="SERVINGNUM" SortExpression="SERVINGNUM" />
            <asp:BoundField DataField="COOKINGMINUTES" HeaderText="COOKINGMINUTES" SortExpression="COOKINGMINUTES" />
            <asp:BoundField DataField="CATEGORYID" HeaderText="CATEGORYID" SortExpression="CATEGORYID" />
            <asp:BoundField DataField="CREATEDATE" HeaderText="CREATEDATE" SortExpression="CREATEDATE" />
            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowInsertButton="True" />
            <asp:TemplateField HeaderText="x">
                <ItemTemplate>
                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="INGREDIENTID" DataSourceID="SqlDataSourceIngredients">
                        <Columns>
                            <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                            <asp:BoundField DataField="INGREDIENTID" HeaderText="INGREDIENTID" ReadOnly="True" SortExpression="INGREDIENTID" />
                            <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                            <asp:BoundField DataField="QUANTITY" HeaderText="QUANTITY" SortExpression="QUANTITY" />
                            <asp:BoundField DataField="UNITOFMEASURE" HeaderText="UNITOFMEASURE" SortExpression="UNITOFMEASURE" />
                        </Columns>
                    </asp:GridView>
                </ItemTemplate>
            </asp:TemplateField>
        </Fields>
    </asp:DetailsView>
    <asp:SqlDataSource ID="SqlDataSourceIngredients" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM &quot;INGREDIENTS&quot; WHERE &quot;INGREDIENTID&quot; = ?" InsertCommand="INSERT INTO &quot;INGREDIENTS&quot; (&quot;INGREDIENTID&quot;, &quot;NAME&quot;, &quot;QUANTITY&quot;, &quot;UNITOFMEASURE&quot;) VALUES (?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;INGREDIENTS&quot;" UpdateCommand="UPDATE &quot;INGREDIENTS&quot; SET &quot;NAME&quot; = ?, &quot;QUANTITY&quot; = ?, &quot;UNITOFMEASURE&quot; = ? WHERE &quot;INGREDIENTID&quot; = ?">
        <DeleteParameters>
            <asp:Parameter Name="INGREDIENTID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="INGREDIENTID" Type="Decimal" />
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="QUANTITY" Type="Decimal" />
            <asp:Parameter Name="UNITOFMEASURE" Type="String" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="NAME" Type="String" />
            <asp:Parameter Name="QUANTITY" Type="Decimal" />
            <asp:Parameter Name="UNITOFMEASURE" Type="String" />
            <asp:Parameter Name="INGREDIENTID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    <asp:SqlDataSource ID="SqlDataSourceRecipe" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM &quot;RECIPES&quot; WHERE &quot;RECIPEID&quot; = ?" InsertCommand="INSERT INTO &quot;RECIPES&quot; (&quot;RECIPEID&quot;, &quot;RECIPENAME&quot;, &quot;USERID&quot;, &quot;DESCRIPTION&quot;, &quot;SERVINGNUM&quot;, &quot;COOKINGMINUTES&quot;, &quot;CATEGORYID&quot;, &quot;CREATEDATE&quot;) VALUES (?, ?, ?, ?, ?, ?, ?, ?)" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT * FROM &quot;RECIPES&quot;" UpdateCommand="UPDATE &quot;RECIPES&quot; SET &quot;RECIPENAME&quot; = ?, &quot;USERID&quot; = ?, &quot;DESCRIPTION&quot; = ?, &quot;SERVINGNUM&quot; = ?, &quot;COOKINGMINUTES&quot; = ?, &quot;CATEGORYID&quot; = ?, &quot;CREATEDATE&quot; = ? WHERE &quot;RECIPEID&quot; = ?">
        <DeleteParameters>
            <asp:Parameter Name="RECIPEID" Type="Decimal" />
        </DeleteParameters>
        <InsertParameters>
            <asp:Parameter Name="RECIPEID" Type="Decimal" />
            <asp:Parameter Name="RECIPENAME" Type="String" />
            <asp:Parameter Name="USERID" Type="Decimal" />
            <asp:Parameter Name="DESCRIPTION" Type="String" />
            <asp:Parameter Name="SERVINGNUM" Type="Decimal" />
            <asp:Parameter Name="COOKINGMINUTES" Type="Decimal" />
            <asp:Parameter Name="CATEGORYID" Type="Decimal" />
            <asp:Parameter Name="CREATEDATE" Type="DateTime" />
        </InsertParameters>
        <UpdateParameters>
            <asp:Parameter Name="RECIPENAME" Type="String" />
            <asp:Parameter Name="USERID" Type="Decimal" />
            <asp:Parameter Name="DESCRIPTION" Type="String" />
            <asp:Parameter Name="SERVINGNUM" Type="Decimal" />
            <asp:Parameter Name="COOKINGMINUTES" Type="Decimal" />
            <asp:Parameter Name="CATEGORYID" Type="Decimal" />
            <asp:Parameter Name="CREATEDATE" Type="DateTime" />
            <asp:Parameter Name="RECIPEID" Type="Decimal" />
        </UpdateParameters>
    </asp:SqlDataSource>
    </asp:Content>