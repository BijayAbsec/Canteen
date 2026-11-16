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
    public class Food_transaction_master_BAL
    {
        Food_transaction_master_DAL obj_Food_transaction_master_DAL = new Food_transaction_master_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_Food_transaction_master_DAL.Add_Edit_Delete(obj_Food_transaction_master_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            return obj_Food_transaction_master_DAL.Get_Details(obj_Food_transaction_master_Entity);
        }

        public DataTable Add_Edit(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            return obj_Food_transaction_master_DAL.Get_Details(obj_Food_transaction_master_Entity);
        }
        public DataTable get_reqdata(Food_transaction_master_Entity obj_Food_transaction_master_Entity)
        {
            return obj_Food_transaction_master_DAL.get_reqdata(obj_Food_transaction_master_Entity);
        }

    }
}
