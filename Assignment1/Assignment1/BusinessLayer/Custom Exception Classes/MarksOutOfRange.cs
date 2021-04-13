using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{ 
    class MarksOutOfRange: Exception
    {
        public MarksOutOfRange() : base(string.Format("Marks out of range. Marks should be between 1 - 100")) { }
    }
}
