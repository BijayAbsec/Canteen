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
    public class Unit_BAL
    {
        Unit_DAL obj_Unit_DAL = new Unit_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Unit_Entity obj_Unit_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Unit_DAL.Add_Edit_Delete(obj_Unit_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Unit_Entity obj_Unit_Entity)
        {
            return obj_Unit_DAL.Get_Details(obj_Unit_Entity);
        }
    }
}
