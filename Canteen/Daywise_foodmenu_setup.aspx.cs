using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Canteen_ENTITY;
using Canteen_BAL;

namespace Canteen
{
    public partial class Daywise_foodmenu_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity = new Daywise_foodmenu_Entity();
        Daywise_foodmenu_BAL obj_Daywise_foodmenu_BAL = new Daywise_foodmenu_BAL();

        Food_Entity obj_Food_Entity = new Food_Entity();
        Food_BAL obj_Food_BAL = new Food_BAL();

        Time_Entity obj_Time_Entity = new Time_Entity();
        Time_BAL obj_Time_BAL = new Time_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"].ToString() != null)
                {
                    BindFood();
                    BindTime();
                    BindDaywise_foodmenuList();
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }

        protected void BindFood()
        {
            obj_Food_Entity.food_id = 0;
            obj_Food_Entity.flag = "view_all_active";

            RequiredResultData = obj_Food_BAL.Get_Details(obj_Food_Entity);

            ddlfoodid.Items.Clear();
            ddlfoodid.DataSource = RequiredResultData;
            ddlfoodid.DataValueField = "Food_id";
            ddlfoodid.DataTextField = "Food_Name";
            //txtprice.dtatextField = "Price";
            ddlfoodid.DataBind();
            ddlfoodid.Items.Insert(0, "--Select--");
            ddlfoodid.Items[0].Value = "0";
            ddlfoodid.Items[0].Selected = true;
        }

        protected void BindTime()
        {
            obj_Time_Entity.time_id = 0;
            obj_Time_Entity.flag = "view_all_active";

            RequiredResultData = obj_Time_BAL.Get_Details(obj_Time_Entity);

            ddltimeid.Items.Clear();
            ddltimeid.DataSource = RequiredResultData;
            ddltimeid.DataValueField = "Time_id";
            ddltimeid.DataTextField = "Time_Name";
            ddltimeid.DataBind();
            ddltimeid.Items.Insert(0, "--Select--");
            ddltimeid.Items[0].Value = "0";
            ddltimeid.Items[0].Selected = true;
        }

        protected void BindDaywise_foodmenuList()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.flag = "select_all_active";
            obj_Daywise_foodmenu_Entity.search_value = txtSearch.Text.Trim();

            RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);
            ViewState["dtcont"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_Daywise_foodmenu.DataSource = RequiredResultData;
                    Lv_Daywise_foodmenu.DataBind();
                }
                else
                {
                    Lv_Daywise_foodmenu.DataSource = RequiredResultData;
                    Lv_Daywise_foodmenu.DataBind();
                }
            }
            else
            {
                Lv_Daywise_foodmenu.DataSource = RequiredResultData;
                Lv_Daywise_foodmenu.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //object hdnfoodmenu_id = null;
            obj_Daywise_foodmenu_Entity.foodmenu_id = Convert.ToInt32(hdnfoodmenu_id.Value);
            obj_Daywise_foodmenu_Entity.food_id = Convert.ToInt32(ddlfoodid.SelectedValue.ToString());
            obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
            obj_Daywise_foodmenu_Entity.category = ddlcategory.SelectedValue.ToString();
            obj_Daywise_foodmenu_Entity.active_status = 1;
            obj_Daywise_foodmenu_Entity.created_by = 1;
            obj_Daywise_foodmenu_Entity.flag = "insert_update";
            if (obj_Daywise_foodmenu_BAL.Add_Edit_Delete(obj_Daywise_foodmenu_Entity))
            {
                lblMessage.Text = "Saved successfully.";
                IntializeAllIds();
                BindDaywise_foodmenuList();
            }
            else
            {
                lblMessage.Text = "Error in Insert.";
            }
        }

        protected void IntializeAllIds()
        {
            ddlfoodid.Text = "0";
            ddltimeid.Text = "0";
            hdnfoodmenu_id.Value = "0";
            ddlcategory.DataValueField = "0";
        }

        protected void Lv_Daywise_foodmenu_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string food_menu_id = "";
            ListViewDataItem Daywise_foodmenuItems = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (Daywise_foodmenuItems != null)
                {
                    food_menu_id = (string)Lv_Daywise_foodmenu.DataKeys[Daywise_foodmenuItems.DisplayIndex][0].ToString().Trim();
                    hdnfoodmenu_id.Value = food_menu_id;
                    ViewState["food_menu_id"] = food_menu_id;

                    obj_Daywise_foodmenu_Entity.foodmenu_id = Convert.ToInt32(food_menu_id);
                    obj_Daywise_foodmenu_Entity.flag = "view_by_id";

                    RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            ddlfoodid.SelectedValue = RequiredResultData.Rows[0]["food_id"].ToString();
                            ddlcategory.SelectedValue = RequiredResultData.Rows[0]["category"].ToString();
                            ddltimeid.SelectedValue = RequiredResultData.Rows[0]["time_id"].ToString();
                        }
                    }
                }
            }
            if (e.CommandName == "Delete")
            {
                if (Daywise_foodmenuItems != null)
                {
                    food_menu_id = (string)Lv_Daywise_foodmenu.DataKeys[Daywise_foodmenuItems.DisplayIndex][0].ToString().Trim();
                    hdnfoodmenu_id.Value = food_menu_id;
                    ViewState["food_menu_id"] = food_menu_id;

                    obj_Daywise_foodmenu_Entity.foodmenu_id = Convert.ToInt32(food_menu_id);
                    obj_Daywise_foodmenu_Entity.flag = "delete";

                    if (obj_Daywise_foodmenu_BAL.Add_Edit_Delete(obj_Daywise_foodmenu_Entity))
                    {
                        lblMessage.Text = "Deleted successfully.";

                        hdnfoodmenu_id.Value = "0";

                        BindDaywise_foodmenuList();
                    }
                    else
                    {
                        lblMessage.Text = "Error, not deleted successfully";
                    }
                }
            }
        }

        protected void Lv_Daywise_foodmenu_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_Daywise_foodmenu_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }

        protected void Lv_Daywise_foodmenu_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_Daywise_foodmenu.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindDaywise_foodmenuList();
        }

        protected void Lv_Daywise_foodmenu_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDaywise_foodmenuList();
        }
    }
}