using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    /// <summary>
    /// Class Applicant- Helps in storing the applicant's information in the List and CSV file.
    /// </summary>
    class Applicant
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public double Percentage { get; private set; }
        public Applicant(string aName, int aAge, double aPercentage)//Constructor
        {
            Name = aName;
            Age = aAge;
            Percentage = aPercentage;
        }
    }
}
