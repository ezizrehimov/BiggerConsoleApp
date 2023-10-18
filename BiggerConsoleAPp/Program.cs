using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Validation do-while check uchun
            Validation validation = new Validation();


            // university uchun lazimi value-lar
            Console.Write("Universitet adini daxil edin: ");
            string uniName = Console.ReadLine();

            string uniWorkerLimitStr = "";
            int uniWorkerLimit = 0;
            validation.doWhileChecker_int("Ischi limitini daxil edin: ", ref uniWorkerLimitStr, ref uniWorkerLimit);


            string uniSalaryLimitStr = "";
            double uniSalaryLimit = 0;
            validation.doWhileChecker_double("Maash limitini daxil edin: ", ref uniSalaryLimitStr, ref uniSalaryLimit);

            University university = new University(uniName, uniWorkerLimit, uniSalaryLimit);

            // esas dongu burada baslayir.
            while (true)
            {
                string mainChoiseStr;
                int mainChoise;
                do
                {
                    Console.WriteLine("1. - Telebelerle bagli \n2. - Ichilerle bagli \n3. - Cixish");
                    Console.Write("Seciminiz: ");
                    mainChoiseStr = Console.ReadLine();
                }
                while (!int.TryParse(mainChoiseStr, out mainChoise) || !(mainChoise >= 1 && mainChoise <= 3));


                switch (mainChoise)
                {
                    // Telebelerle bagli
                    case 1:

                        string stuChoiseStr;
                        int stuChoise;
                        do
                        {
                            Console.WriteLine("1.1 - Studentlerin siyahisini gostermek \n" +
                                "1.2 - Student  yaratmaq \n" +
                                "1.3 - Studentde deyisiklik etmek \n" +
                                "1.4 -  Studentlerin ortalama qiymetini gostermek ");
                            Console.Write("Seciminiz: ");
                            stuChoiseStr = Console.ReadLine();
                        }
                        while (!int.TryParse(stuChoiseStr, out stuChoise) || !(stuChoise >= 1 && stuChoise <= 4));

                        stuMethods(stuChoise, university,validation);

                        break;

                    // Ischilerle bagli
                    case 2:
                        string empChoiseStr;
                        int empChoise;
                        do
                        {
                            Console.WriteLine("2.1 - Iscilerin siyahisini gostermek \n" +
                                "2.2 - Universitydeki iscilerin siyahisini gostermrek \n" +
                                "2.3 - Isci elave etmek \n" +
                                "2.4 - Isci uzerinde deyisiklik etmek \n" +
                                "2.5 - Universityden isci silinmesi \n" +
                                "2.6 - Search ");
                            Console.Write("Seciminiz: ");
                            empChoiseStr = Console.ReadLine();
                        }
                        while (!int.TryParse(empChoiseStr, out empChoise) || !(empChoise >= 1 && empChoise <= 6));

                        empMethods(empChoise, university, validation);

                        break;

                    // Bitib
                    case 3:
                        return;
                }

            }

        }

        public static void stuMethods(int choise, University university, Validation validation)
        {

            switch (choise)
            {
                // Iscilerin siyahisini gostermek 
                case 1:
                    Console.WriteLine("Spesifik qrupa gore isteyirsizse, qrup novunu daxil edin. Eger istemirsinizse, bosh buraxin");

                    string filterGroupTypeStr;
                    int filterGroupType;
                    do
                    {
                        Console.Write("Qrup novunu daxil edin - (Programming - 1, Design - 2, System - 3): ");
                        filterGroupTypeStr = Console.ReadLine();

                    }
                    while ((!int.TryParse(filterGroupTypeStr, out filterGroupType) || !(filterGroupType >= 1 && filterGroupType <= 3))
                    && !(string.IsNullOrEmpty(filterGroupTypeStr)));



                    GroupType filterGroup;
                    if (filterGroupType == 1) filterGroup = GroupType.Programming;
                    else if (filterGroupType == 2) filterGroup = GroupType.Design;
                    else filterGroup = GroupType.System;

                    if (filterGroupType == 0)
                    {
                        foreach (var student in university.Students)
                        {
                            student.getInfo();
                        }

                    }
                    else
                    {
                        foreach (var student in university.Students.Where(s => s.GroupType == filterGroup))
                        {
                            student.getInfo();
                        }
                    }

                    break;

                // Student  yaratmaq 
                case 2:
                    Console.Write("Ad ve soyadi daxil edin: ");
                    string fullName = Console.ReadLine();


                    string groupTypeStr;
                    int groupType;
                    do
                    {
                        Console.Write("Qrup novunu daxil edin - (Programming - 1, Design - 2, System - 3): ");
                        groupTypeStr = Console.ReadLine();
                    }
                    while (!int.TryParse(groupTypeStr, out groupType) || !(groupType >= 1 && groupType <= 3));

                    GroupType group;

                    if (groupType == 1) group = GroupType.Programming;
                    else if (groupType == 2) group = GroupType.Design;
                    else group = GroupType.System;


                    string pointStr = "";
                    int point = 0;
                    validation.doWhileChecker_int("Bal: ", ref pointStr, ref point);


                    Student newStudent = new Student(fullName, group, point);
                    university.AddStudent(newStudent);

                    break;

                // Studentde deyisiklik etmek 
                case 3:
                    Console.Write("Deyisiklik edilecek telebenin qrup nomresin daxil edin: ");
                    string updateStudentGroupNo = Console.ReadLine();

                    Console.Write("Yeni qrup nomresi daxil edin: ");
                    string updateStudentNewGroupNo = Console.ReadLine();

                    university.StudentUpdate(updateStudentGroupNo, updateStudentNewGroupNo);

                    break;

                // Studentlerin ortalama qiymetini gostermek 
                case 4:
                    Console.WriteLine("Spesifik qrupa gore isteyirsizse, qrup novunu daxil edin. Eger istemirsinizse, bosh buraxin");

                    string averageGroupTypeStr;
                    int averageGroupType;
                    do
                    {
                        Console.Write("Qrup novunu daxil edin - (Programming - 1, Design - 2, System - 3): ");
                        averageGroupTypeStr = Console.ReadLine();

                    }
                    while ((!int.TryParse(averageGroupTypeStr, out averageGroupType) || !(averageGroupType >= 1 && averageGroupType <= 3))
                    && !(string.IsNullOrEmpty(averageGroupTypeStr)));



                    GroupType averageGroup;
                    if (averageGroupType == 1) averageGroup = GroupType.Programming;
                    else if (averageGroupType == 2) averageGroup = GroupType.Design;
                    else averageGroup = GroupType.System;



                    if (averageGroupType == 0)
                    {
                        averageGroup = 0;
                        double average = university.CalcStudentsAverage(averageGroup);
                        Console.WriteLine($"Butun telebelerin ortalama bali: {average}");

                    }
                    else
                    {
                        double average = university.CalcStudentsAverage(averageGroup);
                        Console.WriteLine($"Qrupun ortalama bali: {average}");
                    }

                    break;
            }
        }

        public static void empMethods(int choise, University university, Validation validation)
        {

            switch (choise)
            {
                // Iscilerin siyahisini gostermek 
                case 1:
                    Console.WriteLine("Butun isciler: ");

                    foreach (var employee in university.Employees)
                    {
                        employee.getInfo();
                    }

                    break;

                // Universitydeki iscilerin siyahisini gostermrek
                case 2:

                    string filterDepVStr;
                    int filterDepV;

                    do
                    {
                        Console.Write("Deparment daxil edin - (IT - 1, Maliyye - 2, Marketing - 3): ");
                        filterDepVStr = Console.ReadLine();
                    }
                    while (!int.TryParse(filterDepVStr, out filterDepV) || !(filterDepV >= 1 && filterDepV <= 3));

                    Department filterDep;
                    if (filterDepV == 1) filterDep = Department.IT;
                    else if (filterDepV == 2) filterDep = Department.Maliyye;
                    else filterDep = Department.Marketing;


                    foreach (var employee in university.Employees.Where(e => e.DepartmentName == filterDep))
                    {
                        employee.getInfo();
                    }

                    break;

                // Isci elave etmek
                case 3:

                    Console.Write("Ad ve soyadi daxil edin: ");
                    string fullName = Console.ReadLine();

                    Console.Write("Pozisiya daxil edin: ");
                    string position = Console.ReadLine();

                    string salaryStr = "";
                    double salary = 0;
                    validation.doWhileChecker_double("Maash daxil edin: ", ref salaryStr, ref salary);


                    string addDepVStr;
                    int addDepV;

                    do
                    {
                        Console.Write("Deparment daxil edin - (IT - 1, Maliyye - 2, Marketing - 3): ");
                        addDepVStr = Console.ReadLine();
                    }
                    while (!int.TryParse(addDepVStr, out addDepV) || !(addDepV >= 1 && addDepV <= 3));

                    Department addDep;
                    if (addDepV == 1) addDep = Department.IT;
                    else if (addDepV == 2) addDep = Department.Maliyye;
                    else addDep = Department.Marketing;



                    string empTypeVStr;
                    int empTypeV;

                    do
                    {
                        Console.Write("Is rejimini daxil edin - (Fulltime - 1, Parttime - 2, Adjunct - 3): ");
                        empTypeVStr = Console.ReadLine();
                    }
                    while (!int.TryParse(empTypeVStr, out empTypeV) || !(empTypeV >= 1 && empTypeV <= 3));

                    EmployeeType addEmpType;
                    if (empTypeV == 1) addEmpType = EmployeeType.Fulltime;
                    else if (empTypeV == 2) addEmpType = EmployeeType.Parttime;
                    else addEmpType = EmployeeType.Adjunct;

                    Employee newEmployee = new Employee(fullName, position, salary, addDep, addEmpType);
                    university.AddEmployee(newEmployee);

                    break;

                // Isci uzerinde deyisiklik etmek
                case 4:
                    Employee empUpdate;
                    string editEmpNo;
                    do
                    {
                        Console.Write("Deyisiklik edilecek iscinin No daxil edin: ");
                        editEmpNo = Console.ReadLine();
                        empUpdate = university.Employees.FirstOrDefault(e => e.No == editEmpNo);
                    } while (empUpdate == null);

                    string newSalaryStr = "";
                    double newSalary = 0;
                    validation.doWhileChecker_double("Yeni maash daxil edin: ", ref newSalaryStr, ref newSalary);

                    Console.Write("Yeni pozisiya daxil edin: ");
                    string newPosition = Console.ReadLine();
                    university.UpdateEmployee(editEmpNo, newSalary, newPosition);

                    break;

                // Universityden isci silinmesi
                case 5:

                    Console.Write("Silinecek iscinin No daxil edin: ");
                    string delEmpNo = Console.ReadLine();
                    university.DeleteEmployee(delEmpNo);

                    break;

                // Search();
                case 6:

                    Console.Write("Axtarish uchun ad soyad daxil edin: ");
                    string searchWord = Console.ReadLine();
                    var foundEmp = university.Employees.Where(e => e.Fullname.Contains(searchWord)).ToList();
                    Console.WriteLine("Tapilan isci:");
                    foreach (var emp in foundEmp)
                    {
                        emp.getInfo();
                    }

                    break;
            }
        }
    }


}
