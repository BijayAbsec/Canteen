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
    public class Time_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;

        public Time_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }

        public int Add_Edit_Delete(Time_Entity obj_Time_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_time";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@time_id", obj_Time_Entity.time_id);
            sqlCmd.Parameters.AddWithValue("@time_name", obj_Time_Entity.time_name);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_Time_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_Time_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_Time_Entity.flag);

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

        public DataTable Get_Details(Time_Entity obj_Time_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_time";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@time_id", obj_Time_Entity.time_id);
                sqlCmd.Parameters.AddWithValue("@time_name", obj_Time_Entity.time_name);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_Time_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_Time_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Time_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_Time_Entity.search_value);                
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
    }
}
