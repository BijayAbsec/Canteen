using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen_ENTITY;
using Canteen_GlobalVariable;

namespace Canteen_DAL
{
    public class Signup_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public Signup_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }
        public int Add_Edit_Delete(User_Entity obj_User_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_Signup";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@User_ID", obj_User_Entity.user_id);
            sqlCmd.Parameters.AddWithValue("@Employee_Idno", obj_User_Entity.employee_idno);
            sqlCmd.Parameters.AddWithValue("@User_Name", obj_User_Entity.user_name);
            sqlCmd.Parameters.AddWithValue("@Email_ID", obj_User_Entity.user_email);
            sqlCmd.Parameters.AddWithValue("@Contact_No", obj_User_Entity.contact_no);
            sqlCmd.Parameters.AddWithValue("@Dept_Id", obj_User_Entity.dept_id);
            sqlCmd.Parameters.AddWithValue("@Roll_Id", obj_User_Entity.role_id);
            sqlCmd.Parameters.AddWithValue("@Active_Status", obj_User_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@Password", obj_User_Entity.user_password);
            sqlCmd.Parameters.AddWithValue("@User_Image", obj_User_Entity.user_image);
            sqlCmd.Parameters.AddWithValue("@Created_by", obj_User_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_User_Entity.flag);

            #endregion
            try
            {
                SqlCon.Open();
                sqlCmd.ExecuteNonQuery();
                status = 1;

                return status;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                SqlCon.Dispose();
                sqlCmd.Dispose();
            }
        }
        public DataTable Get_Details(User_Entity obj_User_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_Signup";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@User_ID", obj_User_Entity.user_id);
                sqlCmd.Parameters.AddWithValue("@Employee_Idno", obj_User_Entity.employee_idno);
                sqlCmd.Parameters.AddWithValue("@User_Name", obj_User_Entity.user_name);
                sqlCmd.Parameters.AddWithValue("@Email_ID", obj_User_Entity.user_email);
                sqlCmd.Parameters.AddWithValue("@Contact_No", obj_User_Entity.contact_no);
                sqlCmd.Parameters.AddWithValue("@Dept_Id", obj_User_Entity.dept_id);
                sqlCmd.Parameters.AddWithValue("@Roll_Id", obj_User_Entity.role_id);
                sqlCmd.Parameters.AddWithValue("@Active_Status", obj_User_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@Password", obj_User_Entity.user_password);
                sqlCmd.Parameters.AddWithValue("@User_Image", obj_User_Entity.user_image);
                sqlCmd.Parameters.AddWithValue("@Created_by", obj_User_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_User_Entity.flag);

                #endregion
                SqlDa = new SqlDataAdapter(sqlCmd);
                SqlDa.Fill(dt);
                if (dt.Rows.Count > 0)
                {

                }
                else
                {
                    dt = null;
                }
            }
            catch (Exception ex) { throw ex; }
            finally { SqlCon.Close(); }
            return dt;
        }
    }
}
