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
    public class Token_BAL
    {
        Token_DAL obj_token_DAL = new Token_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();

        public bool Add_Edit_Delete(Token_Entity obj_token_Entity)
        {
            if (StatusMessageNo.StatusMessage == obj_token_DAL.Add_Edit_Delete(obj_token_Entity)) { return true; }
            else { return false; }
        }

        public DataTable Get_Details(Token_Entity obj_token_Entity)
        {
            return obj_token_DAL.Get_Details(obj_token_Entity);
        }
    }
}
