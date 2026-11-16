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
    public class Daywise_foodmenu_BAL
    {
        Daywise_foodmenu_DAL obj_Daywise_foodmenu_DAL = new Daywise_foodmenu_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Daywise_foodmenu_DAL.Add_Edit_Delete(obj_Daywise_foodmenu_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
        {
            return obj_Daywise_foodmenu_DAL.Get_Details(obj_Daywise_foodmenu_Entity);
        }
        public DataTable get_reqdata(Daywise_foodmenu_Entity obj_Daywise_foodmenu_Entity)
        {
            return obj_Daywise_foodmenu_DAL.get_reqdata(obj_Daywise_foodmenu_Entity);
        }
    }
}
