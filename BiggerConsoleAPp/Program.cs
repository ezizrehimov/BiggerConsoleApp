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

            // university uchun lazimi value-lar
            Console.Write("Universitet adini daxil edin: ");
            string uniName = Console.ReadLine();

            string uniWorkerLimitStr;
            int uniWorkerLimit;

            do
            {
                Console.Write("Ischi limitini daxil edin: ");
                uniWorkerLimitStr = Console.ReadLine();
            }
            while (!int.TryParse(uniWorkerLimitStr, out uniWorkerLimit));

            string uniSalaryLimitStr;
            double uniSalaryLimit;
            do
            {
                Console.Write("Maash limitini daxil edin: ");
                uniSalaryLimitStr = Console.ReadLine();
            }
            while (!double.TryParse(uniSalaryLimitStr, out uniSalaryLimit));

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

                        stuMethods(stuChoise, university);

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
                        break;

                    // Bitib
                    case 3:
                        return;
                }

            }

        }

        public static void stuMethods(int choise, University university)
        {

            switch (choise)
            {
                // Iscilerin siyahisini gostermek 
                case 1:
                    Console.Write("Spesifik qrupa gore isteyirsizse, qrup nomresini daxil edin. Eger istemirsinizse, bosh buraxin: ");
                    string filterGroupNo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(filterGroupNo))
                    {
                        foreach (var student in university.Students)
                        {
                            student.getInfo();
                        }

                    }
                    else
                    {
                        foreach (var student in university.Students.Where(s => s.GroupNo == filterGroupNo))
                        {
                            student.getInfo();
                        }
                    }

                    // bu 1ci variant idi :D

                    //Console.Write("Qrup nomresin daxil edin: ");
                    //string groupNo = Console.ReadLine();

                    //foreach (var student in university.Students.Where(s => s.GroupNo == groupNo))
                    //{
                    //    student.getInfo();
                    //}

                    break;

                // Universitydeki iscilerin siyahisini gostermrek 
                case 2:
                    Console.Write("Ad ve soyadi daxil edin: ");
                    string fullName = Console.ReadLine();


                    string groupTypeStr;
                    int groupType;
                    do
                    {
                        Console.WriteLine("Qrup novunu daxil edin - (Programming - 1, Design - 2, System - 3): ");
                        groupTypeStr = Console.ReadLine();
                    }
                    while (!int.TryParse(groupTypeStr, out groupType) || !(groupType >= 1 && groupType <= 3));

                    GroupType group;

                    if (groupType == 1) group = GroupType.Programming;
                    else if (groupType == 2) group = GroupType.Design;
                    else group = GroupType.System;


                    string pointStr;
                    int point;
                    do
                    {
                        Console.Write("Bal: ");
                        pointStr = Console.ReadLine();
                    }
                    while (!int.TryParse(pointStr, out point));


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

                    Console.Write("Spesifik qrupa gore isteyirsizse, qrup nomresini daxil edin. Eger istemirsinizse, bosh buraxin: ");
                    string specificGroupNo = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(specificGroupNo))
                    {
                        double average = university.CalcStudentsAverage("#empty");
                        Console.WriteLine($"Butun telebelerin ortalama bali: {average}");
                    }
                    else
                    {
                        double average = university.CalcStudentsAverage(specificGroupNo);
                        Console.WriteLine($"Qrupun ortalama bali: {average}");
                    }

                    break;
            }
        }

        public static void empMethods(int choise)
        {

            switch (choise)
            {
                case 1:
                    break;
            }
        }
    }


}
