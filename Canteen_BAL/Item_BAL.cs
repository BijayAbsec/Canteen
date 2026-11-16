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
    public class Item_BAL
    {
        Item_DAL obj_Item_DAL = new Item_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Item_Entity obj_Item_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Item_DAL.Add_Edit_Delete(obj_Item_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Item_Entity obj_Item_Entity)
        {
            return obj_Item_DAL.Get_Details(obj_Item_Entity);
        }
    }
}
