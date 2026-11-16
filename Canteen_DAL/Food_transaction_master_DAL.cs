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
    public class Food_transaction_master_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public Food_transaction_master_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }

        public DataTable Get_Details(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_food_transaction_master";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@foodtransaction_id", obj_Food_transaction_master_Entity.foodtransaction_id);
                sqlCmd.Parameters.AddWithValue("@user_id", obj_Food_transaction_master_Entity.user_id);
                sqlCmd.Parameters.AddWithValue("@time_id", obj_Food_transaction_master_Entity.time_id);
                sqlCmd.Parameters.AddWithValue("@category", obj_Food_transaction_master_Entity.category);
                sqlCmd.Parameters.AddWithValue("@token_no", obj_Food_transaction_master_Entity.token_no);
                sqlCmd.Parameters.AddWithValue("@guest_no", obj_Food_transaction_master_Entity.guest_no);
                //sqlCmd.Parameters.AddWithValue("@active_status", obj_Food_transaction_master_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_Food_transaction_master_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Food_transaction_master_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@food_id", obj_Food_transaction_master_Entity.food_id);
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

        public int Add_Edit_Delete(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_food_transaction_master";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@foodtransaction_id", obj_Food_transaction_master_Entity.foodtransaction_id);
            sqlCmd.Parameters.AddWithValue("@user_id", obj_Food_transaction_master_Entity.user_id);
            sqlCmd.Parameters.AddWithValue("@time_id", obj_Food_transaction_master_Entity.time_id);
            sqlCmd.Parameters.AddWithValue("@category", obj_Food_transaction_master_Entity.category);
            sqlCmd.Parameters.AddWithValue("@token_no", obj_Food_transaction_master_Entity.token_no);
            sqlCmd.Parameters.AddWithValue("@guest_no", obj_Food_transaction_master_Entity.guest_no);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_Food_transaction_master_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_Food_transaction_master_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_Food_transaction_master_Entity.flag);
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

        public DataTable Add_Edit(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_food_transaction_master";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@foodtransaction_id", obj_Food_transaction_master_Entity.foodtransaction_id);
                sqlCmd.Parameters.AddWithValue("@user_id", obj_Food_transaction_master_Entity.user_id);
                sqlCmd.Parameters.AddWithValue("@time_id", obj_Food_transaction_master_Entity.time_id);
                sqlCmd.Parameters.AddWithValue("@category", obj_Food_transaction_master_Entity.category);
                sqlCmd.Parameters.AddWithValue("@token_no", obj_Food_transaction_master_Entity.token_no);
                sqlCmd.Parameters.AddWithValue("@guest_no", obj_Food_transaction_master_Entity.guest_no);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_Food_transaction_master_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_Food_transaction_master_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Food_transaction_master_Entity.flag);
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
        public DataTable get_reqdata(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
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
                sqlCmd.Parameters.AddWithValue("@dateFrom", obj_Food_transaction_master_Entity.dateFrom);
                sqlCmd.Parameters.AddWithValue("@dateTo", obj_Food_transaction_master_Entity.dateTo);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Food_transaction_master_Entity.flag);
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
