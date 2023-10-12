using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Employee
    {

        public static int id = 1000;
        public string No { get; set; }

        private string _fullName;
        public string Fullname
        {
            get { return _fullName; }
            set
            {
                if (CheckOnlyChar(value)) _fullName = value;
                else Console.WriteLine("Ad yalniz herflerden ibaret olmalidir.");
            }
        }
        public string Position { get; set; }

        public double Salary { get; set; }

        public string DepartmentName { get; set; }
        public string EmployeeType { get; set; }
        public Employee(string departmentName)
        {
            id++;
            DepartmentName = departmentName;

            No = DepartmentName.Substring(0, 2).ToUpper() + id;
        }

        public void info()
        {
            Console.WriteLine(Fullname, No, DepartmentName);
        }


        public bool CheckOnlyChar(string value)
        {
            for (int i = 0; i < value.Length; i++)
            {

                if (!Char.IsLetter(value[i]))
                {
                    return false;
                }

            }
            return true;
        }

        public int Validation(string value)
        {
            string[] abc =  value.Split(new string[] { " " }, StringSplitOptions.None)
 ;
            return abc.Length;
        }
    }
}
