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
    public partial class Unit_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Unit_Entity obj_unit_Entity = new Unit_Entity();
        Unit_BAL obj_unit_BAL = new Unit_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Bindunit();
            }

        }
        private void Bindunit()
        {
            obj_unit_Entity.unit_id = 0;
            obj_unit_Entity.flag = "select_all";
            obj_unit_Entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_unit_BAL.Get_Details(obj_unit_Entity);
            ViewState["dtunit"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_unit.DataSource = RequiredResultData;
                    Lv_unit.DataBind();
                }
                else
                {
                    Lv_unit.DataSource = RequiredResultData;
                    Lv_unit.DataBind();
                }
            }
            else
            {
                Lv_unit.DataSource = RequiredResultData;
                Lv_unit.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_unit_Entity.unit_id = Convert.ToInt32(hdnunit_Id.Value);
            obj_unit_Entity.unit_name = txtunitname.Text.Trim();
            obj_unit_Entity.active_status = 1;
            obj_unit_Entity.created_by = 1;
            obj_unit_Entity.flag = "insert_update";
            if (obj_unit_BAL.Add_Edit_Delete(obj_unit_Entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdnunit_Id.Value = "0";
                txtunitname.Text = string.Empty;

                Bindunit();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_unit_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string unit_id = "";
            ListViewDataItem unititem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (unititem != null)
                {
                    unit_id = (string)Lv_unit.DataKeys[unititem.DisplayIndex][0].ToString().Trim();
                    hdnunit_Id.Value = unit_id;
                    ViewState["unit_id"] = unit_id;

                    obj_unit_Entity.unit_id = Convert.ToInt32(unit_id);
                    obj_unit_Entity.flag = "select_by_id";

                    RequiredResultData = obj_unit_BAL.Get_Details(obj_unit_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txtunitname.Text = RequiredResultData.Rows[0]["unit_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (unititem != null)
                {
                    unit_id = (string)Lv_unit.DataKeys[unititem.DisplayIndex][0].ToString().Trim();
                    hdnunit_Id.Value = unit_id;
                    ViewState["unit_id"] = unit_id;

                    obj_unit_Entity.unit_id = Convert.ToInt32(unit_id);
                    obj_unit_Entity.flag = "delete";

                    if (obj_unit_BAL.Add_Edit_Delete(obj_unit_Entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdnunit_Id.Value = "0";

                        Bindunit();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_unit_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_unit_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_unit.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Bindunit();
        }
        protected void Lv_unit_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_unit_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_unit_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindunit();
        }
    }
}