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
            recipe.CookingTime = 0;
        }

        recipe.Servings = Int16.Parse(numOfServingsTextBox.Text);
        recipe.Description = recipteDescTextBox.Text;
        recipes.Add(recipe);

        string connectionString =
          ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        comm.Connection.Open();

        comm.CommandType = CommandType.Text;
        try
        {
            comm.CommandText = "insert into categories (categoryid, type) values (category_id_seq.nextval, " + " ' " + categoryTextBox.Text + " ' )";
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            comm.CommandText = "insert into users (userid, name) values (users_id_seq.nextval , ' " + submittedByTextBox.Text + " ' )";
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            comm.CommandText = "insert into recipes(recipeID,recipename,cookingminutes,servingnum, description,userid,categoryid) values ( recipes_id_seq.nextval, " + " ' " + nameOfRecipeTextBox.Text + " ' , " + Int16.Parse(cookingTimeTextBox.Text) + " ," + Int16.Parse(numOfServingsTextBox.Text) + " , ' " + recipteDescTextBox.Text + " ' " + ",users_id_seq.currval, category_id_seq.currval)";
            comm.ExecuteNonQuery();
            if (recipe.Ingredients.Count > 0)
            {
                foreach (Ingredient i in recipe.Ingredients)
                {
                    comm.Parameters.Clear();
                    comm.CommandText = "insert into ingredients (ingredientID,name, quantity, unitofmeasure) values (ingredients_id_seq.NEXTVAL," + "'" + i.Name + "'," + i.Quantity + ",'" + i.Unit + "') ";
                    comm.ExecuteNonQuery();
                    comm.Parameters.Clear();
                    comm.CommandText = "insert into RECIPESLINKINGREDIENTS values(default, recipes_id_seq.currval,ingredients_id_seq.CURRVAL)";
                    comm.ExecuteNonQuery();

                }
            }

            


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
        Session["Ingredients"] = null;
        Response.Redirect("recipes.aspx");
    }

    protected void cancelBtnClick(object sender, EventArgs e)
    {
        Session["Ingredients"] = null;
        Response.Redirect("recipes.aspx");
    }
}