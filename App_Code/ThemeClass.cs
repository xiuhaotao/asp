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
        HttpCookie themeCookie;
        themeCookie = Request.Cookies["Theme"];
        if (themeCookie != null)
        {
            Page.Theme = themeCookie.Value;
        }
        else
        {
            themeCookie = new HttpCookie("Theme", "Light");
            themeCookie.Expires = DateTime.Now.AddMonths(1);
            Response.Cookies.Add(themeCookie);
            Page.Theme = "Light";
        }
    }
}