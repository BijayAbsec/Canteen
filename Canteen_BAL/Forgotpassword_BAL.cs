using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Canteen_DAL;
using Canteen_ENTITY;
using Canteen_GlobalVariable;

namespace Canteen_BAL
{
    public class Forgotpassword_BAL
    {

        Forgotpassword_DAL obj_Canteen_DAL = new Forgotpassword_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Password_Entity obj_Password_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Canteen_DAL.Add_Edit_Delete(obj_Password_Entity)) { return true; }
            else { return false; }
        }
        public DataTable Get_Details(Password_Entity obj_Password_Entity)
        {
            return obj_Canteen_DAL.Get_Details(obj_Password_Entity);
        }

    }
}
