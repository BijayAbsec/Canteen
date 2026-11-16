using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class User_Entity
    {
        public int user_id { get; set; }
        public string employee_idno { get; set; }
        public string user_name { get; set; }
        public string user_email { get; set; }
        public string contact_no { get; set; }
        public int dept_id { get; set; }
        public int role_id { get; set; }
        public int active_status { get; set; }
        public string user_image { get; set; }
        public string user_password { get; set; }
        public string created_by { get; set; }
        public string created_date { get; set; }
        public string updated_by { get; set; }
        public string updated_date { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }



    }
}
