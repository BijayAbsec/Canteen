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
    public partial class Changepassword : System.Web.UI.Page
    {
        Changepassword_BAL obj_Changepassword_BAL = new Changepassword_BAL();
        Password_Entity obj_Password_Entity = new Password_Entity();
        DataTable RequiredResultData = new DataTable();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            obj_Password_Entity.Old_password = oldpassword.Text.ToString();
            obj_Password_Entity.New_password = newpassword.Text.ToString();
            obj_Password_Entity.user_id = Convert.ToInt32(Session["user_id"].ToString());

            RequiredResultData = obj_Changepassword_BAL.Get_Details(obj_Password_Entity);
            if (RequiredResultData != null)
            {
                if (RequiredResultData.Rows.Count > 0)
                {
                    if (RequiredResultData.Rows[0]["status"].ToString() == "1")
                    {
                        lblmessage.Text = "Password changed successfully";
                        Response.Redirect("Signin.aspx");
                    }
                    else
                    {
                        lblmessage.Text = "Sorry, old password does not match.";
                    }
                }
            }

        }
    }
}