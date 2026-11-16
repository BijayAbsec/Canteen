using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Canteen_ENTITY;
using Canteen_BAL;
using System.Data;
using System.Configuration;
using System.IO;

namespace Canteen
{
    public partial class Signin : System.Web.UI.Page
    {
        User_Entity obj_User_Entity = new User_Entity();
        Signin_BAL obj_Signin_BAL = new Signin_BAL();
        DataTable RequiredResultData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["user_id"] = "";
                Session["User_email"] = "";
                Session["user_role"] = "";
                Session["User_image"] = "";
                Session["User_Name"] = "";

            }

        }

        protected void btnSignIn_Click(object sender, EventArgs e)
        {
            obj_User_Entity.user_email = txtEmail.Text.Trim();
            obj_User_Entity.user_password = txtPassword.Text.Trim();

            RequiredResultData = obj_Signin_BAL.Get_Details(obj_User_Entity);

            if (RequiredResultData != null)
            {               
                if(RequiredResultData.Rows[0][0].ToString()== "login failed")
                {
                    lblMsg.Text = "Login Failed";
                    txtPassword.Text = String.Empty;

                    Session["user_id"] = "";
                    Session["User_email"] = "";
                    Session["user_role"] = "";
                    Session["User_Name"] = "";
                    Session["user_image"] = "";
                    lblMsg.Text = "Login Failed";
                }
                else
                {
                    lblMsg.Text = "Login successful";
                    Session["user_id"] = RequiredResultData.Rows[0]["user_id"];
                    Session["User_email"] = RequiredResultData.Rows[0]["user_email"];
                    Session["user_role"] = RequiredResultData.Rows[0]["role_id"];
                    Session["User_Name"] = RequiredResultData.Rows[0]["user_name"];
                    Session["user_image"] = RequiredResultData.Rows[0]["user_image"];
                    Response.Redirect("Index.aspx");
                    
                }

            }
            else
            {
                Session["user_id"] = "";
                Session["User_email"] = "";
                Session["user_role"] = "";
                //Session["user_image"] = "";
                Session["User_Name"] = "";
                lblMsg.Text = "Login Failed";
                txtPassword.Text = String.Empty;
            }


        }
    }
}