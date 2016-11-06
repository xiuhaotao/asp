using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Recipe
{
    private string name;
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    private string owner;
    public string Owner
    {
        get { return owner; }
        set { owner = value; }
    }

    private string category;
    public string Category
    {
        get { return category; }
        set { category = value; }
    }

    private int cookingTime;
    public int CookingTime
    {
        get { return cookingTime; }
        set { cookingTime = value; }
    }

    private int servings;
    public int Servings
    {
        get { return servings; }
        set { servings = value; }
    }

    private string description;
    public string Description
    {
        get { return description; }
        set { description = value; }
    }

    List<Ingredient> ingredients;
    public List<Ingredient> Ingredients
    {
        get { return ingredients; }
        set { ingredients = value; }
    }
}