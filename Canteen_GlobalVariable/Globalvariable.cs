using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canteen_GlobalVariable
{
    public class Globalvariable
    {
        private string ConnectionSettings;
        private int Status;

        public string Cloud_Connection
        {
            get
            {
                return ConnectionSettings = ConfigurationManager.ConnectionStrings["dbConnection"].ConnectionString;
            }
        }

        public int StatusMessage
        {
            get
            {
                return Status = 1;
            }
        }
    }
}

