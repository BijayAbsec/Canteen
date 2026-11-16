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
    public partial class Token_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Token_Entity obj_token_Entity = new Token_Entity();
        Token_BAL obj_token_BAL = new Token_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Bindtoken();
            }
        }
        private void Bindtoken()
        {
            obj_token_Entity.token_id = 0;
            obj_token_Entity.flag = "select_all";
            obj_token_Entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_token_BAL.Get_Details(obj_token_Entity);
            ViewState["dttoken"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_token.DataSource = RequiredResultData;
                    Lv_token.DataBind();
                }
                else
                {
                    Lv_token.DataSource = RequiredResultData;
                    Lv_token.DataBind();
                }
            }
            else
            {
                Lv_token.DataSource = RequiredResultData;
                Lv_token.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_token_Entity.token_id = Convert.ToInt32(hdntoken_Id.Value);
            obj_token_Entity.token_name = txttokenname.Text.Trim();
            obj_token_Entity.active_status = 1;
            obj_token_Entity.created_by = 1;
            obj_token_Entity.flag = "insert_update";
            if (obj_token_BAL.Add_Edit_Delete(obj_token_Entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdntoken_Id.Value = "0";
                txttokenname.Text = string.Empty;

                Bindtoken();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_token_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string token_id = "";
            ListViewDataItem tokenitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (tokenitem != null)
                {
                    token_id = (string)Lv_token.DataKeys[tokenitem.DisplayIndex][0].ToString().Trim();
                    hdntoken_Id.Value = token_id;
                    ViewState["token_id"] = token_id;

                    obj_token_Entity.token_id = Convert.ToInt32(token_id);
                    obj_token_Entity.flag = "select_by_id";

                    RequiredResultData = obj_token_BAL.Get_Details(obj_token_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txttokenname.Text = RequiredResultData.Rows[0]["token_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (tokenitem != null)
                {
                    token_id = (string)Lv_token.DataKeys[tokenitem.DisplayIndex][0].ToString().Trim();
                    hdntoken_Id.Value = token_id;
                    ViewState["token_id"] = token_id;

                    obj_token_Entity.token_id = Convert.ToInt32(token_id);
                    obj_token_Entity.flag = "delete";

                    if (obj_token_BAL.Add_Edit_Delete(obj_token_Entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdntoken_Id.Value = "0";

                        Bindtoken();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_token_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_token_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_token.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Bindtoken();
        }
        protected void Lv_token_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_token_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_token_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Bindtoken();
        }
    }
}