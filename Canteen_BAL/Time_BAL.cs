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
    public class Time_BAL
    {
        Time_DAL obj_Time_DAL = new Time_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Time_Entity obj_Time_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Time_DAL.Add_Edit_Delete(obj_Time_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Time_Entity obj_Time_Entity)
        {
            return obj_Time_DAL.Get_Details(obj_Time_Entity);
        }
    }
}
