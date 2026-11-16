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
    public partial class Index : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Staff_list_BAL obj_Staff_list_BAL = new Staff_list_BAL();
        User_Entity obj_User_Entity = new User_Entity();
        Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity = new Daywise_foodmenu_Entity();
        Daywise_foodmenu_BAL obj_Daywise_foodmenu_BAL = new Daywise_foodmenu_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                bindnonveg();
                bindcommon();
                bindveg();
                bindtotaluser();
            }
        }
        private void bindnonveg()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.flag = "get_non-veg_menu";

            RequiredResultData = obj_Daywise_foodmenu_BAL.get_reqdata(obj_Daywise_foodmenu_Entity);
            ViewState["dtcat"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_nonveg.DataSource = RequiredResultData;
                    Lv_nonveg.DataBind();
                }
                else
                {
                    Lv_nonveg.DataSource = RequiredResultData;
                    Lv_nonveg.DataBind();
                }
            }
            else
            {
                Lv_nonveg.DataSource = RequiredResultData;
                Lv_nonveg.DataBind();
            }
        }
        private void bindcommon()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.flag = "get_common_menu";

            RequiredResultData = obj_Daywise_foodmenu_BAL.get_reqdata(obj_Daywise_foodmenu_Entity);
            ViewState["dtcat"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_common.DataSource = RequiredResultData;
                    Lv_common.DataBind();
                }
                else
                {
                    Lv_common.DataSource = RequiredResultData;
                    Lv_common.DataBind();
                }
            }
            else
            {
                Lv_common.DataSource = RequiredResultData;
                Lv_common.DataBind();
            }
        }
        private void bindveg()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.flag = "get_veg_menu";

            RequiredResultData = obj_Daywise_foodmenu_BAL.get_reqdata(obj_Daywise_foodmenu_Entity);
            ViewState["dtcat"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_veg.DataSource = RequiredResultData;
                    Lv_veg.DataBind();
                }
                else
                {
                    Lv_veg.DataSource = RequiredResultData;
                    Lv_veg.DataBind();
                }
            }
            else
            {
                Lv_veg.DataSource = RequiredResultData;
                Lv_veg.DataBind();
            }
        }
        private void bindtotaluser()
        {
            obj_User_Entity.user_id = 0;
            obj_User_Entity.flag = "get_index_card_details";
            RequiredResultData = obj_Staff_list_BAL.get_reqdata(obj_User_Entity);            
            lblTotalUSer.Text = RequiredResultData.Rows[0]["total_user"].ToString();
        }

        protected void Lv_common_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            

        }
        protected void Lv_nonveg_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {


        }
        protected void Lv_veg_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {


        }
    }
}