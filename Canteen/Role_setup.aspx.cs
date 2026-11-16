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
    public partial class Role_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        role_entity obj_role_entity = new role_entity();
        role_BAL obj_role_BAL = new role_BAL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Bindrole();
            }

        }
        private void Bindrole()
        {
            obj_role_entity.role_id = 0;
            obj_role_entity.flag = "select_all";
            obj_role_entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_role_BAL.Get_requireddata(obj_role_entity);
            ViewState["dtrole"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_role.DataSource = RequiredResultData;
                    Lv_role.DataBind();
                }
                else
                {
                    Lv_role.DataSource = RequiredResultData;
                    Lv_role.DataBind();
                }
            }
            else
            {
                Lv_role.DataSource = RequiredResultData;
                Lv_role.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_role_entity.role_id = Convert.ToInt32(hdnrole_Id.Value);
            obj_role_entity.role_name = txtrolename.Text.Trim();
            obj_role_entity.active_status = 1;
            obj_role_entity.created_by = 1;
            obj_role_entity.flag = "insert_update";
            if (obj_role_BAL.Add_Edit_Delete(obj_role_entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdnrole_Id.Value = "0";
                txtrolename.Text = string.Empty;

                Bindrole();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_role_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string role_id = "";
            ListViewDataItem roleitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (roleitem != null)
                {
                    role_id = (string)Lv_role.DataKeys[roleitem.DisplayIndex][0].ToString().Trim();
                    hdnrole_Id.Value = role_id;
                    ViewState["role_id"] = role_id;

                    obj_role_entity.role_id = Convert.ToInt32(role_id);
                    obj_role_entity.flag = "select_by_id";

                    RequiredResultData = obj_role_BAL.Get_requireddata(obj_role_entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txtrolename.Text = RequiredResultData.Rows[0]["role_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (roleitem != null)
                {
                    role_id = (string)Lv_role.DataKeys[roleitem.DisplayIndex][0].ToString().Trim();
                    hdnrole_Id.Value = role_id;
                    ViewState["role_id"] = role_id;

                    obj_role_entity.role_id = Convert.ToInt32(role_id);
                    obj_role_entity.flag = "delete";

                    if (obj_role_BAL.Add_Edit_Delete(obj_role_entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdnrole_Id.Value = "0";

                        Bindrole();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_role_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_role_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_role.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Bindrole();
        }
        protected void Lv_role_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_role_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_role_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindrole();
        }
    }
}