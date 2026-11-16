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
    public partial class Time_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Time_Entity obj_Time_Entity = new Time_Entity();
        Time_BAL obj_Time_BAL = new Time_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Bindtime();
            }

        }
        private void Bindtime()
        {
            obj_Time_Entity.time_id = 0;
            obj_Time_Entity.flag = "select_all";
            obj_Time_Entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_Time_BAL.Get_Details(obj_Time_Entity);
            ViewState["dttime"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_time.DataSource = RequiredResultData;
                    Lv_time.DataBind();
                }
                else
                {
                    Lv_time.DataSource = RequiredResultData;
                    Lv_time.DataBind();
                }
            }
            else
            {
                Lv_time.DataSource = RequiredResultData;
                Lv_time.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_Time_Entity.time_id = Convert.ToInt32(hdntime_Id.Value);
            obj_Time_Entity.time_name = txttimename.Text.Trim();
            obj_Time_Entity.active_status = 1;
            obj_Time_Entity.created_by = 1;
            obj_Time_Entity.flag = "insert_update";
            if (obj_Time_BAL.Add_Edit_Delete(obj_Time_Entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdntime_Id.Value = "0";
                txttimename.Text = string.Empty;

                Bindtime();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_time_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string time_id = "";
            ListViewDataItem timeitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (timeitem != null)
                {
                    time_id = (string)Lv_time.DataKeys[timeitem.DisplayIndex][0].ToString().Trim();
                    hdntime_Id.Value = time_id;
                    ViewState["time_id"] = time_id;

                    obj_Time_Entity.time_id = Convert.ToInt32(time_id);
                    obj_Time_Entity.flag = "select_by_id";

                    RequiredResultData = obj_Time_BAL.Get_Details(obj_Time_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txttimename.Text = RequiredResultData.Rows[0]["time_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (timeitem != null)
                {
                    time_id = (string)Lv_time.DataKeys[timeitem.DisplayIndex][0].ToString().Trim();
                    hdntime_Id.Value = time_id;
                    ViewState["time_id"] = time_id;

                    obj_Time_Entity.time_id = Convert.ToInt32(time_id);
                    obj_Time_Entity.flag = "delete";

                    if (obj_Time_BAL.Add_Edit_Delete(obj_Time_Entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdntime_Id.Value = "0";

                        Bindtime();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_time_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_time_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_time.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Bindtime();
        }
        protected void Lv_time_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_time_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_time_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindtime();
        }
    }
}