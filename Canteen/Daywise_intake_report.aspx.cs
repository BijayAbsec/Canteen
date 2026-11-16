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
    public partial class Daywise_intake_report : System.Web.UI.Page
    {

        DataTable RequiredResultData = new DataTable();

        Daywise_intake_Entity obj_Daywise_intake_Entity = new Daywise_intake_Entity();
        Daywise_intake_BAL obj_Daywise_intake_BAL = new Daywise_intake_BAL();
        Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity = new Daywise_foodmenu_Entity();
        Daywise_foodmenu_BAL obj_Daywise_foodmenu_BAL = new Daywise_foodmenu_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               bindintakelist();
            }
        }
        private void bindintakelist()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.flag = "select_daywise_intake_transaction";

            if (txtDateFrom.Text.Trim() != string.Empty)
            {
                obj_Daywise_foodmenu_Entity.dateFrom = Convert.ToString(Convert.ToDateTime(txtDateFrom.Text.Trim()).ToString("yyyy-MM-dd"));
            }
            else
            {
                obj_Daywise_foodmenu_Entity.dateFrom = null;
            }

            if (txtDateTo.Text.Trim() != string.Empty)
            {
                obj_Daywise_foodmenu_Entity.dateTo = Convert.ToString(Convert.ToDateTime(txtDateTo.Text.Trim()).ToString("yyyy-MM-dd"));
            }
            else
            {
                obj_Daywise_foodmenu_Entity.dateTo = null;
            }

            RequiredResultData = obj_Daywise_foodmenu_BAL.get_reqdata(obj_Daywise_foodmenu_Entity);
            ViewState["dtstaff"] = RequiredResultData;
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
        protected void Lv_Daywise_intake_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_Daywise_intake.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            bindintakelist();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindintakelist();
        }
    }
}