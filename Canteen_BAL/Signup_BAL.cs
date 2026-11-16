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
    public class Signup_BAL
    {
        Signup_DAL obj_Canteen_DAL = new Signup_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(User_Entity obj_User_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Canteen_DAL.Add_Edit_Delete(obj_User_Entity)) { return true; }
            else { return false; }
        }
        public DataTable Get_Details(User_Entity obj_User_Entity)
        {
            return obj_Canteen_DAL.Get_Details(obj_User_Entity);
        }
    }
}
