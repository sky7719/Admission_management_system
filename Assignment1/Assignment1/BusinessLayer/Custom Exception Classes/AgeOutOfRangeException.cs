using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class AgeOutOfRangeException: Exception
    {
        public AgeOutOfRangeException() : base(string.Format("!!! Age is not in the requied range(18 years - 30 years). !!!")) { }
        //created new custom exception to check if the entered age is in the range 18 to 30.
    }
}
