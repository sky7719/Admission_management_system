using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.IO;

namespace Assignment1
{
    /// <summary>
    /// Progam that gives the user both the options 1. to enter the details of the 
    /// applicant using a stored comma seperated value file as well as 2. through console.
    /// stores the values into two seperate CSV files- Admission list and failed admission list
    /// according to the marks of the applicant.
    /// It also checks for the redundecy. If the data of the applicant is already present 
    /// in any of the files(Addmission list or failed admission list) it doesn't 
    /// store it again.
    /// </summary>
    class Program
    {
        public static List<Applicant> _AdmissionList = new List<Applicant>();
        public static List<Applicant> _FailedList = new List<Applicant>();
        public static string _FilePath1 = ".\\AdmissionList.csv";
        public static string _FilePath2 = ".\\FailedCollection.csv";
        public static string _UserInputFilePath = "";
        static void Main(string[] args)
        {
            FileIO.ReadRecord();
            Constant.MenuMessege();//calls the home function to take input form the user.
        }
        /// <summary>
        /// Prompts the user to choose one of the given functionalities at home page.
        /// </summary>
        public static void Homepage()
        {
            try
            {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1: FileIO.ReadUserInputFile();
                        break;
                    case 2:AddApplicant();//calls the Addaplicant function to enter the details of new user.
                        break;
                    case 3://Prints the admissionList and calls the sortmenu function 
                        Console.WriteLine("Record of applicants");
                        Constant.ViewList(_AdmissionList);
                        Constant.SortMessege(_AdmissionList);
                        break;
                    case 4://Prints the _FailedList and calls the sortmenu function 
                        Console.WriteLine("Students with score less than 60%.");
                        Constant.ViewList(_FailedList);
                        Constant.SortMessege(_FailedList);
                        break;
                    case 5: break;//Closes the program.
                    default:
                        Console.WriteLine("Wrong serial number entered.");
                        Homepage();
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Homepage();
            }
        }
        /// <summary>
        /// Prompts the user to enter the details of the applicant and checks 
        /// if the entered applicant's age is in the given range, weather the 
        /// applicant has scored more than 60% and the values are in right format.
        /// </summary>
        public static void AddApplicant()
        {
            try
            {
                Console.Write("Name of the applicant: ");
                string name = Console.ReadLine();
                Console.Write("Age: ");
                int age = Convert.ToInt16(Console.ReadLine());
                Console.Write("Percentage: ");
                double percentage = Convert.ToDouble(Console.ReadLine());
                Applicant apl1 = new Applicant(name, age, percentage);
                string[] val = { name, age.ToString(), percentage.ToString() };
                string str = string.Join(",", val);
                if (FileIO.CheckRedundency(str))
                {
                    try
                    {
                        ValidateApplicant(apl1);
                        CheckMarksGreaterThan60(apl1);
                        _AdmissionList.Add(apl1);//adds the applicant datails in the list.
                        FileIO.WriteRow(_FilePath1, apl1);//writes the applicant details in the file. 
                        Constant.PrintDetails(apl1);//prints the details of the new applicant.
                        Console.WriteLine(" Applicant added to record. ");
                    }
                    catch (MarksLessThan60Exception ex)
                    {
                        Console.WriteLine(ex.Message);//if the marks are less than 60% prints the messege and calls the homepage function.
                        _FailedList.Add(apl1);//adds the applicant datails in the failedapplicant  list.
                        FileIO.WriteRow(_FilePath2, apl1);//writes the applicant details in the failedApplicant file.
                        Constant.PrintDetails(apl1);//prints the details of the new applicant.
                        Console.WriteLine(" Applicant added to failed list. ");
                    }
                }
                else
                {
                    Console.WriteLine("Applicant's record already present in te list.");
                }
                Constant.MenuMessege();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);//if the outer try block throws an exception the following 
                Constant.MenuMessege();//code prints he messege and calls the homepage function
            }
        }
        /// <summary>
        /// Function to validate the applicant is of valid age(18 - 30) and has score above 60. Checks if the name entered contains only the alphabets or not. Throws exception if not.
        /// </summary>
        /// <param name="apl"></param>
        public static void ValidateApplicant(Applicant apl)
        {
            if (apl.Age<18 || apl.Age > 30)
            {
                throw new AgeOutOfRangeException();
            }
            if(apl.Percentage < 0 || apl.Percentage > 100)
            {
                throw new MarksOutOfRange();
            }
            if (!Regex.IsMatch(apl.Name, "^[a-zA-Z ]*$"))
            {
                throw new InvalidNameFormatException();
            }
        }
        /// <summary>
        /// Checks if the marks are greater than 60. if marks are less than 60 then throws exception.
        /// </summary>
        /// <param name="apl"></param>
        public static void CheckMarksGreaterThan60(Applicant apl)
        {
            if (apl.Percentage < 60)
            {
                throw new MarksLessThan60Exception();
            }
        }
        /// <summary>
        /// Prompts the user to select one option out of 1.sort by name,2.sort by percantage 3.go back to home page.
        /// </summary>
        /// <param name="Mylist"></param>
        public static void SortMenu(List<Applicant> Mylist)
        {
            ApplicantComparer Compare = new ApplicantComparer();
            try {
                int choice = Convert.ToInt32(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Compare.comp = ApplicantComparer.CompareBy.Name;
                        Mylist.Sort(Compare);//Sorts the list using the custom created comparer.
                        Constant.ViewList(Mylist);//shows the sorted list list
                        Constant.SortMessege(Mylist);//shows the sort menu .
                        break;
                    case 2:
                        Compare.comp = ApplicantComparer.CompareBy.Percentage;
                        Mylist.Sort(Compare);//Sorts the list using the custom created comparer. 
                        Constant.ViewList(Mylist);//shows the sorted list list
                        Constant.SortMessege(Mylist);//shows the sort menu .
                        break;
                    case 3:
                        Constant.MenuMessege();//takes the user back to hame page.
                        break;
                    default:
                        Console.WriteLine("Wrong choice. Please enter the right serial number");
                        SortMenu(Mylist);
                        break;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                SortMenu(Mylist);
            }
        }
    }
}
