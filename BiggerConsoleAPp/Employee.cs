using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Employee : Validation
    {

        public static int id = 1000;
        public string No { get; set; }

        // fullName uchun encapsulation
        private string _fullName;
        public string Fullname
        {
            get { return _fullName; }
            set
            {
                if (CheckWords(value)) _fullName = value;
                else Console.WriteLine("Ad sertlere uygun deyil.");
            }
        }

        // position uchun encapsulation
        private string _position;
        public string Position
        {
            get { return _position; }
            set
            {
                if (value.Length >= 2) _position = value;
                else Console.WriteLine("Pozisiya sertlere uygun deyil.");
            }
        }

        // salary uchun encapsulation
        private double _salary;
        public double Salary
        {
            get { return _salary; }
            set
            {
                if (value >= 250) _salary = value;
                else Console.WriteLine("Maash 250-den asagi ola bilmez.");
            }
        }

        public Department DepartmentName { get; set; }
        public EmployeeType EmployeeType { get; set; }

        public Employee(string fullname, string position, double salary, Department department, EmployeeType employeeType)
        {
            id++;
            No = employeeNo(department, id);
            Fullname = fullname;
            Position = position;
            Salary = salary;
            DepartmentName = department;
            EmployeeType = employeeType;
        }


        // Ischiler haqqinda melumat
        public void getInfo()
        {

            Console.WriteLine($"Ischi nomresi: {No},\n" +
                $"Ad ve soyad: {Fullname},\n" +
                $"Pozisiya: {Position},\n" +
                $"Maash: {Salary},\n" +
                $"Department: {DepartmentName},\n" +
                $"Ischi novu: {EmployeeType}");
        }

        // employee No uchun validation
        public string employeeNo(Department department, int id)
        {
            if (department != 0)
            {
                return department.ToString().Substring(0, 3).ToUpper() + id;

            }
            return department.ToString().Substring(0, 2).ToUpper() + id;
        }
    }
}
