using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ThemeClass
/// </summary>

public class ThemeClass : System.Web.UI.Page
{
    protected void Page_PreInit(object sender, EventArgs e)
    {
        if (Session["Theme"] != null)
        {
            Page.Theme = Session["Theme"].ToString();
        }
        else
        {
            Page.Theme = "Light";
        }
    }
}