using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;


public partial class RecipeDetails : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
        }

    }

    private void BindList()
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        OracleDataReader reader;
        DataTable recipeDetailTable = new DataTable();
        DataTable categoryTable = new DataTable();
        DataTable ingredientsTable = new DataTable();
        DataTable listTable = new DataTable();

        try
        {
            // load recipe data
            comm.CommandText = "select u.name as Submity_by, c.type as category, r.recipeid,  r.categoryid, r.recipename,r.userID, r.description, r.servingnum, r.cookingminutes from recipes r right outer join users u on r.userid = u.userid join categories c on c.categoryid = r.categoryid  join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID  where r.recipeid=" + Request.QueryString["key"];
            comm.CommandType = CommandType.Text;
            comm.Connection.Open();
            reader = comm.ExecuteReader();
            recipeDetailTable.Load(reader);
            // bind recipe detail view
            DetailsViewDetail.DataSource = recipeDetailTable;
            DetailsViewDetail.DataBind();

            // load selected category data
            comm.Parameters.Clear();
            comm.CommandText = "select r.categoryid, c.type from recipes r left join categories c on c.categoryid = r.categoryid right outer join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID where r.recipeid=" + Request.QueryString["key"];
            reader = comm.ExecuteReader();
            categoryTable.Load(reader);
            // load category list data
            comm.Parameters.Clear();
            comm.CommandText = "select categoryid, type from categories";
            reader = comm.ExecuteReader();
            listTable.Load(reader);
            // bind category label (normal mode) and category droplist (edit mode)
            Label category = (Label)DetailsViewDetail.FindControl("catgoryLabel");
            if (category != null)
            {
                category.Text = categoryTable.Rows[0]["type"].ToString();
            }
            DropDownList categoryDropList = (DropDownList)DetailsViewDetail.FindControl("categoryList");
            if (categoryDropList != null)
            {
                categoryDropList.DataSource = listTable;
                categoryDropList.DataTextField = "Type";
                categoryDropList.DataValueField = "categoryid";
                categoryDropList.DataBind();
                ListItem selectedListItem = categoryDropList.Items.FindByValue(categoryTable.Rows[0]["categoryid"].ToString());
                if (selectedListItem != null)
                {
                    selectedListItem.Selected = true;
                }
            }

            // load ingredients data
            comm.Parameters.Clear();
            comm.CommandText = "select ingredients.ingredientid,ingredients.name,ingredients.quantity,ingredients.unitofmeasure from ingredients join recipesLinkIngredients on ingredients.INGREDIENTID = recipesLinkIngredients.INGREDIENTID where recipesLinkIngredients .recipeid = " + Request.QueryString["key"];
            reader = comm.ExecuteReader();
            ingredientsTable.Load(reader);
            // bind ingredientView
            ingredientView.DataSource = ingredientsTable;
            ingredientView.DataBind();
        }
        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }
        catch (Exception ex)
        {
            exception.Text = ex.Message;
        }
        finally
        {
            comm.Connection.Close();
        }        
    }

    protected void btnAddCate_Click(object sender, EventArgs e)
    {
        DropDownList newSeleCat = (DropDownList)DetailsViewDetail.FindControl("categoryList");
        String value = newSeleCat.SelectedValue;
        TextBox newCate = (TextBox)DetailsViewDetail.FindControl("newCate");
        if (newCate.Text.Length > 0 && null == newSeleCat.Items.FindByText(newCate.Text))
        {
            string connectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            OracleCommand comm = conn.CreateCommand();
            comm.CommandText = "insert into categories (categoryid, type, typedesc) values (category_id_seq.nextval, '" + newCate.Text + "', '" + newCate.Text + "')";
            comm.CommandType = CommandType.Text;
            
            DataTable table;
            table = new DataTable();
            try
            {
                comm.Connection.Open();
                OracleDataReader reader = comm.ExecuteReader();
                table.Load(reader);
                newSeleCat.DataBind();
                newSeleCat.Items.FindByText(newCate.Text).Selected = true;
            }
            catch (SqlException ex)
            {
                exception.Text = ex.Message;
            }
            catch (Exception ex)
            {

                exception.Text = ex.Message;
            }
            finally
            {
                newCate.Text = "";
                comm.Connection.Close();
            }            
        } else
        {
            newCate.Text = "";
        }
    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();

        comm.CommandText = "delete from recipes where recipeid=" + Request.QueryString["key"];
        comm.CommandType = CommandType.Text;


        DataTable table;
        table = new DataTable();
        try
        {

            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();
            table.Load(reader);
        }
        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }
        catch (Exception ex)
        {

            exception.Text = ex.Message;
        }
        finally
        {
            comm.Connection.Close();
        }
        DetailsViewDetail.DataSource = table;
        DetailsViewDetail.DataBind();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("recipes.aspx");
    }

    protected void DetailsViewDetail_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsViewDetail.ChangeMode(e.NewMode);
        BindList();
    }

    protected void DetailsViewDetail_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        TextBox newRecipeName = (TextBox)DetailsViewDetail.FindControl("editRecipename");
        TextBox newDesc = (TextBox)DetailsViewDetail.FindControl("editDesc");
        TextBox newNum = (TextBox)DetailsViewDetail.FindControl("editNum");
        TextBox neweditMinute = (TextBox)DetailsViewDetail.FindControl("editMinute");

        DropDownList newSeleCat = (DropDownList)DetailsViewDetail.FindControl("categoryList");

        string newReName = newRecipeName.Text;
        string newDes = newDesc.Text;
        int servingNum = int.Parse(newNum.Text);
        int minute = int.Parse(neweditMinute.Text);
        string categ = newSeleCat.SelectedValue;

        string connectionString =
             ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.Connection.Open();
            comm.CommandType = CommandType.Text;

            comm.CommandType = CommandType.Text;
            comm.CommandText = "update recipes set recipename='" + newReName + "' , description='" + newDes + "', servingnum=" + servingNum + ", cookingminutes=" + minute + ", categoryid='" + categ + "' where recipeid = " + Request.QueryString["key"];
            comm.ExecuteNonQuery();
        }

        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }

        finally
        {
            comm.Connection.Close();
        }
        BindList();

    }

    protected void ingredientView_RowEditing(object sender, GridViewEditEventArgs e)
    {
        ingredientView.EditIndex = e.NewEditIndex;

        BindList();
    }

    protected void ingredientView_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
       
      GridViewRow row = ingredientView.Rows[e.RowIndex];
      Label Id = (Label)row.FindControl("ingerIdd");
        
        TextBox updateName = (TextBox)row.FindControl("name");
        TextBox updateQuan = (TextBox)row.FindControl("quantity");
        TextBox UpdateUnit = (TextBox)row.FindControl("unitOfMeasure");
        int ingerID = int.Parse(Id.Text);
        string name = updateName.Text;
        int quan = int.Parse(updateQuan.Text);
        string measure = UpdateUnit.Text;

        string connectionString =
             ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.Connection.Open();
            comm.CommandType = CommandType.Text;
            comm.CommandText = "update ingredients set name ='" + name + "' , quantity=" + quan + ", unitofmeasure= '" + measure + "' where ingredientid = " + ingerID;
            comm.ExecuteNonQuery();
            ingredientView.EditIndex = -1;
        }

        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }

        finally
        {
            comm.Connection.Close();
        }
        BindList();
    }

    protected void ingredientView_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
    {
        ingredientView.EditIndex = -1;
        BindList();
    }

    protected void addButton_Click(object sender, EventArgs e)
    {
        DataTable table3;
        table3 = new DataTable();
        string connectionString =
             ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleDataReader reader;
        OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.Connection.Open();
            comm.CommandType = CommandType.Text;

            comm.CommandType = CommandType.Text;
            comm.CommandText = "insert into ingredients (ingredientid, name, quantity, unitofmeasure) values(ingredients_id_seq.nextval, '" + newIngedientName.Text + "', " + int.Parse(newQuantity.Text) + ", '" + newUnit.Text + "')";
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            comm.CommandText = "insert into recipeslinkingredients(recipeid, ingredientid) values(" + int.Parse(Request.QueryString["key"]) + ", ingredients_id_seq.currval)";
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            comm.CommandText = "select ingredients.ingredientid,ingredients.name,ingredients.quantity,ingredients.unitofmeasure from ingredients join recipesLinkIngredients on ingredients.INGREDIENTID = recipesLinkIngredients.INGREDIENTID where recipesLinkIngredients .recipeid = " + Request.QueryString["key"];
            comm.CommandType = CommandType.Text;
            reader = comm.ExecuteReader();
            table3.Load(reader);
            ingredientView.DataSource = table3;
            ingredientView.DataBind();
            newIngedientName.Text = "";
            newQuantity.Text = "";
            newUnit.Text = ""; 
        }

        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }

        finally
        {
            comm.Connection.Close();
        }
    }

    protected void DetailsViewDetail_ModeChanged(object sender, EventArgs e)
    {
       

    }
}
