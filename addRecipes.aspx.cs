using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class addRecipes : ThemeClass
{
    private Recipe recipe;
    private List<Recipe> recipes;
    protected void Page_Load(object sender, EventArgs e)
    {
        recipe = new Recipe();

        if (null != Session["ingredients"])
        {
            recipe.Ingredients = (List<Ingredient>)Session["ingredients"];
        }
        else
        {
            recipe.Ingredients = new List<Ingredient>();
        }
        recipes = (List<Recipe>)Application["Recipes"];
    }

    protected void addBtnClick(object sender, EventArgs e)
    {
        recipe.Name = nameOfRecipeTextBox.Text;
        recipe.Owner = submittedByTextBox.Text;
        recipe.Category = categoryTextBox.Text;
        try
        {
            recipe.CookingTime = Int16.Parse(cookingTimeTextBox.Text);
        }
        catch (Exception m)
        {

            recipe.CookingTime=0;
        }
       
        recipe.Servings = Int16.Parse(numOfServingsTextBox.Text);
        recipe.Description = recipteDescTextBox.Text;
        recipes.Add(recipe);
        Session["Ingredients"] = null;
        Response.Redirect("recipes.aspx");
    }

    protected void cancelBtnClick(object sender, EventArgs e)
    {
        Session["Ingredients"] = null;
        Response.Redirect("recipes.aspx");
    }
}