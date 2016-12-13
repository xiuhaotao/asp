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
public partial class search : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            
            List<ListItem> userListModel = new List<ListItem>();
            List<ListItem> categoryListModel = new List<ListItem>();
            List<ListItem> ingredientListModel = new List<ListItem>();

            userListModel.Add(new ListItem("ALL", "0"));
            categoryListModel.Add(new ListItem("ALL", "0"));
            ingredientListModel.Add(new ListItem("ALL", "0"));
            string connectionString =
            ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            OracleCommand comm = conn.CreateCommand();
            comm.CommandType = CommandType.Text;

            try
            {
                comm.Connection.Open();
                comm.CommandText = "select name, userid from users";

                OracleDataReader reader = comm.ExecuteReader();
                while (reader.Read())
                {
                    ListItem itemUser = new ListItem(Convert.ToString(reader["NAME"]), Convert.ToString(reader["USERID"]));
                
                    userListModel.Add(itemUser);
                }
                reader.Dispose();
                comm.Parameters.Clear();
                    comm.CommandText = "select type, categoryid from categories";
                    comm.CommandType = CommandType.Text;

                OracleDataReader reader2 = comm.ExecuteReader();
                while (reader2.Read())
                    {
                        ListItem itemCategory = new ListItem(Convert.ToString(reader2["type"]), Convert.ToString(reader2["categoryid"]));
                        categoryListModel.Add(itemCategory);
                    }
                    reader2.Dispose();
                    comm.Parameters.Clear();

                
                comm.CommandType = CommandType.Text;

                comm.CommandText = "select name, ingredientid from ingredients";
                OracleDataReader reader3 = comm.ExecuteReader();
                while (reader3.Read())
                    {
                        ListItem item = new ListItem(Convert.ToString(reader3["NAME"]), Convert.ToString(reader3["ingredientid"]));
                        ingredientListModel.Add(item);
                    }
                    reader3.Dispose();                
            }

            catch (Exception)
            {
            }

            finally
            {
                comm.Connection.Close();
                comm.Connection.Dispose();
            }
            submitList.DataSource = userListModel;
            submitList.DataBind();
            submitList.SelectedIndex = 0;
            categoryList.DataSource = categoryListModel;
            categoryList.DataBind();
            categoryList.SelectedIndex = 0;
            ingredientList.DataSource = ingredientListModel;
            ingredientList.DataBind();
            ingredientList.SelectedIndex = 0;
        }
    }
    private void BindList()
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();

        comm.CommandText = "select distinct u.name submitter,r.recipeid id, r.recipename recipe, c.type category, ig.name ingredient from recipes r left join users u on r.userid = u.userid left join categories c on r.categoryid = c.categoryid left join recipeslinkingredients i on r.recipeid = i.recipeid left join ingredients ig on ig.ingredientid = i.ingredientid where ";
        comm.CommandText += submitList.SelectedItem.Value.Equals("0") ? "1=1" : "u.userid = " + submitList.SelectedItem.Value;
        comm.CommandText += categoryList.SelectedItem.Value.Equals("0") ? " and 1=1" : " and r.categoryid = " + categoryList.SelectedItem.Value;
        comm.CommandText += ingredientList.SelectedItem.Value.Equals("0") ? " and 1=1" : " and i.ingredientid = " + ingredientList.SelectedItem.Value;
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

    protected void searchBtn_Click(object sender, EventArgs e)
    {
        BindList();
    }

    protected void GridViewRecipe_SelectedIndexChanged(object sender, EventArgs e)
    {
        
    
        int selectedIndex = GridViewRecipe.SelectedIndex;
        GridViewRow row = GridViewRecipe.Rows[selectedIndex];
        string key = row.Cells[2].Text;
        Response.Redirect("RecipeDetails.aspx?Key=" + key);
    }

}