using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class InvalidNameFormatException: Exception
    {
        public InvalidNameFormatException() : base(string.Format("Name can not include any thing other than alphabets.")) { }
        //created new custom exception to check if  name entered by the user contains only alphabets.
    }
}
