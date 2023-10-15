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

            University uni = new University("ez", 121, 121);

            uni.info();
            //foreach (var item in emo.Validation("salam necesen sag")) {
            //    Console.WriteLine(item);
            //}

        }
    }
}
