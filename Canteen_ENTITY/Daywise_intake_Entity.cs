using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_ENTITY
{
    public class Daywise_intake_Entity
    {
        public int intake_id { get; set; }
        public int item_id { get; set; }
        public decimal quantity { get; set; }
        public int unit_id { get; set; }
        public string price { get; set; }
        public int active_status { get; set; }
        public int created_by { get; set; }
        public string flag { get; set; }
        public string search_value { get; set; }
    }
}
