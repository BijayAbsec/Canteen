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
    public partial class Forgot_password : System.Web.UI.Page
    {
        Forgotpassword_BAL obj_Forgotpassword_BAL = new Forgotpassword_BAL();
        Password_Entity obj_Password_Entity = new Password_Entity();
        DataTable RequiredResultData = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               // Session["user_id"] = "";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            obj_Password_Entity.user_email = txtEmail.Text.ToString();
            obj_Password_Entity.New_password = txtnewPassword.Text.ToString();

            RequiredResultData = obj_Forgotpassword_BAL.Get_Details(obj_Password_Entity);
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    if (RequiredResultData.Rows[0]["status"].ToString() == "1")
                    {
                        lblmessage.Text = "Password changed successfully";
                        Response.Redirect("Signin.aspx");
                       // Session["user_id"] = "";
                    }
                    else
                    {
                        lblmessage.Text = "Sorry, Email does not exists.";
                        //Session["user_id"] = "";
                    }
                }
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            Response.Redirect("Signin.aspx");
        }
    }
}