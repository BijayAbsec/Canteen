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
    public partial class Daywise_intake_setup : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Daywise_intake_Entity obj_Daywise_intake_Entity = new Daywise_intake_Entity();
        Daywise_intake_BAL obj_Daywise_intake_BAL = new Daywise_intake_BAL();

        Unit_Entity obj_Unit_Entity = new Unit_Entity();
        Unit_BAL obj_Unit_BAL = new Unit_BAL();

        Item_Entity obj_Item_Entity = new Item_Entity();
        Item_BAL obj_Item_BAL = new Item_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"].ToString() != null)
                {
                    BindItem();
                    BindUnit();
                    BindDaywise_intakeList();
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }

        protected void BindItem()
        {
            obj_Item_Entity.item_id = 0;
            obj_Item_Entity.flag = "select_all_active";

            RequiredResultData = obj_Item_BAL.Get_Details(obj_Item_Entity);

            ddlitemid.Items.Clear();
            ddlitemid.DataSource = RequiredResultData;
            ddlitemid.DataValueField = "Item_id";
            ddlitemid.DataTextField = "Item_Name";
            ddlitemid.DataBind();
            ddlitemid.Items.Insert(0, "--Select--");
            ddlitemid.Items[0].Value = "0";
            ddlitemid.Items[0].Selected = true;
        }

        protected void BindUnit()
        {
            obj_Unit_Entity.unit_id = 0;
            obj_Unit_Entity.flag = "select_all_active";

            RequiredResultData = obj_Unit_BAL.Get_Details(obj_Unit_Entity);

            ddlunitid.Items.Clear();
            ddlunitid.DataSource = RequiredResultData;
            ddlunitid.DataValueField = "Unit_id";
            ddlunitid.DataTextField = "Unit_Name";
            ddlunitid.DataBind();
            ddlunitid.Items.Insert(0, "--Select--");
            ddlunitid.Items[0].Value = "0";
            ddlunitid.Items[0].Selected = true;
        }

        protected void BindDaywise_intakeList()
        {
            obj_Daywise_intake_Entity.intake_id = 0;
            obj_Daywise_intake_Entity.flag = "view_all_active";
            obj_Daywise_intake_Entity.search_value = txtSearch.Text.Trim();
            RequiredResultData = obj_Daywise_intake_BAL.Get_Details(obj_Daywise_intake_Entity);
            ViewState["dtcont"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_Daywise_intake.DataSource = RequiredResultData;
                    Lv_Daywise_intake.DataBind();
                }
                else
                {
                    Lv_Daywise_intake.DataSource = RequiredResultData;
                    Lv_Daywise_intake.DataBind();
                }
            }
            else
            {
                Lv_Daywise_intake.DataSource = RequiredResultData;
                Lv_Daywise_intake.DataBind();
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            obj_Daywise_intake_Entity.intake_id = Convert.ToInt32(hdnintakeid.Value);
            obj_Daywise_intake_Entity.item_id = Convert.ToInt32(ddlitemid.SelectedValue.ToString());
            obj_Daywise_intake_Entity.quantity = Convert.ToDecimal(txtquantity.Text.ToString());
            obj_Daywise_intake_Entity.unit_id = Convert.ToInt32(ddlunitid.SelectedValue.ToString());
            //obj_Daywise_intake_Entity.price = txtprice.Text.Trim();
            obj_Daywise_intake_Entity.price = "0";
            obj_Daywise_intake_Entity.active_status = 1;
            obj_Daywise_intake_Entity.created_by = 1;
            obj_Daywise_intake_Entity.flag = "insert_update";
            if (obj_Daywise_intake_BAL.Add(obj_Daywise_intake_Entity))
            {
                lblMessage.Text = "Saved successfully.";
                IntializeAllIds();



                BindDaywise_intakeList();
            }
            else
            {
                lblMessage.Text = "Error in Insert.";
            }
        }

        protected void IntializeAllIds()
        {
            ddlitemid.Text = "0";
            hdnintakeid.Value = "0";
            ddlunitid.Text = "0";
            txtquantity.Text = "";
            txtprice.Text = "";
        }

        protected void Lv_Daywise_intake_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string intake_id = "";
            ListViewDataItem IntakeItems = (ListViewDataItem)e.Item;

        }

        protected void Lv_Daywise_intake_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_Daywise_intake.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            BindDaywise_intakeList();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindDaywise_intakeList();
        }
    }
}