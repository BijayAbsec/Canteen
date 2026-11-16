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
    public class Changepassword_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;

        public Changepassword_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }
        public int Add_Edit_Delete(Password_Entity obj_Password_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand(); 
            sqlCmd.CommandText = "msp_ChangePassword";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@old_password", obj_Password_Entity.Old_password);
            sqlCmd.Parameters.AddWithValue("@new_password", obj_Password_Entity.New_password);
            sqlCmd.Parameters.AddWithValue("@User_Id", obj_Password_Entity.user_id);

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
        public DataTable Get_Details(Password_Entity obj_Password_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_ChangePassword";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@old_password", obj_Password_Entity.Old_password);
                sqlCmd.Parameters.AddWithValue("@new_password", obj_Password_Entity.New_password);
                sqlCmd.Parameters.AddWithValue("@User_Id", obj_Password_Entity.user_id);

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
