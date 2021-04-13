using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assignment1
{ 
    class FileIO
    {
        /// <summary>
        /// Reads the data from the file provided by the user and stores in the Admission list and Failed List.
        /// </summary>
        public static void ReadUserInputFile()
        {
            Console.Write("Enter the location:");
            Program._UserInputFilePath = Console.ReadLine();
            if (File.Exists(Program._UserInputFilePath))
            {
                string[] text1 = File.ReadAllLines(Program._UserInputFilePath);
                foreach (string line in text1)
                {
                    try
                    {
                        if (CheckRedundency(line.Replace(" ", "").ToLower()))
                        {
                            string[] aplicant = line.Split(',');
                            Applicant newAppl = new Applicant(aplicant[0], Convert.ToInt32(aplicant[1]), Convert.ToDouble(aplicant[2]));
                            Program.ValidateApplicant(newAppl);
                            if (newAppl.Percentage < 60.0)
                            {
                                Program._FailedList.Add(newAppl);
                                WriteRow(Program._FilePath2, newAppl);
                            }
                            else
                            {
                                Program._AdmissionList.Add(newAppl);
                                WriteRow(Program._FilePath1, newAppl);
                            }
                        }
                    }
                    catch
                    {
                        continue;
                    }
                }
                Console.WriteLine("Data form the given file added to the record.");
                Constant.MenuMessege();
            }
            else
            {
                Console.WriteLine("File does not exist.");
                Console.WriteLine();
                Constant.MenuMessege();
            }
        }
        /// <summary>
        /// Checks if the data of the new applicant is already in the recard.
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static bool CheckRedundency(string str)
        {
            
            str.Replace(" ", "").ToLower();
            string[] text1 = File.ReadAllLines(Program._FilePath1);
            string[] text2 = File.ReadAllLines(Program._FilePath2);
            for (int i = 0; i < text1.Length; i++)
            {
                text1[i] = text1[i].Replace(" ", "").ToLower();
            }
            for (int i = 0; i < text2.Length; i++)
            {
                text2[i] = text2[i].Replace(" ", "").ToLower();
            }
            if (text1.Contains(str) || text2.Contains(str))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
        /// <summary>
        /// Converts the data members of the object in comma seperated string and write them in the file line by line.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="apl"></param>
        public static void WriteRow(string filePath, Applicant apl)
        {
            string[] val = { apl.Name, apl.Age.ToString(), apl.Percentage.ToString() };
            string str = string.Join(",", val);
            string[] text1 = File.ReadAllLines(filePath);
            str = str + "\n";
            if (text1 == null)
            {
                File.WriteAllText(filePath, str);
            }
            else
            {
                File.AppendAllText(filePath, str);
            }
        }
        /// <summary>
        /// take the data line-by-line from the file at filePath, creates objects and stores it in the list.
        /// </summary>
        /// <param name="filePath"></param>
        /// <param name="apl"></param>
        public static void ReadRow(string filePath, List<Applicant> apl)
        {
            string[] text1 = File.ReadAllLines(filePath);
            if (text1 == null)//checks if the file is empty
            {
                return;
            }
            else
            {
                foreach (string line in text1)
                {
                    string[] aplicant = line.Split(',');
                    Applicant newAppl = new Applicant(aplicant[0], Convert.ToInt32(aplicant[1]), Convert.ToDouble(aplicant[2]));
                    apl.Add(newAppl);
                }
            }
        }
        /// <summary>
        /// Reads the data already stored in college record(Admission list and Failed admission list and stores them in arrays.
        /// </summary>
        public static void ReadRecord()
        {
            if (File.Exists(Program._FilePath1))
            {
                ReadRow(Program._FilePath1, Program._AdmissionList);
            }
            else
            {
                File.WriteAllText(Program._FilePath1, "");
            }
            if (File.Exists(Program._FilePath2))
            {
                ReadRow(Program._FilePath2, Program._FailedList);
            }
            else
            {
                File.WriteAllText(Program._FilePath2, "");
            }
        }
    }
}
