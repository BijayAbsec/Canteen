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
    public class Food_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;

        public Food_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }

        public int Add_Edit_Delete(Food_Entity obj_Food_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_food";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@food_id", obj_Food_Entity.food_id);
            sqlCmd.Parameters.AddWithValue("@food_name", obj_Food_Entity.food_name);
            sqlCmd.Parameters.AddWithValue("@price", obj_Food_Entity.price);
            sqlCmd.Parameters.AddWithValue("@category", obj_Food_Entity.category);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_Food_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_Food_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_Food_Entity.flag);

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

        public DataTable Get_Details(Food_Entity obj_Food_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_food";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@food_id", obj_Food_Entity.food_id);
                sqlCmd.Parameters.AddWithValue("@food_name", obj_Food_Entity.food_name);
                sqlCmd.Parameters.AddWithValue("@price", obj_Food_Entity.price);
                sqlCmd.Parameters.AddWithValue("@category", obj_Food_Entity.category);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_Food_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_Food_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_Food_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_Food_Entity.search_value);
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

        public DataTable Get_Food_Category(Food_Entity obj_Food_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.CommandText = "msp_get_food_category";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites                
                sqlCmd.Parameters.AddWithValue("@flag", obj_Food_Entity.flag);
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
