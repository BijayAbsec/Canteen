using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class Item_Entity
    {
        public int item_id { get; set; }
        public string item_name { get; set; }
        public int active_status { get; set; }
        public int created_by { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }
    }
}
