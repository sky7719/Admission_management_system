using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class ApplicantComparer: IComparer<Applicant>
    {
        //New applicant class to create a comparer to help in sorting the list according to a datamember.
        public enum CompareBy
        {
            Percentage,
            Name
        }
        public CompareBy comp;
        public int Compare(Applicant a, Applicant b)
        {
            switch (comp)
            {
                case CompareBy.Percentage: return b.Percentage.CompareTo(a.Percentage);
                    //if the user wants to sort by percentage then this comparer is used.
                case CompareBy.Name: return a.Name.CompareTo(b.Name);
                //if the user wants to sort y name then this comparer is used.
                default:  return a.Name.CompareTo(b.Name);
            }
        }
    }
}
