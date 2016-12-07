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
        DataTable table;
        table = new DataTable();
        try
        {
            comm.CommandText = "select u.name as Submity_by, c.type as category, r.recipeid,  r.categoryid, r.recipename,r.userID, r.description, r.servingnum, r.cookingminutes from recipes r right outer join users u on r.userid = u.userid join categories c on c.categoryid = r.categoryid  join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID  where r.recipeid=" + Request.QueryString["key"];

            comm.CommandType = CommandType.Text;

            comm.Connection.Open();
            reader = comm.ExecuteReader();
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

        DetailsViewDetail.DataSource = table;
        DetailsViewDetail.DataBind();

        DataTable table2;
        table2 = new DataTable();
        try
        {
            comm.CommandText = "select i.name, i.quantity, i.unitOfMeasure, r.categoryid, c.type from recipes r left join categories c on c.categoryid = r.categoryid right outer join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID where r.recipeid=" + Request.QueryString["key"];
            comm.CommandType = CommandType.Text;
            reader = comm.ExecuteReader();
            table2.Load(reader);
            Label category = (Label)DetailsViewDetail.FindControl("Label5");
            if (category != null)
            {
                category.Text = table2.Rows[0]["type"].ToString();
            }
            DropDownList newSeleCat = (DropDownList)DetailsViewDetail.FindControl("categoryList");
            if (newSeleCat != null)
            {
                ListItem selectedListItem = newSeleCat.Items.FindByValue(table2.Rows[0]["categoryid"].ToString());
                if (selectedListItem != null)
                {
                    selectedListItem.Selected = true;
                }
            }
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
        ingredientView.DataSource = table2;
        ingredientView.DataBind();
        
    }

    protected void btnAddCate_Click(object sender, EventArgs e)
    {
        DropDownList newSeleCat = (DropDownList)DetailsViewDetail.FindControl("categoryList");
        String value = newSeleCat.SelectedValue;
        TextBox newCate = (TextBox)DetailsViewDetail.FindControl("newCate");
        if (newCate.Text.Length > 0)
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
            DropDownList categoryDropList = (DropDownList)DetailsViewDetail.FindControl("categoryList");
            categoryDropList.DataBind();
            newCate.Text = "";
            
            if (newSeleCat != null)
            {
                ListItem selectedListItem = newSeleCat.Items.FindByValue(value);
                if (selectedListItem != null)
                {
                    selectedListItem.Selected = true;
                }
            }
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

    protected void insertIngre_Click(object sender, EventArgs e)
    {

    }
}