using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Airforce_Project.Classes
{
    public class SQL_Database_Not_Found_Exception : Exception
    {
        public SQL_Database_Not_Found_Exception(string message)
           : base(message)
        {

        }
    }
}
