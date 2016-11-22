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
        BindList();
    }
    private void BindList()
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();

        comm.CommandText = "select r.recipeid, r.recipename,r.userID, r.description, r.servingnum, r.cookingminutes, i.name, i.quantity, i.unitOfMeasure from recipes r left join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid left join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID where r.recipeid=" + Request.QueryString["key"];

       // comm.CommandText = "select * from recipes where recipeid=" + Request.QueryString["key"];
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


            // table.Load(reader);
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
}