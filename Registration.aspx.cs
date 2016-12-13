using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Registration : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void submitButton_Click(object sender, EventArgs e)
    {
        if (name.Text.Length > 0 && email.Text.Length > 0 && phone.Text.Length > 0 && password.Text.Length > 5
            && password.Text.Equals(repeatPassword.Text))
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
                comm.CommandText = "select name from users where name='" + name.Text + "'";
                String nameUsed = "";
                using (OracleDataReader reader = comm.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        nameUsed = reader.GetString(0);
                    }
                }
                if (nameUsed.Equals(""))
                {
                    comm.Parameters.Clear();
                    comm.CommandText = "insert into users (userid, name, email, phonenum, password) values(users_id_seq.nextval, '"
                        + name.Text + "', '" + email.Text + "', '" + phone.Text + "', '" + password.Text + "')";
                    comm.ExecuteNonQuery();
                    Response.Redirect("Login.aspx");
                }
                else
                {
                    lblMessage.Text = "Register fail, user name is already used";
                }
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
        }
        else
        {
            lblMessage.Text = "Register fail, You should fill all of the field, the password length should more than 6.";
        }
    }
}