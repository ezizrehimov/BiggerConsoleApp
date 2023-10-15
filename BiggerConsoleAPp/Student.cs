using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiggerConsoleAPp
{
    internal class Student : Validation
    {
        public static int id = 100;

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

        public GroupType GroupType { get; set; }

        public string GroupNo { get; set; }
        public int Point { get; set; }

        public Student(string fullname, GroupType groupType, int point)
        {
            id++;
            Fullname = fullname;
            GroupType = groupType;
            GroupNo = studentNo(groupType, id);
            Point = point;
        }

        // Telebeler haqqinda melumat
        public void getInfo()
        {
            Console.WriteLine($"Qrup nomresi: {GroupNo},\n" +
                $"Ad ve soyad: {Fullname},\n" +
                $"Qrup novu: {GroupType},\n" +
                $"Bal: {Point}");
        }

        // student No uchun validation
        public string studentNo(GroupType groupType, int id)
        {
            return groupType.ToString().Substring(0, 1).ToUpper() + id;
        }
    }
}
