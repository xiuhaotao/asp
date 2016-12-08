<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="RecipeDetails.aspx.cs" Inherits="RecipeDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
     <asp:DetailsView ID="DetailsViewDetail" runat="server" Height="50px" Width="180px" BackColor="White" BorderColor="#E7E7FF" BorderStyle="Dashed" BorderWidth="1px" CellPadding="3" CellSpacing="2" GridLines="Horizontal" AutoGenerateRows="False" OnModeChanging="DetailsViewDetail_ModeChanging" OnItemUpdating="DetailsViewDetail_ItemUpdating" >
        <CommandRowStyle Font-Size="Medium" HorizontalAlign="Left" />
        <EditRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="#F7F7F7" />
        <FieldHeaderStyle Font-Names="Arial" Font-Size="Small" />
        <Fields>            

            
            <asp:TemplateField HeaderText="recipe_name">
                <EditItemTemplate>
                    <asp:TextBox ID="editRecipename" runat="server" Text='<%# Bind("recipename") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("recipename") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("recipename") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Desc">
                <EditItemTemplate>
                    <asp:TextBox ID="editDesc" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Serving Num">
                <EditItemTemplate>
                    <asp:TextBox TextMode="Number" min="1" max="99" step="1" ID="editNum" runat="server" Text='<%# Bind("servingnum") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox3" runat="server" Text='<%# Bind("servingnum") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("servingnum") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Minutes">
                <EditItemTemplate>
                    <asp:TextBox  TextMode="Number" min="1" max="999" step="1" ID="editMinute" runat="server" Text='<%# Bind("cookingminutes") %>'></asp:TextBox>
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="TextBox4" runat="server" Text='<%# Bind("cookingminutes") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("cookingminutes") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>           

            <asp:TemplateField HeaderText="Category">
                <EditItemTemplate>
                   
                    <asp:DropDownList ID="categoryList" runat="server" DataSourceID="catList" DataTextField="TYPE" DataValueField="CATEGORYID">
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="catList" runat="server" ConflictDetection="CompareAllValues" ConnectionString="<%$ ConnectionStrings:ConnectionString2 %>" DeleteCommand="DELETE FROM &quot;CATEGORIES&quot; WHERE &quot;CATEGORYID&quot; = ? AND ((&quot;TYPE&quot; = ?) OR (&quot;TYPE&quot; IS NULL AND ? IS NULL))" InsertCommand="INSERT INTO &quot;CATEGORIES&quot; (&quot;CATEGORYID&quot;, &quot;TYPE&quot;) VALUES (?, ?)" OldValuesParameterFormatString="original_{0}" ProviderName="<%$ ConnectionStrings:ConnectionString2.ProviderName %>" SelectCommand="SELECT &quot;CATEGORYID&quot;, &quot;TYPE&quot; FROM &quot;CATEGORIES&quot;" UpdateCommand="UPDATE &quot;CATEGORIES&quot; SET &quot;TYPE&quot; = ? WHERE &quot;CATEGORYID&quot; = ? AND ((&quot;TYPE&quot; = ?) OR (&quot;TYPE&quot; IS NULL AND ? IS NULL))">
                        <DeleteParameters>
                            <asp:Parameter Name="original_CATEGORYID" Type="Decimal" />
                            <asp:Parameter Name="original_TYPE" Type="String" />
                            <asp:Parameter Name="original_TYPE" Type="String" />
                        </DeleteParameters>
                        <InsertParameters>
                            <asp:Parameter Name="CATEGORYID" Type="Decimal" />
                            <asp:Parameter Name="TYPE" Type="String" />
                        </InsertParameters>
                        <UpdateParameters>
                            <asp:Parameter Name="TYPE" Type="String" />
                            <asp:Parameter Name="original_CATEGORYID" Type="Decimal" />
                            <asp:Parameter Name="original_TYPE" Type="String" />
                            <asp:Parameter Name="original_TYPE" Type="String" />
                        </UpdateParameters>
                    </asp:SqlDataSource>
                    <div>
                    <asp:TextBox ID="newCate" runat="server" Width="55px"></asp:TextBox>
                    <asp:Button ID="addCate" runat="server" Text="Add New Category" OnClick="btnAddCate_Click" />
                    </div>
                   
                </EditItemTemplate>
                <InsertItemTemplate>
                    <asp:TextBox ID="insertcate" runat="server" Text='<%# Bind("category") %>'></asp:TextBox>
                </InsertItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label5" runat="server" Text=""></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:CommandField ShowEditButton="True" /> 
        </Fields>
        <FooterStyle BackColor="#B5C7DE" ForeColor="#4A3C8C" />
        <HeaderStyle BackColor="#4A3C8C" Font-Bold="True" ForeColor="#F7F7F7" />
        <PagerStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" HorizontalAlign="Right" />
        <RowStyle BackColor="#E7E7FF" ForeColor="#4A3C8C" />
        <HeaderTemplate>
      <%#Eval("Submity_by")%>
    </HeaderTemplate>
    </asp:DetailsView>
    
<asp:Label ID="exception" runat="server" Text=""></asp:Label>
    <asp:Button ID="btnDelete" runat="server" Text="Delete" OnClick="btnDelete_Click" />
    <br />
    <asp:Button ID="btnReturn" runat="server" Text="Return" OnClick="btnReturn_Click" />
    <asp:Label ID="test" runat="server" Text=""></asp:Label>
    <br />
    <h4> Ingredients</h4>
    <asp:gridview ID="ingredientView" runat="server" BackColor="LightGoldenrodYellow" BorderColor="Tan" BorderWidth="1px" CellPadding="2" ForeColor="Black" GridLines="None" OnSelectedIndexChanged="ingredientView_SelectedIndexChanged" AutoGenerateColumns="False" OnRowCancelingEdit="ingredientView_RowCancelingEdit" OnRowEditing="ingredientView_RowEditing" OnRowUpdating="ingredientView_RowUpdating">
        <AlternatingRowStyle BackColor="PaleGoldenrod" />
        <Columns>
            <asp:TemplateField HeaderText="Update">
                <EditItemTemplate>
                    <asp:LinkButton ID="updateIngereLinkButton" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                    &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IngerId">
                <EditItemTemplate>
                    <asp:Label ID="ingerIdd" runat="server" Text='<%# Bind("ingredientid") %>'></asp:Label>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label4" runat="server" Text='<%# Bind("ingredientid") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="IngertientName">
                <EditItemTemplate>
                    <asp:TextBox ID="name" runat="server" Text='<%# Bind("name") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label1" runat="server" Text='<%# Bind("name") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Quantity">
                <EditItemTemplate>
                    <asp:TextBox ID="quantity" runat="server" Text='<%# Bind("quantity") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label2" runat="server" Text='<%# Bind("quantity") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="measurement">
                <EditItemTemplate>
                    <asp:TextBox ID="unitOfMeasure" runat="server" Text='<%# Bind("unitOfMeasure") %>'></asp:TextBox>
                </EditItemTemplate>
                <ItemTemplate>
                    <asp:Label ID="Label3" runat="server" Text='<%# Bind("unitOfMeasure") %>'></asp:Label>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>
        <FooterStyle BackColor="Tan" />
        <HeaderStyle BackColor="Tan" Font-Bold="True" />
        <PagerStyle BackColor="PaleGoldenrod" ForeColor="DarkSlateBlue" HorizontalAlign="Center" />
        <SelectedRowStyle BackColor="DarkSlateBlue" ForeColor="GhostWhite" />
        <SortedAscendingCellStyle BackColor="#FAFAE7" />
        <SortedAscendingHeaderStyle BackColor="#DAC09E" />
        <SortedDescendingCellStyle BackColor="#E1DB9C" />
        <SortedDescendingHeaderStyle BackColor="#C2A47B" />
    </asp:gridview>
     <asp:Label ID="Label6" runat="server" Text="Name: "></asp:Label>
     <asp:TextBox ID="newIngedientName" runat="server"></asp:TextBox>
     <asp:Label ID="Label7" runat="server" Text="Quantity: "></asp:Label>
     <asp:TextBox ID="newQuantity" runat="server" TextMode="Number" min="1" max="99" step="1"></asp:TextBox>
     <asp:Label ID="Label8" runat="server" Text="Measurement: "></asp:Label>
     <asp:TextBox ID="newUnit" runat="server" Width="50px"></asp:TextBox>
     <asp:Button ID="Button1" runat="server" Text="Add" OnClick="Button1_Click" />
</asp:Content>

