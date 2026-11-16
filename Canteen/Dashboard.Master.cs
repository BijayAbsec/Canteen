using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Canteen
{
    public partial class Dashboard : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUserName.Text = Session["User_Name"].ToString();
            //lblUserName.Text = Session["user_id"].ToString();
            imgProfile.Src = "img/" + Session["user_image"].ToString();

            //if operator then.... 
            if (Convert.ToInt32(Session["user_role"].ToString()) == 3)
            {
                a_Food_setup.Visible = false;
                a_Item_setup.Visible = true;
                a_Role_setup.Visible = false;
                a_Time_setup.Visible = false;
                a_Token_setup.Visible = false;
                a_Unit_setup.Visible = false;
                a_Dept_setup.Visible = false;
                a_Staff_list.Visible = false;
            }
            else
            {
                a_Food_setup.Visible = true;
                a_Item_setup.Visible = true;
                a_Role_setup.Visible = true;
                a_Time_setup.Visible = true;
                a_Token_setup.Visible = true;
                a_Unit_setup.Visible = true;
                a_Dept_setup.Visible = true;
                a_Staff_list.Visible = true;
            }
        }
    }
}