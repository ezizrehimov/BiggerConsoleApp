using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Employee emp = new Employee("aziz rahimov", "sadas", 300, Department.IT, EmployeeType.Parttime);
           
            emp.getInfo();

           
            //foreach (var item in emo.Validation("salam necesen sag")) {
            //    Console.WriteLine(item);
            //}

        }
    }
}
