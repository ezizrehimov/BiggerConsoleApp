﻿using System;
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
            Employee emo = new Employee("Salam");
            int count = emo.Validation("salam necesen sag");
            Console.WriteLine(count);

            //foreach (var item in emo.Validation("salam necesen sag")) {
            //    Console.WriteLine(item);
            //}

        }
    }
}