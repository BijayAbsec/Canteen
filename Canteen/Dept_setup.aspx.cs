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
    public partial class Item_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        dept_entity obj_dept_entity = new dept_entity();
        dept_BAL obj_dept_BAL = new dept_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                Binddept();
            }

        }
        private void Binddept()
        {
            obj_dept_entity.dept_id = 0;
            obj_dept_entity.flag = "select_all";
            obj_dept_entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_dept_BAL.Get_requireddata(obj_dept_entity);
            ViewState["dtdept"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_dept.DataSource = RequiredResultData;
                    Lv_dept.DataBind();
                }
                else
                {
                    Lv_dept.DataSource = RequiredResultData;
                    Lv_dept.DataBind();
                }
            }
            else
            {
                Lv_dept.DataSource = RequiredResultData;
                Lv_dept.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_dept_entity.dept_id = Convert.ToInt32(hdndept_Id.Value);
            obj_dept_entity.dept_name = txtdeptname.Text.Trim();
            obj_dept_entity.active_status = 1;
            obj_dept_entity.created_by = 1;
            obj_dept_entity.flag = "insert_update";
            if (obj_dept_BAL.Add_Edit_Delete(obj_dept_entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdndept_Id.Value = "0";
                txtdeptname.Text = string.Empty;

                Binddept();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_dept_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string dept_id = "";
            ListViewDataItem deptitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (deptitem!= null)
                {
                    dept_id = (string)Lv_dept.DataKeys[deptitem.DisplayIndex][0].ToString().Trim();
                    hdndept_Id.Value = dept_id;
                    ViewState["dept_id"] = dept_id;

                    obj_dept_entity.dept_id = Convert.ToInt32(dept_id);
                    obj_dept_entity.flag = "select_by_id";

                    RequiredResultData = obj_dept_BAL.Get_requireddata(obj_dept_entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txtdeptname.Text = RequiredResultData.Rows[0]["dept_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (deptitem != null)
                {
                    dept_id = (string)Lv_dept.DataKeys[deptitem.DisplayIndex][0].ToString().Trim();
                    hdndept_Id.Value = dept_id;
                    ViewState["dept_id"] = dept_id;

                    obj_dept_entity.dept_id = Convert.ToInt32(dept_id);
                    obj_dept_entity.flag = "delete";

                    if (obj_dept_BAL.Add_Edit_Delete(obj_dept_entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdndept_Id.Value = "0";

                        Binddept();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_dept_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_dept_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_dept.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Binddept();
        }
        protected void Lv_dept_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_dept_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_dept_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binddept();
        }
    }
}