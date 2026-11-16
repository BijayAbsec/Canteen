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
    public class Signin_BAL
    {
        Signin_DAL obj_Canteen_DAL = new Signin_DAL();
        Globalvariable StatusMessageNo = new Globalvariable();
        public DataTable Get_Details(User_Entity obj_User_Entity)
        {

            return obj_Canteen_DAL.Get_Details(obj_User_Entity);
        }
    }
}
