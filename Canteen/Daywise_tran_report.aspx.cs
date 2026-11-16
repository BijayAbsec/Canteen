using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Canteen_ENTITY;
using Canteen_BAL;
using System.Configuration;
using System.IO;

namespace Canteen
{
    public partial class Daywise_tran_report : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();
        Food_transaction_master_Entity obj_Food_transaction_master_Entity = new Food_transaction_master_Entity();
        Food_transaction_master_BAL obj_Food_transaction_master_BAL = new Food_transaction_master_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            bindtransaction();
        }
        private void bindtransaction()
        {
            obj_Food_transaction_master_Entity.foodtransaction_id = 0;
            if (txtDateFrom.Text.Trim() != string.Empty)
            {
                obj_Food_transaction_master_Entity.dateFrom = Convert.ToString(Convert.ToDateTime(txtDateFrom.Text.Trim()).ToString("yyyy-MM-dd"));
            }
            else
            {
                obj_Food_transaction_master_Entity.dateFrom = null;
            }

            if (txtDateTo.Text.Trim() != string.Empty)
            {
                obj_Food_transaction_master_Entity.dateTo = Convert.ToString(Convert.ToDateTime(txtDateTo.Text.Trim()).ToString("yyyy-MM-dd"));
            }
            else
            {
                obj_Food_transaction_master_Entity.dateTo = null;
            }
            obj_Food_transaction_master_Entity.flag = "select_daywise_transaction";

            RequiredResultData = obj_Food_transaction_master_BAL.get_reqdata(obj_Food_transaction_master_Entity);
            ViewState["dtstaff"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_tran.DataSource = RequiredResultData;
                    Lv_tran.DataBind();
                }
                else
                {
                    Lv_tran.DataSource = RequiredResultData;
                    Lv_tran.DataBind();
                }
            }
            else
            {
                Lv_tran.DataSource = RequiredResultData;
                Lv_tran.DataBind();
            }
        }
        protected void Lv_tran_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_tran.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            bindtransaction();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindtransaction();
        }

        protected void Lv_tran_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string tran_id = "";
            ListViewDataItem deptitem = (ListViewDataItem)e.Item;
            if (e.CommandName == "View")
            {
                if (deptitem != null)
                {
                    tran_id = (string)Lv_tran.DataKeys[deptitem.DisplayIndex][0].ToString().Trim();

                    Response.Redirect("Daywise_tran_report_details.aspx?id=" + tran_id);
                }
            }
        }

        protected void Lv_tran_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lbl_guest_no = e.Item.FindControl("lbl_guest_no") as Label;
                var lnkView = e.Item.FindControl("lnkView") as LinkButton;
                if (lbl_guest_no.Text.Trim() == "0")
                {
                    lnkView.Visible = false;
                }
            }
        }
    }
}