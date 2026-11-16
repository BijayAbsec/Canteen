using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen_DAL;
using Canteen_ENTITY;
using Canteen_GlobalVariable;
namespace Canteen_BAL
{
    public class Staff_list_BAL
    {
        Staff_list_DAL obj_Staff_list_DAL = new Staff_list_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();
        public DataTable Get_Staff_List(User_Entity obj_User_Entity)
        {
            return obj_Staff_list_DAL.Get_Staff_List(obj_User_Entity);
        }
        public bool Delete(User_Entity obj_User_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Staff_list_DAL.Delete(obj_User_Entity)) { return true; }
            else { return false; }
        }
        public bool Add_Edit_Delete(User_Entity obj_User_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Staff_list_DAL.Add_Edit_Delete(obj_User_Entity)) { return true; }
            else { return false; }
        }
        public DataTable get_reqdata(User_Entity obj_User_Entity)
        {
            return obj_Staff_list_DAL.get_reqdata(obj_User_Entity);
        }
        public DataTable Get_Details(User_Entity obj_User_Entity)
        {
            return obj_Staff_list_DAL.Get_Details(obj_User_Entity);
        }
    }
}
