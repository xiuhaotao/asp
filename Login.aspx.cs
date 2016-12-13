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
            String passwd = "";
            using (OracleDataReader reader = comm.ExecuteReader())
            {
                if (reader.Read())
                {
                    passwd = reader.GetString(0);
                }
            }
            
            if (passwd.Equals(password.Text))
                return true;
            else
                return false;
        }
        catch (Exception ex)
        {
            lblMessage.Text = ex.Message;
        }

        finally
        {
            comm.Connection.Close();
            comm.Connection.Dispose();
        }
        return false;
    }
}