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
    public class dept_BAL
    {
        dept_DAL obj_Canteen_DAL = new dept_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(dept_entity obj_dept_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Canteen_DAL.Add_Edit_Delete(obj_dept_Entity)) { return true; }
            else { return false; }
        }
        public DataTable Get_requireddata(dept_entity obj_dept_Entity)
        {
            return obj_Canteen_DAL.Get_requireddata(obj_dept_Entity);
        }
        public DataTable Get_Details(dept_entity obj_dept_Entity)
        {
            return obj_Canteen_DAL.Get_Details(obj_dept_Entity);
        }
    }
}
