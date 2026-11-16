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
    public class Food_BAL
    {
        Food_DAL obj_Food_DAL = new Food_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Food_Entity obj_Food_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Food_DAL.Add_Edit_Delete(obj_Food_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Food_Entity obj_Food_Entity)
        {
            return obj_Food_DAL.Get_Details(obj_Food_Entity);
        }

        public DataTable Get_Food_Category(Food_Entity obj_Food_Entity)
        {
            return obj_Food_DAL.Get_Food_Category(obj_Food_Entity);
        }
    }
}
