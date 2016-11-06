using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for RecipeRepo
/// </summary>
public class RecipeRepo
{
    public RecipeRepo()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public List<Recipe> Get()
    {
        HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        return (List<Recipe>)webApp.Application["Recipes"];
    }

    public void Update(Recipe recipe)
    {
        
    }
}