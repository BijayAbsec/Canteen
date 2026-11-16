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
    public partial class Food_transaction : System.Web.UI.Page
    {
        DataTable RequiredResultData = new DataTable();

        Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity = new Daywise_foodmenu_Entity();
        Daywise_foodmenu_BAL obj_Daywise_foodmenu_BAL = new Daywise_foodmenu_BAL();

        Food_transaction_master_Entity obj_Food_transaction_master_Entity = new Food_transaction_master_Entity();
        Food_transaction_master_BAL obj_Food_transaction_master_BAL = new Food_transaction_master_BAL();

        Time_Entity obj_Time_Entity = new Time_Entity();
        Time_BAL obj_Time_BAL = new Time_BAL();

        User_Entity obj_User_Entity = new User_Entity();
        Staff_list_BAL obj_Staff_list_BAL = new Staff_list_BAL();

        Food_Entity obj_Food_Entity = new Food_Entity();
        Food_BAL obj_Food_BAL = new Food_BAL();

        DataTable dt = new DataTable();

        public object PlaceHolder1 { get; private set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"] == null)
                {
                    Response.Redirect("Signin.aspx");
                }
                //BindToken();
                //BindDaywise_foodmenuList();
                BindTime();
                //BindTime1();
                BindFoodCategory();
                //BindFoodCategory1();
                txtno_guest.Visible = false;
                //lbl_guest.Visible = false;
                Lblnm.Visible = false;
                lbldepartment.Visible = false;
                //lbltime.Visible = false;
                //lblcategory.Visible = false;
                //ddltime1.Visible = false;
                //ddlcategory1.Visible = false;

                ddlcategory_SelectedIndexChanged(null, null);
            }
        }

        protected void BindToken()
        {

        }

        protected void BindDaywise_foodmenuList()
        {
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
            obj_Daywise_foodmenu_Entity.category = ddlcategory.SelectedValue.ToString();
            obj_Daywise_foodmenu_Entity.flag = "select_all_food_with_common_active";

            RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);

            ListBox_food.Items.Clear();
            ListBox_food.DataSource = RequiredResultData;
            ListBox_food.DataValueField = "Food_id";
            ListBox_food.DataTextField = "Food_Name";
            ListBox_food.DataBind();
            //ListBox_food.Items.Insert(0, "All");
            //ListBox_food.Items[0].Value = "0";
            //ListBox_food.Items[0].Selected = true;
        }

        protected void BindDaywise_foodmenuList1()
        {
            //obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            //obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltime1.SelectedValue.ToString());
            //obj_Daywise_foodmenu_Entity.category = ddlcategory1.SelectedValue.ToString();
            //obj_Daywise_foodmenu_Entity.flag = "select_all_food_with_common_active";

            //RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);

            //ListBox_food.Items.Clear();
            //food_checklist.Items.Clear();
            //food_checklist.DataSource = RequiredResultData;
            //food_checklist.DataValueField = "Food_id";
            //food_checklist.DataTextField = "Food_Name";
            //food_checklist.DataBind();
        }

        protected void BindTime()
        {
            obj_Time_Entity.time_id = 0;
            obj_Time_Entity.flag = "view_all_active";

            RequiredResultData = obj_Time_BAL.Get_Details(obj_Time_Entity);

            ddltimeid.Items.Clear();
            ddltimeid.DataSource = RequiredResultData;
            ddltimeid.DataValueField = "Time_id";
            ddltimeid.DataTextField = "Time_Name";
            ddltimeid.DataBind();
            //ddltimeid.Items.Insert(0, "--Select--");
            //ddltimeid.Items[0].Value = "0";
            ddltimeid.Items[1].Selected = true;
        }

        protected void BindFoodCategory()
        {
            obj_Food_Entity.flag = "select_category";

            RequiredResultData = obj_Food_BAL.Get_Food_Category(obj_Food_Entity);

            ddlcategory.Items.Clear();
            ddlcategory.DataSource = RequiredResultData;
            ddlcategory.DataValueField = "category";
            ddlcategory.DataTextField = "category";
            ddlcategory.DataBind();
            ddlcategory.Items[2].Selected = true;
        }

        protected void txtstaff_id_TextChanged(object sender, EventArgs e)
        {
            obj_User_Entity.user_id = 0;
            obj_User_Entity.employee_idno = txtstaff_id.Text.Trim();
            obj_User_Entity.flag = "get_details_by_id";
            Lblnm.Visible = true;
            lbldepartment.Visible = true;
            lblname.Visible = true;
            lbldept.Visible = true;
            RequiredResultData = obj_Staff_list_BAL.Get_Details(obj_User_Entity);
            ViewState["dtcont"] = RequiredResultData;
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    lblname.Text = RequiredResultData.Rows[0]["User_Name"].ToString().Trim();
                    lbldept.Text = RequiredResultData.Rows[0]["dept_name"].ToString().Trim();

                    hdnUserId.Value = RequiredResultData.Rows[0]["user_id"].ToString().Trim();
                    ViewState["user_id"] = RequiredResultData.Rows[0]["user_id"].ToString().Trim();

                    hdnUserRole.Value = RequiredResultData.Rows[0]["role_id"].ToString().Trim();
                    ViewState["role_id"] = RequiredResultData.Rows[0]["role_id"].ToString().Trim();

                    if (txtno_guest.Text.Trim() != string.Empty)
                    {
                        txtno_guest_TextChanged(null, null);
                    }
                    btngenerate_token_Click(null, null);
                }
            }
        }

        protected void ddltimeid_SelectedIndexChanged(object sender, EventArgs e)
        {
            //obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
            //RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);
            //if(RequiredResultData !=null)
            //{
            //    if(RequiredResultData.Rows.Count > 0)
            //    {
            //        ListBox_food.Items.Clear();
            //        ListBox_food.DataSource = RequiredResultData;
            //        ListBox_food.DataValueField = "Food_id";
            //        ListBox_food.DataTextField = "Food_Name";
            //        ListBox_food.DataBind();
            //    }
            //}
            BindDaywise_foodmenuList();
        }

        protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDaywise_foodmenuList();
        }

        protected void btngenerate_token_Click(object sender, EventArgs e)
        {
            int ctr = 0;
            DataTable dt_token = new DataTable();
            obj_Food_transaction_master_Entity.foodtransaction_id = 0;
            obj_Food_transaction_master_Entity.flag = "generate_token_no";
            dt_token = obj_Food_transaction_master_BAL.Get_Details(obj_Food_transaction_master_Entity);
            if (dt_token != null)
            {
                txt_token.Text = (DateTime.Now.Year).ToString("0000") + (DateTime.Now.Month).ToString("00") + (DateTime.Now.Day).ToString() + "-" + Convert.ToString(Convert.ToInt32(dt_token.Rows[0]["token_no"].ToString()) + 1);
                ctr = Convert.ToInt32(dt_token.Rows[0]["token_no"].ToString()) + 1;

                foreach (ListViewDataItem item in LV_Menu.Items)
                {
                    ctr = ctr + 1;
                    TextBox txtGuestTokenNo = (TextBox)item.FindControl("txtGuestTokenNo");
                    txtGuestTokenNo.Text = (DateTime.Now.Year).ToString("0000") + (DateTime.Now.Month).ToString("00") + (DateTime.Now.Day).ToString() + "-" + Convert.ToString(ctr);
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            obj_Food_transaction_master_Entity.user_id = Convert.ToInt32(hdnUserId.Value);
            obj_Food_transaction_master_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
            obj_Food_transaction_master_Entity.category = ddlcategory.SelectedValue.ToString();
            obj_Food_transaction_master_Entity.token_no = txt_token.Text.Trim();
            obj_Food_transaction_master_Entity.food_id = 0;
            if (txtno_guest.Text.Trim() == "")
            {
                obj_Food_transaction_master_Entity.guest_no = 0;
            }
            else
            {
                obj_Food_transaction_master_Entity.guest_no = Convert.ToInt32(txtno_guest.Text.Trim());
            }

            obj_Food_transaction_master_Entity.active_status = 1;
            obj_Food_transaction_master_Entity.created_by = 1;
            obj_Food_transaction_master_Entity.flag = "insert_update";
            RequiredResultData = obj_Food_transaction_master_BAL.Add_Edit(obj_Food_transaction_master_Entity);
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    lblMessage.Text = "Saved successfully.";

                    #region for inset details table if guest is there
                    int guest_ctr = 0;
                    if (txtno_guest.Text.Trim() != "")
                    {
                        foreach (ListViewDataItem item in LV_Menu.Items)
                        {
                            TextBox txtGuestTokenNo = (TextBox)item.FindControl("txtGuestTokenNo");                            
                            CheckBoxList food_checklist = (CheckBoxList)item.FindControl("food_checklist");
                            guest_ctr = guest_ctr + 1;

                            for (int i = 0; i < food_checklist.Items.Count; i++)
                            {
                                if (food_checklist.Items[i].Selected == true)// getting selected value from CheckBox List  
                                {
                                    // add selected Item value to the String .
                                    obj_Food_transaction_master_Entity.foodtransaction_id = Convert.ToInt32(RequiredResultData.Rows[0]["foodtransaction_id"].ToString());
                                    obj_Food_transaction_master_Entity.user_id = Convert.ToInt32(hdnUserId.Value);
                                    obj_Food_transaction_master_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
                                    obj_Food_transaction_master_Entity.category = ddlcategory.SelectedValue.ToString();
                                    obj_Food_transaction_master_Entity.token_no = txtGuestTokenNo.Text.Trim();
                                    obj_Food_transaction_master_Entity.food_id = Convert.ToInt32(food_checklist.Items[i].Value);
                                    obj_Food_transaction_master_Entity.guest_no = guest_ctr;
                                    obj_Food_transaction_master_Entity.active_status = 1;
                                    obj_Food_transaction_master_Entity.created_by = 1;
                                    obj_Food_transaction_master_Entity.flag = "Insert_Details";

                                    DataTable dt = new DataTable();
                                    dt = obj_Food_transaction_master_BAL.Add_Edit(obj_Food_transaction_master_Entity);
                                }
                            }
                        }
                    }
                    #endregion

                    //Response.Redirect("Food_transaction.aspx");
                    ClearControls();
                }
                else
                {
                    lblMessage.Text = "Error in Insert.";
                }
            }
            else
            {
                lblMessage.Text = "Error in Insert.";
            }
        }

        private void ClearControls()
        {
            txtstaff_id.Text = string.Empty; txtstaff_id_TextChanged(null, null);
            txt_token.Text = string.Empty;
            txtno_guest.Text = string.Empty; txtno_guest.Visible = false;
            check_guest.Checked = false;
            LV_Menu.Visible = false;
            Lblnm.Visible = false; lblname.Visible = false;
            lbldepartment.Visible = false; lbldept.Visible = false;
        }

        protected void txtno_guest_TextChanged(object sender, EventArgs e)
        {
            dt.Rows.Clear();
            {
                if (txtstaff_id.Text.Trim() == string.Empty) { return; }
                if (txtno_guest.Text.Trim() == string.Empty) { txtno_guest.Text = "0"; }
                Generate(Convert.ToInt32(txtno_guest.Text));
            }
        }

        private void Generate(int staff_no)
        {
            LV_Menu.Visible = true;
            LV_Menu.Items.Clear();
            dt.Columns.AddRange(new System.Data.DataColumn[] { new System.Data.DataColumn("ID", typeof(int)) });

            for (int i = 0; i < staff_no; i++)
            {
                dt.Rows.Add(i);
            }
            this.LV_Menu.DataSource = dt;
            this.LV_Menu.DataBind();

            btngenerate_token_Click(null, null);
        }

        protected void ddlcategory1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDaywise_foodmenuList();
        }

        protected void ddltime1_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindDaywise_foodmenuList();
        }

        protected void ddlcategory_SelectedIndexChanged1(object sender, EventArgs e)
        {
            BindFoodCategory();
        }

        protected void LV_Menu_ItemCommand(object sender, ListViewCommandEventArgs e)
        {

        }

        protected void LV_Menu_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                var food_checklist = e.Item.FindControl("food_checklist") as CheckBoxList;

                RequiredResultData.Clear();
                obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
                obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
                obj_Daywise_foodmenu_Entity.category = ddlcategory.SelectedValue.ToString();
                obj_Daywise_foodmenu_Entity.category = "veg";
                obj_Daywise_foodmenu_Entity.flag = "view_food_all";

                RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);

                food_checklist.Items.Clear();
                food_checklist.DataSource = RequiredResultData;
                food_checklist.DataValueField = "Food_id";
                food_checklist.DataTextField = "Food_Name";
                food_checklist.DataBind();
            }
        }

        protected void ddl_item_template_category_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Reference the DropDownList.
            DropDownList ddl_item_template_category = sender as DropDownList;
            //var ddl_item_template_category = e.Item.FindControl("ddl_item_template_category") as DropDownList;

            //Get the ID of the DropDownList.
            string id = ddl_item_template_category.SelectedValue;

            // Find your control
            ListViewItem item = (ListViewItem)ddl_item_template_category.NamingContainer;
            CheckBoxList food_checklist = (CheckBoxList)item.FindControl("food_checklist");

            RequiredResultData.Clear();
            obj_Daywise_foodmenu_Entity.foodmenu_id = 0;
            obj_Daywise_foodmenu_Entity.time_id = Convert.ToInt32(ddltimeid.SelectedValue.ToString());
            obj_Daywise_foodmenu_Entity.category = ddlcategory.SelectedValue.ToString();
            obj_Daywise_foodmenu_Entity.category = "veg";
            obj_Daywise_foodmenu_Entity.flag = "view_food_all";

            RequiredResultData = obj_Daywise_foodmenu_BAL.Get_Details(obj_Daywise_foodmenu_Entity);

            food_checklist.Items.Clear();
            food_checklist.DataSource = RequiredResultData;
            food_checklist.DataValueField = "Food_id";
            food_checklist.DataTextField = "Food_Name";
            food_checklist.DataBind();
        }

        protected void check_guest_CheckedChanged(object sender, EventArgs e)
        {
            if (check_guest.Checked == true)
            {
                //lbl_guest.Visible = true;
                txtno_guest.Visible = true;
            }
            else
            {
                //lbl_guest.Visible = false;
                txtno_guest.Text = "";
                txtno_guest_TextChanged(null, null);
                txtno_guest.Visible = false;
            }

        }
        
    }
}