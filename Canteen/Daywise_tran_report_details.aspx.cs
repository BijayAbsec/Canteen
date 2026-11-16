using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

using Canteen_ENTITY;
using Canteen_BAL;
namespace Canteen
{
    public partial class Daywise_tran_report_details : System.Web.UI.Page
    {
        Food_transaction_master_Entity obj_Food_transaction_master_Entity = new Food_transaction_master_Entity();
        Food_transaction_master_BAL obj_Food_transaction_master_BAL = new Food_transaction_master_BAL();

        DataTable dt = new DataTable();
        DataTable dt1 = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                BindTransactonDetails();
            }
        }

        private void BindTransactonDetails()
        {
            obj_Food_transaction_master_Entity.foodtransaction_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            obj_Food_transaction_master_Entity.flag = "select_user_food_by_tran_id";

            dt = obj_Food_transaction_master_BAL.Get_Details(obj_Food_transaction_master_Entity);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {
                    Lv_tran.DataSource = dt;
                    Lv_tran.DataBind();
                }
                else
                {
                    Lv_tran.DataSource = dt;
                    Lv_tran.DataBind();
                }
            }
            else
            {
                Lv_tran.DataSource = dt;
                Lv_tran.DataBind();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void Lv_tran_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

        }

        protected void Lv_tran_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var lvFoodDetails = e.Item.FindControl("lvFoodDetails") as ListView;

                obj_Food_transaction_master_Entity.foodtransaction_id = Convert.ToInt32(Request.QueryString["id"].ToString());
                obj_Food_transaction_master_Entity.flag = "select_guest_food_details";

                dt1 = obj_Food_transaction_master_BAL.Get_Details(obj_Food_transaction_master_Entity);
                if (dt1 != null)
                {
                    if (dt1.Rows.Count > 0)
                    {
                        lvFoodDetails.DataSource = dt1;
                        lvFoodDetails.DataBind();
                    }
                    else
                    {
                        lvFoodDetails.DataSource = dt1;
                        lvFoodDetails.DataBind();
                    }
                }
                else
                {
                    lvFoodDetails.DataSource = dt1;
                    lvFoodDetails.DataBind();
                }
            }
        }
    }
}