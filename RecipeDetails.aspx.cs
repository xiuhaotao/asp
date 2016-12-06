﻿using System;
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


public partial class RecipeDetails : ThemeClass
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindList();
           
        }
       
    }
   
    private void BindList()
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();
        OracleDataReader reader;
        DataTable table;
        table = new DataTable();
        try
        {            
        comm.CommandText = "select u.name as Submity_by, c.type as category, r.recipeid,  r.categoryid, r.recipename,r.userID, r.description, r.servingnum, r.cookingminutes from recipes r right outer join users u on r.userid = u.userid join categories c on c.categoryid = r.categoryid  join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID  where r.recipeid=" + Request.QueryString["key"];
      
        comm.CommandType = CommandType.Text;

         comm.Connection.Open();
         reader= comm.ExecuteReader();           
            table.Load(reader);
        }
        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }
        catch (Exception ex)
        {

            exception.Text = ex.Message;
        }
       
        DetailsViewDetail.DataSource = table;
        DetailsViewDetail.DataBind();

        DataTable table2;
        table2 = new DataTable();
        try
        {
            comm.CommandText = "select i.name, i.quantity, i.unitOfMeasure from recipes r right outer join recipesLinkIngredients on r.recipeid = recipesLinkIngredients.recipeid right outer join ingredients i on recipesLinkIngredients.ingredientID = i.ingredientID where r.recipeid=" + Request.QueryString["key"];

            comm.CommandType = CommandType.Text;

            reader = comm.ExecuteReader();
            table2.Load(reader);
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
        ingredientView.DataSource = table2;
        ingredientView.DataBind();


     /*   DataTable table3;
        table3 = new DataTable();
        try
        {
            comm.CommandText = "select type from categories";
            comm.CommandType = CommandType.Text;

            reader = comm.ExecuteReader();
            table3.Load(reader);
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
       // (DataList)DetailsViewDetail.FindControl("cateList").DataSource = table2;
      //  cateList.DataBind();*/

    }

    protected void btnDelete_Click(object sender, EventArgs e)
    {
         
    
        string connectionString =
        ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
        OracleConnection conn = new OracleConnection();
        conn.ConnectionString = connectionString;
        OracleCommand comm = conn.CreateCommand();

        comm.CommandText = "delete from recipes where recipeid=" + Request.QueryString["key"];
        comm.CommandType = CommandType.Text;


        DataTable table;
        table = new DataTable();
        try
        {

            comm.Connection.Open();
            OracleDataReader reader = comm.ExecuteReader();


            // table.Load(reader);
            table.Load(reader);
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
        DetailsViewDetail.DataSource = table;
        DetailsViewDetail.DataBind();
    }

    protected void btnReturn_Click(object sender, EventArgs e)
    {
        Response.Redirect("recipes.aspx");
    }

    protected void DetailsViewDetail_ModeChanging(object sender, DetailsViewModeEventArgs e)
    {
        DetailsViewDetail.ChangeMode(e.NewMode);
        BindList();
    }

    protected void DetailsViewDetail_ItemUpdating(object sender, DetailsViewUpdateEventArgs e)
    {
        
            TextBox newRecipeName = (TextBox)DetailsViewDetail.FindControl("editRecipename");
            TextBox newDesc = (TextBox)DetailsViewDetail.FindControl("editDesc");
            TextBox newNum = (TextBox)DetailsViewDetail.FindControl("editNum");
            TextBox neweditMinute = (TextBox)DetailsViewDetail.FindControl("editMinute");

            TextBox newEditCate = (TextBox)DetailsViewDetail.FindControl("editCate");
            DropDownList newSeleCat = (DropDownList)DetailsViewDetail.FindControl("categoryList");

        newEditCate.Text = newSeleCat.SelectedValue;
       


        string newReName = newRecipeName.Text;
            string newDes = newDesc.Text;
            int servingNum = int.Parse(newNum.Text);
            int minute = int.Parse(neweditMinute.Text);
        string categ = newEditCate.Text;

       /* if (newSeleCat.SelectedIndex != -1)
        {
            categ = newSeleCat.SelectedValue.ToString();
        } else
        {
            categ =  newEditCate.Text;
        }*/

        string connectionString =
             ConfigurationManager.ConnectionStrings["ConnectionString2"].ConnectionString;
            OracleConnection conn = new OracleConnection();
            conn.ConnectionString = connectionString;
            OracleCommand comm = conn.CreateCommand();
        try
        {
            comm.Connection.Open();
            comm.CommandType = CommandType.Text;
            
            comm.CommandType = CommandType.Text;
            comm.CommandText = "update recipes set recipename = ' " + newReName + "' , description = '" + newDes + "', servingnum = " + servingNum + ", cookingminutes = " + minute +  " where recipeid = " + Request.QueryString["key"];
            comm.ExecuteNonQuery();
            comm.Parameters.Clear();
            comm.CommandText = "update categories set type = ' " + categ + "'where categories.categoryid = (select  categoryid from recipes where recipes.recipeid = " + Request.QueryString["key"]+")";
            comm.ExecuteNonQuery();
        }

        catch (SqlException ex)
        {
            exception.Text = ex.Message;
        }
        
        finally
        {
            comm.Connection.Close();
        }
        BindList();
    }





    //protected void categoryList_TextChanged(object sender, EventArgs e)
    //{
    //    int index = Convert.ToInt32(e.SelectValue);
    //}

    //protected void categoryList_SelectedIndexChanged(object sender, EventArgs e)
    //{

    //    DropDownList1.SelectedIndex = DropDownList1.Items.IndexOf(DropDownList1.Items.FindByText("your default selected text"));
    //}

    protected void insertIngre_Click(object sender, EventArgs e)
    {

    }
}