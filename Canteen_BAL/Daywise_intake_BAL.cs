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
    public class Daywise_intake_BAL
    {
        Daywise_intake_DAL obj_Daywise_intake_DAL = new Daywise_intake_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();
        public bool Add(Daywise_intake_Entity obj_Daywise_intake_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Daywise_intake_DAL.Add_Edit_Delete(obj_Daywise_intake_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Daywise_intake_Entity obj_Daywise_intake_Entity)
        {
            return obj_Daywise_intake_DAL.Get_Details(obj_Daywise_intake_Entity);
        }
    }
}
