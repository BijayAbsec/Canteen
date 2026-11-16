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

    public partial class Item_setup1 : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Item_Entity obj_item_Entity = new Item_Entity();
        Item_BAL obj_item_BAL = new Item_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                Binditem();
            }

        }
        private void Binditem()
        {
            obj_item_Entity.item_id = 0;
            obj_item_Entity.flag = "select_all";
            obj_item_Entity.search_value = txtsearch.Text.Trim();

            RequiredResultData = obj_item_BAL.Get_Details(obj_item_Entity);
            ViewState["dtitem"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_item.DataSource = RequiredResultData;
                    Lv_item.DataBind();
                }
                else
                {
                    Lv_item.DataSource = RequiredResultData;
                    Lv_item.DataBind();
                }
            }
            else
            {
                Lv_item.DataSource = RequiredResultData;
                Lv_item.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_item_Entity.item_id = Convert.ToInt32(hdnitem_Id.Value);
            obj_item_Entity.item_name = txtitemname.Text.Trim();
            obj_item_Entity.active_status = 1;
            obj_item_Entity.created_by = 1;
            obj_item_Entity.flag = "insert_update";
            if (obj_item_BAL.Add_Edit_Delete(obj_item_Entity))
            {
                lblMsg.Text = "Saved successfully.";

                hdnitem_Id.Value = "0";
                txtitemname.Text = string.Empty;

                Binditem();

            }
            else
            {
                lblMsg.Text = "Error in Insert.";
            }

        }
        protected void Lv_item_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string item_id = "";
            ListViewDataItem itemitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "Edit")
            {
                if (itemitem != null)
                {
                    item_id = (string)Lv_item.DataKeys[itemitem.DisplayIndex][0].ToString().Trim();
                    hdnitem_Id.Value = item_id;
                    ViewState["item_id"] = item_id;

                    obj_item_Entity.item_id = Convert.ToInt32(item_id);
                    obj_item_Entity.flag = "select_by_id";

                    RequiredResultData = obj_item_BAL.Get_Details(obj_item_Entity);

                    if (RequiredResultData != null)
                    {
                        if (RequiredResultData.Rows.Count > 0)
                        {
                            txtitemname.Text = RequiredResultData.Rows[0]["item_name"].ToString();
                        }
                    }
                }
            }

            if (e.CommandName == "Delete")
            {
                if (itemitem != null)
                {
                    item_id = (string)Lv_item.DataKeys[itemitem.DisplayIndex][0].ToString().Trim();
                    hdnitem_Id.Value = item_id;
                    ViewState["item_id"] = item_id;

                    obj_item_Entity.item_id = Convert.ToInt32(item_id);
                    obj_item_Entity.flag = "delete";

                    if (obj_item_BAL.Add_Edit_Delete(obj_item_Entity))
                    {
                        lblMsg.Text = "Deleted successfully.";

                        hdnitem_Id.Value = "0";

                        Binditem();
                    }
                    else
                    {
                        lblMsg.Text = "Error, not deleted successfully";
                    }
                }
            }

        }
        protected void Lv_item_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_item_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_item.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            Binditem();
        }
        protected void Lv_item_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_item_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void Lv_item_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Binditem();
        }
    }
}