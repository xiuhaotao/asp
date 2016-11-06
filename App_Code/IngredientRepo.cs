using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
public class IngredientRepo
{
    public List<Ingredient> Get()
    {
        HttpApplication webApp = HttpContext.Current.ApplicationInstance;
        return (List<Ingredient>)webApp.Session["Ingredients"];
    }

    public void Update(Ingredient ingredient)
    {
       
    }
}