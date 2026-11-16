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
    public partial class Staff_list : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        User_Entity obj_User_Entity = new User_Entity();
        Staff_list_BAL obj_Staff_list_BAL = new Staff_list_BAL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                bindstafflist();
            }
        }
        private void bindstafflist()
        {
            obj_User_Entity.user_id = 0;
            obj_User_Entity.flag = "View_all_active";
            obj_User_Entity.search_value = txtSearch.Text.Trim();

            RequiredResultData = obj_Staff_list_BAL.Get_Staff_List(obj_User_Entity);
            ViewState["dtstaff"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    Lv_Signup.DataSource = RequiredResultData;
                    Lv_Signup.DataBind();
                }
                else
                {
                    Lv_Signup.DataSource = RequiredResultData;
                    Lv_Signup.DataBind();
                }
            }
            else
            {
                Lv_Signup.DataSource = RequiredResultData;
                Lv_Signup.DataBind();
            }
        }
        protected void Lv_Signup_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void Lv_Signup_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            string user_id = "";
            ListViewDataItem stafflist = (ListViewDataItem)e.Item;
            
            if (e.CommandName == "View")
            {
                if (stafflist != null)
                {
                    user_id = (string)Lv_Signup.DataKeys[stafflist.DisplayIndex][0].ToString().Trim();                  
                   Response.Redirect("Staff_profile.aspx?id=" + user_id);
                }
            }

            if (e.CommandName == "Delete")
            {
                if (stafflist != null)
                {
                    user_id = (string)Lv_Signup.DataKeys[stafflist.DisplayIndex][0].ToString().Trim();

                    obj_User_Entity.user_id = Convert.ToInt32(user_id);
                    obj_User_Entity.flag = "delete";

                    if (obj_Staff_list_BAL.Delete(obj_User_Entity))
                    {
                        bindstafflist();
                    }
                }
            }
        }
        protected void Lv_Signup_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            (Lv_Signup.FindControl("DataPager1") as DataPager).SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            bindstafflist();

        }
        protected void Lv_Signup_ItemDeleting(object sender, ListViewDeleteEventArgs e)
        {

        }
        protected void Lv_Signup_ItemDataBound(object sender, ListViewItemEventArgs e)
        {

        }
        protected void Lv_Signup_ItemEditing(object sender, ListViewEditEventArgs e)
        {

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            bindstafflist();
        }
    }
}