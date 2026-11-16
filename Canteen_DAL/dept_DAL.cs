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
    public class dept_DAL
    {
        string Canteen_ConnectionSettings = string.Empty;
        public dept_DAL()
        {
            Globalvariable objConnectionSettings = new Globalvariable();
            Canteen_ConnectionSettings = objConnectionSettings.Cloud_Connection;
        }
        public int Add_Edit_Delete(dept_entity obj_dept_Entity)
        {
            int status = 0;
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);

            SqlCommand sqlCmd = SqlCon.CreateCommand();
            sqlCmd.CommandText = "msp_dept";
            sqlCmd.CommandType = CommandType.StoredProcedure;
            #region Entites
            sqlCmd.Parameters.AddWithValue("@dept_id", obj_dept_Entity.dept_id);
            sqlCmd.Parameters.AddWithValue("@dept_name", obj_dept_Entity.dept_name);
            sqlCmd.Parameters.AddWithValue("@active_status", obj_dept_Entity.active_status);
            sqlCmd.Parameters.AddWithValue("@created_by", obj_dept_Entity.created_by);
            sqlCmd.Parameters.AddWithValue("@flag", obj_dept_Entity.flag);

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
        public DataTable Get_requireddata(dept_entity obj_dept_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_dept";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@dept_id", obj_dept_Entity.dept_id);
                sqlCmd.Parameters.AddWithValue("@dept_name", obj_dept_Entity.dept_name);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_dept_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_dept_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_dept_Entity.flag);
                sqlCmd.Parameters.AddWithValue("@search_value", obj_dept_Entity.search_value);
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
        public DataTable Get_Details(dept_entity obj_dept_Entity)
        {
            SqlDataAdapter SqlDa = new SqlDataAdapter();
            SqlConnection SqlCon = new SqlConnection(Canteen_ConnectionSettings);
            SqlCommand sqlCmd = SqlCon.CreateCommand();
            DataTable dt = new DataTable();
            try
            {
                SqlCon.Open();
                sqlCmd.Connection = SqlCon;
                sqlCmd.CommandText = "msp_getdept";
                sqlCmd.CommandType = CommandType.StoredProcedure;
                #region Entites
                sqlCmd.Parameters.AddWithValue("@dept_id", obj_dept_Entity.dept_id);
                sqlCmd.Parameters.AddWithValue("@dept_name", obj_dept_Entity.dept_name);
                sqlCmd.Parameters.AddWithValue("@active_status", obj_dept_Entity.active_status);
                sqlCmd.Parameters.AddWithValue("@created_by", obj_dept_Entity.created_by);
                sqlCmd.Parameters.AddWithValue("@flag", obj_dept_Entity.flag);

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
