using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class MarksLessThan60Exception: Exception
    {
        public MarksLessThan60Exception() : base(string.Format("!!! Marks are less than the requirement(>60%). !!!")) { }
        //Created new exception class to throw exception if the marks of the applicant is less than 60.
    }
}
