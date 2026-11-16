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
    public class Staff_list_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public Staff_list_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }
        public DataTable Get_Staff_List(User_Entity obj_User_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_Staff_list";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@User_ID", obj_User_Entity.user_id);
                sqlCmd.Parameters.AddWithValue("@flag", obj_User_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_User_Entity.search_value);
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
        public int Delete(User_Entity obj_User_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_Staff_list";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@User_ID", obj_User_Entity.user_id);
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
        public DataTable get_reqdata(User_Entity obj_User_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_index";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@dateFrom", obj_User_Entity.dateFrom);
                sqlCmd.Parameters.AddWithValue("@dateTo", obj_User_Entity.dateTo);
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
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                SqlCon.Close();
            }
            return dt;
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
                sqlCmd.CommandText = "msp_staff_list";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@User_ID", obj_User_Entity.user_id);
                sqlCmd.Parameters.AddWithValue("@employee_idno", obj_User_Entity.employee_idno);
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
