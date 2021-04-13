using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1
{
    class Constant
    {
        /// <summary>
        /// Prints all the different functionalities to perform on the data and calls the HomePage() function.
        /// </summary>
        public static void MenuMessege()
        {
            Console.WriteLine();
            Console.WriteLine("               MENU");
            Console.WriteLine(" 1 Add data from CSV file.");
            Console.WriteLine(" 2 Add an applicant's Information.");
            Console.WriteLine(" 3 View admission list");
            Console.WriteLine(" 4 View failed admission list");
            Console.WriteLine(" 5 Exit");
            Console.Write("Enter serial number(1 to 5) and press Enter : ");
            Program.Homepage();
        }
        /// <summary>
        /// Prompts the user to select one option out of sort by name, sort by percantage and go back to home page.
        /// </summary>
        /// <param name="MyList"></param>
        public static void SortMessege(List<Applicant> MyList)
        {
            try
            {
                Console.WriteLine("  Enter Serial number of your choice.");
                Console.WriteLine("  1 Sort by name.");
                Console.WriteLine("  2 Sort by percentage.");
                Console.WriteLine("  3 Go back to home page.");
                Program.SortMenu(MyList);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Program.SortMenu(MyList);
            }
            
        }
        /// <summary>
        /// Prints the Age, Percentage, first name, last name and the middle name from the field 'name' .
        /// </summary>
        /// <param name="apl"></param>
        public static void PrintDetails(Applicant apl)
        {
            string[] names = apl.Name.Split(' ');
            if (names.Length == 3)
            {
                //to print the data of the applicant if the applicant enters first name, middle name and last name.
                Console.WriteLine("{0}   {1}   {2}   {3}   {4}", "| First Name".PadRight(20), "| Middle Name".PadRight(20), "| Last Name".PadRight(20), "| Age".PadRight(10), "| Percentage |");
                Console.WriteLine("| {0} | {1} | {2} | {3}  | {4} |", names[0].PadRight(20), names[1].PadRight(20), names[2].PadRight(20), apl.Age.ToString().PadRight(9), apl.Percentage.ToString().PadRight(10));
            }
            else if (names.Length == 2)
            {
                //to print the data of the applicant if the applicant enters first name and last name.
                Console.WriteLine("{0}   {1}   {2}   {3}   {4}", "| First Name".PadRight(20), "| Middle Name".PadRight(20), "| Last Name".PadRight(20), "| Age".PadRight(10), "| Percentage |");
                Console.WriteLine("| {0} | {1} | {2} | {3}  | {4} |", names[0].PadRight(20), "".PadRight(20), names[1].PadRight(20), apl.Age.ToString().PadRight(9), apl.Percentage.ToString().PadRight(10));
            }
            else if (names.Length == 1)
            {
                //to print the data of the applicant if the applicant enters only first name.
                Console.WriteLine("{0}   {1}   {2}   {3}   {4}", "| First Name".PadRight(20), "| Middle Name".PadRight(20), "| Last Name".PadRight(20), "| Age".PadRight(10), "| Percentage |");
                Console.WriteLine("| {0} | {1} | {2} | {3}  | {4} |", names[0].PadRight(20), "".PadRight(20), "".PadRight(20), apl.Age.ToString().PadRight(9), apl.Percentage.ToString().PadRight(10));
            }
        }
        /// <summary>
        /// Takes a list of Applicant class object and prints its data mambers in the form of table.
        /// </summary>
        /// <param name="apl"></param>
        public static void ViewList(List<Applicant> apl)
        {
            //prints the passed list.
            Console.WriteLine("{0}   {1}   {2}", "| Name".PadRight(30), "| Age".PadRight(10), "| Percentage |");
            foreach (Applicant obj in apl)
            {
                Console.WriteLine("| {0} | {1} | {2} |", obj.Name.PadRight(30), obj.Age.ToString().PadRight(10), obj.Percentage.ToString().PadRight(10));
            }
        }
    }
}
