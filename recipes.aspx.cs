using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class recipes : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void addBtnClick(object sender, EventArgs e)
    {
        Response.Redirect("addRecipes.aspx");
    }
}