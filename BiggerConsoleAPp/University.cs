using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class University
    {

        // Name uchun encapsulation
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                if (value.Length >= 2) _name = value;
                else Console.WriteLine("Ad sertlere uygun deyil.");
            }
        }

        // WorkerLimit uchun encapsulation
        private int _workerLimit;
        public int WorkerLimit
        {
            get { return _workerLimit; }
            set
            {
                if (value >= 1) _workerLimit = value;
                else Console.WriteLine("Isci sayi sertlere uygun deyil.");
            }
        }

        // SalaryLimit uchun encapsulation
        private double _salaryLimit;
        public double SalaryLimit
        {
            get { return _salaryLimit; }
            set
            {
                if (value >= 250) _salaryLimit = value;
                else Console.WriteLine("Min. 250-den asaghi ola bilmez.");
            }
        }
        public List<Employee> Employees { get; set; }
        public List<Student> Students { get; set; }


        public University(string name, int workerLimit, double salaryLimit)
        {
            Name = name;
            WorkerLimit = workerLimit;
            SalaryLimit = salaryLimit;
            Employees = new List<Employee>();
            Students = new List<Student>();

        }

        public void info()
        {
            Console.WriteLine(Name);
        }

        public double CalcSalaryAverage()
        {
            if (Employees.Count == 0)
            {
                return 0;
            }

            double totalSalary = Employees.Sum(e => e.Salary);
            return totalSalary / Employees.Count;
        }


        public double CalcStudentsAverage(GroupType groupType)
        {
            int totalPoints;

            if (groupType == 0)
            {
                if (Students.Count == 0)
                {
                    return 0;
                }

                totalPoints = Students.Sum(s => s.Point);
                return totalPoints / Students.Count;

            }

            List<Student> listStudents = Students.Where(s => s.GroupType == groupType).ToList();
            if (listStudents.Count == 0)
            {
                return 0;
            }

            totalPoints = listStudents.Sum(s => s.Point);
            return totalPoints / listStudents.Count;
        }

        public void AddEmployee(Employee employee)
        {
            if (Employees.Count < WorkerLimit)
            {
                Employees.Add(employee);
                Console.WriteLine("Elave olundu.");
            }
            else
            {
                Console.WriteLine("Elave edile bilmedi.Limite catilibdir.");
            }
        }

        public void UpdateEmployee(string employeeNo, double newSalary, string newPosition)
        {
            Employee employee = Employees.FirstOrDefault(e => e.No == employeeNo);
            if (employee != null)
            {
                employee.Salary = newSalary;
                employee.Position = newPosition;
                Console.WriteLine("İşçinin maaşı və vəzifəsi yeniləndi.");
            }
            else
            {
                Console.WriteLine("İşçi tapılmadı.");
            }
        }

        public void DeleteEmployee(string employeeNo)
        {
            var employee = Employees.FirstOrDefault(e => e.No == employeeNo);
            if (employee != null)
            {
                Employees.Remove(employee);
                Console.WriteLine("İşçi silindi.");
            }
            else
            {
                Console.WriteLine("İşçi tapılmadı.");
            }
        }


        public void AddStudent(Student student)
        {
            Students.Add(student);
            Console.WriteLine("Elave olundu.");
        }
        public void StudentUpdate(string groupNo, string newGroupNo)
        {
            var students = Students.Where(s => s.GroupNo == groupNo).ToList();
            if (students.Count > 0)
            {
                foreach (var student in students)
                {
                    student.GroupNo = newGroupNo;
                    Console.WriteLine("Qrup nomresi deyisdirildi.");

                }
            }
            else
            {
                Console.WriteLine("Telebe tapilmadi.");
            }
        }

    }
}
