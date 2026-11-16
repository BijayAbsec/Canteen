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
    public class role_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public role_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }
        public int Add_Edit_Delete(role_entity obj_role_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_role";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@role_id", obj_role_Entity.role_id);
            sqlCmd.Parameters.AddWithValue("@role_name", obj_role_Entity.role_name);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_role_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_role_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_role_Entity.flag);

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
        public DataTable Get_requireddata(role_entity obj_role_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_role";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@role_id", obj_role_Entity.role_id);
                sqlCmd.Parameters.AddWithValue("@role_name", obj_role_Entity.role_name);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_role_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_role_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_role_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_role_Entity.search_value);
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
        public DataTable Get_Details(role_entity obj_role_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_getrole";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@role_id", obj_role_Entity.role_id);
                sqlCmd.Parameters.AddWithValue("@role_name", obj_role_Entity.role_name);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_role_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_role_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_role_Entity.flag);

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
