using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class WebUserControl : System.Web.UI.UserControl
{
    protected List<Ingredient> ingredients;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Ingredients"] != null)
        {
            ingredients = (List<Ingredient>)Session["Ingredients"];
        }
        else
        {
            ingredients = new List<Ingredient>();
            Session["Ingredients"] = ingredients;
        }
        
    }

    protected void addBtnClick(object sender, EventArgs e)
    {
        Ingredient item = new Ingredient();
        item.Name = nameText.Text;
        item.Quantity = quantityText.Text;
        item.Unit = unitText.Text;
        if (item.Name.Length + item.Quantity.Length + item.Unit.Length > 0)
        {
            ingredients.Add(item);
            ListView1.DataBind();
            nameText.Text = "";
            quantityText.Text = "";
            unitText.Text = "";
        }        
        if (15 == ingredients.Count)
        {
            nameText.Enabled = false;
            quantityText.Enabled = false;
            unitText.Enabled = false;
            addBtn.Enabled = false;
        }
    }
}