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
    public class role_BAL
    {
        role_DAL obj_Canteen_DAL = new role_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(role_entity obj_role_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Canteen_DAL.Add_Edit_Delete(obj_role_Entity)) { return true; }
            else { return false; }
        }
        public DataTable Get_requireddata(role_entity obj_role_Entity)
        {
            return obj_Canteen_DAL.Get_requireddata(obj_role_Entity);
        }
        public DataTable Get_Details(role_entity obj_role_Entity)
        {
            return obj_Canteen_DAL.Get_Details(obj_role_Entity);
        }
    }
}
