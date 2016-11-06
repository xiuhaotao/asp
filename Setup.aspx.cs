using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Setup : ThemeClass
{
    protected void Page_LoadComplete(object sender, EventArgs e)
    {
    }

    protected void btnBlue_Click(object sender, EventArgs e)
    {
        Session["Theme"] = btnDark.Text;
        Server.Transfer(Request.FilePath);
    }

    protected void btnRed_Click(object sender, EventArgs e)
    {
        Session["Theme"] = btnLight.Text;
        Server.Transfer(Request.FilePath);
    }
}