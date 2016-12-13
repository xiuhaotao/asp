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
using System.Web.Security;
//-- XiurongDeng 300853165--
public partial class Login : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
    }

    protected void submitButton_Click(object sender, EventArgs e)
    {
        string Username = username.Text;
        string Password = password.Text;
        try
        {
            if (ValidateUser(Username, Password))
            {
                FormsAuthentication.RedirectFromLoginPage(Username, false);
            }
            else
            {
                lblMessage.Text = "Incorrect Credentials.";
                
            }
        }
        catch
        {
            lblMessage.Text = "Login Failed.";         
        }
    }

    public Boolean ValidateUser(string author, string pass)
    {

        // List<ListItem> userPassword = new List<ListItem>();
        //string dataPassword;
        string connectionString =
             ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        comm.CommandType = CommandType.Text;

        try
        {
            comm.Connection.Open();
            comm.CommandText = "select password from users where name = '" + author + "'";
            OracleDataReader reader = comm.ExecuteReader();

            //ListItem item = new ListItem(Convert.ToString(reader["NAME"]), Convert.ToString(reader["PASSWORD"]));
            //userPassword.Add(item);
            //  dataPassword = Convert.ToString(reader["PASSWORD"]);
            lblMessage.Text = Convert.ToString(reader["PASSWORD"]);
            reader.Dispose();
        }
        catch (Exception)
        {
        }

        finally
        {
            comm.Connection.Close();
            comm.Connection.Dispose();
        }

       
        if ((lblPass.Text).Equals(pass))
            return true;
        else
            return false;
    }

    }