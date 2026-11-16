using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class role_entity
    {
        public int role_id { get; set; }
        public string role_name { get; set; }
        public int active_status { get; set; }
        public int created_by { get; set; }
        public string created_date { get; set; }
        public string updated_by { get; set; }
        public string updated_date { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }
    }
}
