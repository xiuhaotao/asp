using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

public class Ingredient
{
    private string name;
    private string quantity;
    private string unit;

    public Ingredient()
    {
        name = "";
        quantity = "";
        unit = "";
    }

    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    public string Quantity
    {
        get { return quantity; }
        set { quantity = value; }
    }

    public string Unit
    {
        get { return unit; }
        set { unit = value; }
    }
}