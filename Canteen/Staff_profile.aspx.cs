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
    public partial class Staff_profile : System.Web.UI.Page
    {
        Int32 FileSize = Convert.ToInt32(ConfigurationManager.AppSettings["FileSize"].ToString());
        static string filelUrl = string.Empty;

        DataTable RequiredResultData = new DataTable();

        User_Entity obj_User_Entity = new User_Entity();
        dept_entity obj_dept_Entity = new dept_entity();
        role_entity obj_role_Entity = new role_entity();
        dept_BAL obj_dept_BAL = new dept_BAL();
        role_BAL obj_role_BAL = new role_BAL();
        Signup_BAL obj_Signup_BAL = new Signup_BAL();
        Staff_list_BAL obj_Staff_list_BAL = new Staff_list_BAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["User_Name"].ToString() != null)
                {
                    binddept();
                    bindrole();
                    if (Convert.ToInt32(Session["user_role"].ToString()) == 3)
                    {
                        dvRole.Visible = false;
                    }
                    else
                    {
                        dvRole.Visible = true;
                    }
                    BindControls(Convert.ToInt32(Request.QueryString["id"].ToString()));
                }
                else
                {
                    Response.Redirect("Signin.aspx");
                }
            }
        }
        private void binddept()
        {
            obj_dept_Entity.dept_id = 0;
            obj_dept_Entity.flag = "select_all_active";
            RequiredResultData = obj_dept_BAL.Get_Details(obj_dept_Entity);
            ddldept.Items.Clear();
            ddldept.DataSource = RequiredResultData;
            ddldept.DataValueField = "dept_id";
            ddldept.DataTextField = "dept_Name";
            ddldept.DataBind();
            ddldept.Items.Insert(0, "--Select--");
            ddldept.Items[0].Value = "0";
            ddldept.Items[0].Selected = true;
        }
        private void bindrole()
        {
            obj_role_Entity.role_id = 0;
            obj_role_Entity.flag = "select_all_active";
            RequiredResultData = obj_role_BAL.Get_Details(obj_role_Entity);
            ddlrole.Items.Clear();
            ddlrole.DataSource = RequiredResultData;
            ddlrole.DataValueField = "role_id";
            ddlrole.DataTextField = "role_name";
            ddlrole.DataBind();
            ddlrole.Items.Insert(0, "--Select--");
            ddlrole.Items[0].Value = "0";
            ddlrole.Items[0].Selected = true;
        }
        //protected void BindControls(int user_id)
        //{
        //    obj_User_Entity.user_id = user_id;
        //    obj_User_Entity.flag = "select_by_id";

        //    RequiredResultData = obj_Staff_list_BAL.Get_Staff_List(obj_User_Entity);
        //    if (RequiredResultData != null)
        //    {
        //        if (RequiredResultData.Rows.Count > 0)
        //        {
        //            txtname.Text = RequiredResultData.Rows[0]["user_name"].ToString();
        //            txtemail.Text = RequiredResultData.Rows[0]["user_email"].ToString();

        //        }
        //        if (RequiredResultData.Rows.Count > 0)
        //        {
        //            lbldept.Text = RequiredResultData.Rows[0]["dept_id"].ToString();
        //            //ldlrole.Text = RequiredResultData.Rows[0]["role_id"].ToString();
        //        }
        //        if (RequiredResultData.Rows.Count > 0)
        //        {                   
        //            ldlrole.Text = RequiredResultData.Rows[0]["role_id"].ToString();
        //        }
        //        txtemployee.Text = RequiredResultData.Rows[0]["employee_idno"].ToString();
        //        //txtpassword.Text = RequiredResultData.Rows[0]["user_password"].ToString();
        //        txtcontact.Text = RequiredResultData.Rows[0]["contact_no"].ToString();
        //        if (RequiredResultData.Rows[0]["user_image"].ToString() != string.Empty)
        //        {
        //            imgProfile.ImageUrl = "../img/" + RequiredResultData.Rows[0]["user_image"].ToString();
        //            lblProfileImagePath.Text = "../img/" + RequiredResultData.Rows[0]["user_image"].ToString();
        //        }


        //    }
        //}

        protected void BindControls(int user_id)
        {
            //binddept(); bindrole();
            obj_User_Entity.user_id = user_id;
            obj_User_Entity.flag = "select_by_id";

            RequiredResultData = obj_Staff_list_BAL.Get_Staff_List(obj_User_Entity);
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    txtname.Text = RequiredResultData.Rows[0]["user_name"].ToString();
                    txtemail.Text = RequiredResultData.Rows[0]["user_email"].ToString();

                    //if (RequiredResultData.Rows.Count > 0)
                    //{
                    //lbldept.Text = RequiredResultData.Rows[0]["dept_id"].ToString();

                    ddldept.SelectedValue = RequiredResultData.Rows[0]["dept_id"].ToString();
                    //ldlrole.Text = RequiredResultData.Rows[0]["role_id"].ToString();

                    ddlrole.SelectedValue = RequiredResultData.Rows[0]["role_id"].ToString();
                    //}

                    txtemployee.Text = RequiredResultData.Rows[0]["employee_idno"].ToString();
                    //txtpassword.Text = RequiredResultData.Rows[0]["user_password"].ToString();
                    txtcontact.Text = RequiredResultData.Rows[0]["contact_no"].ToString();
                    if (RequiredResultData.Rows[0]["user_image"].ToString() != string.Empty)
                    {
                        imgProfile.ImageUrl = "../img/" + RequiredResultData.Rows[0]["user_image"].ToString();
                        lblProfileImagePath.Text = "../img/" + RequiredResultData.Rows[0]["user_image"].ToString();
                    }
                }
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            //if (fuimage.HasFile)
            //{
            //    string strProfileImagePath = ""; string strFileName = ""; string extension = ""; string PublicfileName = "";
            //    string PublicfilePath = "";

            //    if (fuimage.PostedFile.ContentLength > FileSize)
            //    {
            //        ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('File Size cannot be more than 4 mb');", true);
            //        return;
            //    }
            //    strProfileImagePath = Server.MapPath(@"~/img/");

            //    if (fuimage.HasFile)
            //    {
            //        if (!string.IsNullOrEmpty(fuimage.PostedFile.FileName))
            //        {
            //            strFileName = Convert.ToString(DateTime.Now.Year).Substring(2, 2) + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
            //            extension = Path.GetExtension(fuimage.PostedFile.FileName);
            //            PublicfileName = strFileName + extension;
            //            PublicfilePath = Path.Combine(strProfileImagePath, PublicfileName);
            //            fuimage.PostedFile.SaveAs(PublicfilePath);
            //            if (lblProfileImagePath.Text.Trim() != string.Empty)
            //            {
            //                obj_User_Entity.user_image = lblProfileImagePath.Text.Trim();
            //            }
            //            else
            //            {
            //                obj_User_Entity.user_image = PublicfilePath;
            //            }
            //        }
            //    }
            //}

            if (fuimage.HasFile)
            {
                string strProfileImagePath = ""; string strFileName = ""; string extension = ""; string PublicfileName = "";
                string PublicfilePath = "";

                if (fuimage.PostedFile.ContentLength > FileSize)
                {
                    ScriptManager.RegisterClientScriptBlock(this, this.GetType(), "alert", "alert('File Size cannot be more than 4 mb');", true);
                    return;
                }
                strProfileImagePath = Server.MapPath(@"~/img/");

                if (fuimage.HasFile)
                {
                    if (!string.IsNullOrEmpty(fuimage.PostedFile.FileName))
                    {
                        strFileName = Convert.ToString(DateTime.Now.Year).Substring(2, 2) + DateTime.Now.Day.ToString("00") + DateTime.Now.Month.ToString("00") + DateTime.Now.Hour.ToString("00") + DateTime.Now.Minute.ToString("00") + DateTime.Now.Second.ToString("00");
                        extension = Path.GetExtension(fuimage.PostedFile.FileName);
                        PublicfileName = strFileName + extension;
                        PublicfilePath = Path.Combine(strProfileImagePath, PublicfileName);
                        fuimage.PostedFile.SaveAs(PublicfilePath);
                        //if (lblProfileImagePath.Text.Trim() != string.Empty)
                        //{
                        //    obj_User_Entity.user_image = lblProfileImagePath.Text.Trim();
                        //}
                        //else
                        //{
                        obj_User_Entity.user_image = PublicfilePath;
                        //}
                    }
                }
            }
            else
            {
                obj_User_Entity.user_image = lblProfileImagePath.Text;
            }

            obj_User_Entity.user_id = Convert.ToInt32(Request.QueryString["id"].ToString());
            obj_User_Entity.user_name = txtname.Text.Trim();
            obj_User_Entity.user_email = txtemail.Text.Trim();
            obj_User_Entity.employee_idno = txtemployee.Text.Trim();
            obj_User_Entity.contact_no = txtcontact.Text.Trim();
            obj_User_Entity.dept_id = Convert.ToInt32(ddldept.SelectedValue.ToString());
            obj_User_Entity.role_id = Convert.ToInt32(ddlrole.SelectedValue.ToString());
            obj_User_Entity.active_status = 1;

            obj_User_Entity.created_by = "1";
            obj_User_Entity.flag = "insert_update";

            if (obj_Staff_list_BAL.Add_Edit_Delete(obj_User_Entity))
            {


                Response.Redirect("Staff_list.aspx");
                lblmessage.Text = "Saved Successfully.";

            }
            else
            {
                lblmessage.Text = "Error in Insert.";
            }



        }
    }
}