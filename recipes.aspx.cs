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

// XiurongDeng 300853165

public partial class recipes : ThemeClass
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
      
        
       comm.CommandText = "select c.type, r.recipeid,r.recipename,r.categoryid, u.name from categories c join  recipes r on c.categoryid = r.categoryid join users u on  r.userid = u.userid";
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
        GridViewRecipe.DataSource = table;
        GridViewRecipe.DataBind();
    }

    

    protected void GridViewRecipe_SelectedIndexChanged(object sender, EventArgs e)
    {
        int selectedIndex = GridViewRecipe.SelectedIndex;
        GridViewRow row = GridViewRecipe.Rows[selectedIndex];
        string key = row.Cells[2].Text;
        Response.Redirect("RecipeDetails.aspx?Key=" + key);
    }
}