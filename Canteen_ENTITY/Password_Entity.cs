using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class Password_Entity
    {
        public int user_id { get; set; }
        public string user_email { get; set; }
        public string Old_password { get; set; }
        public string New_password { get; set; }
        public string Confirm_password { get; set; }
        public int active_status { get; set; }
        public string created_by { get; set; }
        public string flag { get; set; }
    }
}
