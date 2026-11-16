using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class Token_Entity
    {
        public int token_id { get; set; }
        public string token_name { get; set; }
        public int active_status { get; set; }
        public int created_by { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }
    }
}
