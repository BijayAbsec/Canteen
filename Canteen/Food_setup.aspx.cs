using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Canteen_ENTITY;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Canteen_BAL;

namespace Canteen
{
    public partial class Food_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Food_Entity obj_Food_Entity = new Food_Entity();
        Food_BAL obj_Food_BAL = new Food_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Bindfood();
            }

        }
        private void Bindfood()
        {
            obj_Food_Entity.food_id = 0;
            obj_Food_Entity.flag = "select_all";
            obj_Food_Entity.search_value = txtSearch.Text.Trim();

            RequiredResultData = obj_Food_BAL.Get_Details(obj_Food_Entity);
            ViewState["dtfood"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_food.DataSource = RequiredResultData;
                    Lv_food.DataBind();
                }
                else
                {
                    Lv_food.DataSource = RequiredResultData;
                    Lv_food.DataBind();
                }
            }
            else
            {
                Lv_food.DataSource = RequiredResultData;
                Lv_food.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_Food_Entity.food_id = Convert.ToInt32(hdnfood_Id.Value);
            obj_Food_Entity.food_name = txtfood.Text.Trim();
            obj_Food_Entity.price = Convert.ToDecimal(txtprice.Text.Trim());
            obj_Food_Entity.category = ddlcategory.SelectedValue.ToString();
            obj_Food_Entity.active_status = 1;
            obj_Food_Entity.created_by = 1;
            obj_Food_Entity.flag = "insert_update";
            if (obj_Food_BAL.Add_Edit_Delete(obj_Food_Entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdnfood_Id.Value = "0";
                txtfood.Text = string.Empty;
                txtprice.Text= string.Empty;
                ddlcategory.SelectedValue = "";

                Bindfood();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        

    }
        protected void Lv_food_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string food_id = "";
            ListViewDataItem roleitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (roleitem != null)
                {
                    food_id = (string)Lv_food.DataKeys[roleitem.DisplayIndex][0].ToString().Trim();
                    hdnfood_Id.Value = food_id;
                    ViewState["food_id"] = food_id;

                    obj_Food_Entity.food_id = Convert.ToInt32(food_id);
                    obj_Food_Entity.flag = "select_by_id";

                    RequiredResultData = obj_Food_BAL.Get_Details(obj_Food_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txtfood.Text = RequiredResultData.Rows[0]["food_name"].ToString();
                            txtprice.Text= RequiredResultData.Rows[0]["price"].ToString();
                            ddlcategory.SelectedValue= RequiredResultData.Rows[0]["category"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (roleitem != null)
                {
                    food_id = (string)Lv_food.DataKeys[roleitem.DisplayIndex][0].ToString().Trim();
                    hdnfood_Id.Value = food_id;
                    ViewState["food_id"] = food_id;

                    obj_Food_Entity.food_id = Convert.ToInt32(food_id);
                    obj_Food_Entity.flag = "delete";

                    if (obj_Food_BAL.Add_Edit_Delete(obj_Food_Entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdnfood_Id.Value = "0";

                        Bindfood();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_food_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_food_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_food.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Bindfood();
        }
        protected void Lv_food_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_food_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_food_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindfood();
        }
    }
}