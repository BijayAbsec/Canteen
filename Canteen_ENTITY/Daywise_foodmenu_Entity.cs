using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class Daywise_foodmenu_Entity
    {
        public int foodmenu_id { get; set; }
        public int food_id { get; set; }
        public int time_id { get; set; }
        public string category { get; set; }
        public int active_status { get; set; }
        public int created_by { get; set; }
        public string dateFrom { get; set; }
        public string dateTo { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }
    }
}
