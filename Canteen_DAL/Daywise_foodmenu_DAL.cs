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
    public class Daywise_foodmenu_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public Daywise_foodmenu_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }

        public int Add_Edit_Delete(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_daywise_foodmenu";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@foodmenu_id", obj_Daywise_foodmenu_Entity.foodmenu_id);
            sqlCmd.Parameters.AddWithValue("@food_id", obj_Daywise_foodmenu_Entity.food_id);
            sqlCmd.Parameters.AddWithValue("@time_id", obj_Daywise_foodmenu_Entity.time_id);
            sqlCmd.Parameters.AddWithValue("@category", obj_Daywise_foodmenu_Entity.category);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_Daywise_foodmenu_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_Daywise_foodmenu_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_Daywise_foodmenu_Entity.flag);

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

        public DataTable Get_Details(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_daywise_foodmenu";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@foodmenu_id", obj_Daywise_foodmenu_Entity.foodmenu_id);
                sqlCmd.Parameters.AddWithValue("@food_id", obj_Daywise_foodmenu_Entity.food_id);
                sqlCmd.Parameters.AddWithValue("@time_id", obj_Daywise_foodmenu_Entity.time_id);
                sqlCmd.Parameters.AddWithValue("@category", obj_Daywise_foodmenu_Entity.category);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_Daywise_foodmenu_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_Daywise_foodmenu_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Daywise_foodmenu_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_Daywise_foodmenu_Entity.search_value);
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
        public DataTable get_reqdata(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
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
                sqlCmd.Parameters.AddWithValue("@dateFrom", obj_Daywise_foodmenu_Entity.dateFrom);
                sqlCmd.Parameters.AddWithValue("@dateTo", obj_Daywise_foodmenu_Entity.dateTo);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Daywise_foodmenu_Entity.flag);
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
